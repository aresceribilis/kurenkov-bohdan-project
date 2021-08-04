using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Vismy.Application.DTOs;
using Vismy.Application.Interfaces;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Joins;
using Vismy.Core.Models.Statuses;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Vismy.Application.Services
{
    // TODO: define DTOs
    // TODO: define VMs
    // TODO: configure Model-DTO and DTO-VM maps
    // TODO: put VMs as methods parameters
    // TODO: add automapper service
    // TODO: add validation service for DTOs
    // TODO: get VM -> map into DTOs -> validate -> map into Models -> use repository
    // TODO: get Model -> map into DTOs -> do business logic -> map into VMs -> return to the Presentation
    public class UserService : IUserService
    {
        public IMapper Mapper { get; set; }
        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Tag> TagRepository { get; set; }
        public IRepository<PostTag> PostTagRepository { get; set; }
        public IRepository<PostStatus> PostStatusRepository { get; set; }
        public IRepository<Report> ReportRepository { get; set; }
        public IRepository<AspNetUser> UserRepository { get; set; }
        public IRepository<UserUser> UserUserRepository { get; set; }
        public IRepository<UserPost> UserPostRepository { get; set; }
        public IRepository<UserPostStatus> UserPostStatusRepository { get; set; }
        public IRepository<UserReportAuthor> UserReportAuthorRepository { get; set; }
        public UserManager<AspNetUser> UserManager { get; set; }
        public SignInManager<AspNetUser> SignInManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public UserService(
            IMapper mapper,
            IRepository<Post> postRepository,
            IRepository<Tag> tagRepository,
            IRepository<PostTag> postTagRepository,
            IRepository<PostStatus> postStatusRepository,
            IRepository<Report> reportRepository,
            IRepository<AspNetUser> userRepository,
            IRepository<UserUser> userUserRepository,
            IRepository<UserPost> userPostRepository,
            IRepository<UserPostStatus> userPostStatusRepository,
            IRepository<UserReportAuthor> userReportAuthorRepository,
            UserManager<AspNetUser> userManager,
            SignInManager<AspNetUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            Mapper = mapper;
            PostRepository = postRepository;
            TagRepository = tagRepository;
            PostTagRepository = postTagRepository;
            PostStatusRepository = postStatusRepository;
            ReportRepository = reportRepository;
            UserRepository = userRepository;
            UserUserRepository = userUserRepository;
            UserPostRepository = userPostRepository;
            UserPostStatusRepository = userPostStatusRepository;
            UserReportAuthorRepository = userReportAuthorRepository;
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public async Task<string> GetUserIdAsync(ClaimsPrincipal userClaim) => (await UserManager.GetUserAsync(userClaim)).Id;

        public async Task<IdentityResult> AddUserAsync(UserInfoDTO userDto, bool rememberMe)
        {
            var user = Mapper.Map<AspNetUser>(userDto);

            var result = await UserManager.CreateAsync(user, user.PasswordHash);

            if (!result.Succeeded) return result;

            await SignInManager.SignInAsync(user, rememberMe);

            if (!await RoleManager.RoleExistsAsync("User"))
                await RoleManager.CreateAsync(new IdentityRole() { Name = "User" });

            await UserManager.AddToRoleAsync(user, "User");

            return result;
        }

        public async Task ChangeRole(string email, string oldRole, string newRole)
        {
            var user = await UserManager.FindByEmailAsync(email);

            if (await RoleManager.RoleExistsAsync(oldRole))
                if (await UserManager.IsInRoleAsync(user, oldRole))
                    await UserManager.RemoveFromRoleAsync(user, oldRole);

            if (!await RoleManager.RoleExistsAsync(newRole))
                await RoleManager.CreateAsync(new IdentityRole() { Name = newRole });
            await UserManager.AddToRoleAsync(user, newRole);

            await SignInManager.RefreshSignInAsync(user);
        }

        public async Task SignOut() => await SignInManager.SignOutAsync();

        public async Task<SignInResult> Login(UserInfoDTO userDto)
        {
            var user = await UserManager.FindByNameAsync(userDto.Email);

            return await SignInManager.PasswordSignInAsync(user, userDto.Password, userDto.RememberMe, false);
        }

        public async Task<bool> AddPostAsync(PostInfoDTO postDto)
        {
            //var post = Mapper.Map<Post>(postDto);

            var post = new Post()
            {
                Id = Guid.NewGuid().ToString(),
                Title = postDto.Title,
                Description = postDto.Description,
                UserId = postDto.AuthorId,
                Shared = 0
            };

            try
            {
                var postStatus = (await PostStatusRepository.GetAsync(ps => ps.Name == "None")).FirstOrDefault();
                if (postStatus == null)
                {
                    await PostStatusRepository.AddAsync(new PostStatus() { Name = "None", Description = "No one status is applied." });
                    postStatus = (await PostStatusRepository.GetAsync(ps => ps.Name == "None")).FirstOrDefault();
                }
                post.PostStatusId = postStatus.Id;

                await PostRepository.AddAsync(post);

                var tagSs = postDto.Tags;
                foreach (var tagS in tagSs)
                {
                    var tag = (await TagRepository.GetAsync(t => t.Name == tagS)).FirstOrDefault();
                    if (tag == null)
                    {
                        tag = new Tag() { Id = Guid.NewGuid().ToString(), Name = tagS };

                        await TagRepository.AddAsync(tag);
                    }

                    var postTag = new PostTag()
                    {
                        PostId = post.Id,
                        TagId = tag.Id
                    };

                    await PostTagRepository.AddAsync(postTag);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task EditPostAsync(PostInfoDTO postDto) => await PostRepository.UpdateAsync(Mapper.Map<Post>(postDto));

        public async Task DeletePostAsync(string postId) => await PostRepository.DeleteAsync(new Post() { Id = postId });

        public async Task FollowUserAsync(string userId, string followingId)
        {
            var userUser =
                (await UserUserRepository.GetAsync(uu =>
                    (uu.UserId == userId) &&
                    (uu.FollowerId == followingId)))
                .FirstOrDefault();

            if (userUser != null)
                await UserUserRepository.DeleteAsync(userUser);
            else
            {
                var user = (await UserRepository
                    .GetAsync(u =>
                        u.Id == userId,
                        "UserUserUsers"))
                    .FirstOrDefault();
                var following = (await UserRepository
                    .GetAsync(u =>
                        u.Id == userId,
                        "UserUserFollowers"))
                    .FirstOrDefault();

                userUser = new UserUser()
                {
                    User = user,
                    Follower = following,
                    UserId = user.Id,
                    FollowerId = followingId
                };

                await UserUserRepository.AddAsync(userUser);

                user.UserUserUsers.Add(userUser);
                following.UserUserFollowers.Add(userUser);

                await UserRepository.UpdateAsync(user);
                await UserRepository.UpdateAsync(following);
            }
        }

        public async Task ViewPostAsync(string userId, string postId)
        {
            var userPost =
                (await UserPostRepository.GetAsync(uu =>
                    (uu.UserId == userId) &&
                    (uu.PostId == postId)))
                .FirstOrDefault();

            if (userPost == null)
            {
                var user = (await UserRepository
                    .GetAsync(u =>
                        u.Id == userId,
                        "UserPosts"))
                    .FirstOrDefault();
                var post = (await PostRepository.GetAsync(p =>
                        p.Id == postId,
                        "UserPosts"))
                    .FirstOrDefault();
                var userPostStatus =
                    (await UserPostStatusRepository
                        .GetAsync(i =>
                            i.Name == "Viewed"))
                    .FirstOrDefault();

                userPost = new UserPost()
                {
                    User = user,
                    UserId = user.Id,
                    Post = post,
                    PostId = postId,
                    UserPostStatus = userPostStatus,
                    UserPostStatusId = userPostStatus.Id
                };

                user.UserPosts.Add(userPost);
                post.UserPosts.Add(userPost);
            }
        }

        public async Task LikePostAsync(string userId, string postId)
        {
            var userPost =
                (await UserPostRepository.GetAsync(uu =>
                    (uu.UserId == userId) &&
                    (uu.PostId == postId),
                    "UserPostStatus"))
                .FirstOrDefault();

            if (userPost.UserPostStatus.Name == "Liked")
            {
                userPost.UserPostStatus.Name = "Viewed";
                userPost.UserPostStatus.Description = "View shows you viewed the post before.";
            }
            else
            {
                userPost.UserPostStatus.Name = "Liked";
                userPost.UserPostStatus.Description = "Like shows you appreciate the post.";
            }

            await UserPostRepository.UpdateAsync(userPost);
        }

        public async Task MakeReportAsync(string authorId, ReportInfoDTO reportDto)
        {
            var report = (await ReportRepository
                    .GetAsync(r =>
                        (r.PostId == reportDto.Post.Id) &&
                        (r.ReportStatus.Name == reportDto.TypeName),
                        "UserReportAuthors"))
                .FirstOrDefault();
            var author = (await UserRepository.GetAsync(u => u.Id == authorId)).FirstOrDefault();

            if (report == null)
            {
                report = Mapper.Map<Report>(reportDto);

                var userReportAuthor = new UserReportAuthor()
                {
                    Report = report,
                    ReportId = report.Id,
                    User = author,
                    UserId = authorId
                };
                await UserReportAuthorRepository.AddAsync(userReportAuthor);

                report.UserReportAuthors.Add(userReportAuthor);
                await ReportRepository.UpdateAsync(report);
            }
            else if (report.UserReportAuthors
                .Contains((await UserReportAuthorRepository
                    .GetAsync(ura =>
                        (ura.UserId == authorId) &&
                        (ura.ReportId == report.Id)))
                    .FirstOrDefault()))
            {
                var userReportAuthor = new UserReportAuthor()
                {
                    Report = report,
                    ReportId = report.Id,
                    User = author,
                    UserId = authorId
                };
                await UserReportAuthorRepository.AddAsync(userReportAuthor);

                report.UserReportAuthors.Add(userReportAuthor);
                await ReportRepository.UpdateAsync(report);
            }
        }
    }
}