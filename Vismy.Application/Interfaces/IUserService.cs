using System.Threading.Tasks;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Interfaces
{
    public interface IUserService
    {
        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Report> ReportRepository { get; set; }
        public IRepository<AspNetUser> UserRepository { get; set; }

        public Task AddPostAsync(int userId, Post post);
        public Task EditPostAsync(Post post);
        public Task DeletePostAsync(int postId);
        public Task FollowUserAsync(int userId, int followingId);
        public Task ViewPostAsync(int userId, int postId);
        public Task LikePostAsync(int userId, int postId);
        public Task MakeReportAsync(int userId, Report report);
    }
}