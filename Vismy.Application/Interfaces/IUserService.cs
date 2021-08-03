using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vismy.Application.DTOs;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> AddUserAsync(UserInfoDTO userDto, bool rememberMe);
        public Task ChangeRole(string email, string oldRole, string newRole);
        public Task SignOut();
        public Task<SignInResult> Login(UserInfoDTO userDto);
        public Task AddPostAsync(PostInfoDTO postDto);
        public Task EditPostAsync(PostInfoDTO postDto);
        public Task DeletePostAsync(int postId);
        public Task FollowUserAsync(string userId, string followingId);
        public Task ViewPostAsync(string userId, int postId);
        public Task LikePostAsync(string userId, int postId);
        public Task MakeReportAsync(string authorId, ReportInfoDTO reportDto);
    }
}