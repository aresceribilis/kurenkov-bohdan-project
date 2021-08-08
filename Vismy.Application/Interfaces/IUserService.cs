using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vismy.Application.DTOs;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Interfaces
{
    public interface IUserService
    {
        public Task<int> GetUserPostsCountAsync(string nickname);
        public Task<IEnumerable<PostPreviewDTO>> GetUserPostsAsync(string nickname, int pageSize, int pageIndex = 0);
        public Task<bool> IsUserOwnPostAsync(string nickname, string postId);
        public Task<bool> UpdatePostAsync(PostInfoDTO postDto);
        public Task<bool> UpdateProfileAsync(UserInfoDTO userDto);
        public Task<PostInfoDTO> GetPostInfoAsync(string postId);
        public Task<IEnumerable<PostPreviewDTO>> GetPostPreviewsAsync(int pageSize, string filter, int pageIndex = 0);
        public Task<int> GetPostsCountAsync(string filter = null);
        public Task<UserInfoDTO> GetUserInfoAsync(ClaimsPrincipal userClaim);
        public Task<UserInfoDTO> GetUserInfoAsync(string nickname);
        public Task<IEnumerable<UserPreviewDTO>> GetUserPreviewsAsync(int pageSize, string filter, int pageIndex = 0);
        public Task<int> GetUsersCountAsync(string filter = null);
        public Task<string> GetUserIdAsync(string nickname);
        public Task<string> GetUserIdAsync(ClaimsPrincipal userClaim);
        public Task<IdentityResult> AddUserAsync(UserInfoDTO userDto, bool rememberMe);
        public Task ChangeRole(string email, string oldRole, string newRole);
        public Task SignOut();
        public Task<SignInResult> Login(UserInfoDTO userDto);
        public Task<bool> AddPostAsync(PostInfoDTO postDto);
        public Task EditPostAsync(PostInfoDTO postDto);
        public Task DeletePostAsync(string postId);
        public Task<int> GetUserFollowersCountAsync(string nickname = null);
        public Task<int> GetUserFollowingCountAsync(string nickname = null);
        public Task<IEnumerable<UserPreviewDTO>> GetUserFollowersAsync(string nickname, int pageSize, int pageIndex = 0);
        public Task<IEnumerable<UserPreviewDTO>> GetUserFollowingAsync(string nickname, int pageSize, int pageIndex = 0);
        public Task<bool> IsFollowedAsync(string userId, string followingId);
        public Task FollowUserAsync(string userId, string followingId);
        public Task ViewPostAsync(string userId, string postId);
        public Task LikePostAsync(string userId, string postId);
        public Task MakeReportAsync(string authorId, ReportInfoDTO reportDto);
    }
}