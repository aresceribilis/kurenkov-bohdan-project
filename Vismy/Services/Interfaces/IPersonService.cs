using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models;
using Vismy.Models.Interfaces;

namespace Vismy.Services.Interfaces
{
    public interface IPersonService
    {
        public IPostRepository PostRepository { get; set; }
        public IReportPostRepository ReportPostRepository { get; set; }
        public IReportUserRepository ReportUserRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public void AddPost(Post post);
        public void EditPost(Post post);
        public void DeletePost(Post post);
        public void FollowUser(IPerson user);
        public void LikePost(Post post);
        public void MakeReport(IReport<IPerson> report);
        public void MakeReport(IReport<Post> report);
    }
}