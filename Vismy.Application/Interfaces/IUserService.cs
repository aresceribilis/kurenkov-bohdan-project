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

        public Task AddPostAsync(AspNetUser user, Post post);
        public Task EditPostAsync(Post post);
        public Task DeletePostAsync(Post post);
        public Task FollowUserAsync(AspNetUser user, AspNetUser follower);
        public Task LikePostAsync(AspNetUser user, Post post);
        public Task MakeReportAsync(AspNetUser author, Report report);
    }
}