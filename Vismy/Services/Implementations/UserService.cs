using Vismy.DataAccessLayer.Implementations;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models;
using Vismy.Models.Interfaces;
using Vismy.Services.Interfaces;

namespace Vismy.Services.Implementations
{
    public class UserService : IUserService
    {
        public IPostRepository PostRepository { get; set; } = new PostRepository();
        public IReportPostRepository ReportPostRepository { get; set; } = new ReportPostRepository();
        public IReportUserRepository ReportUserRepository { get; set; } = new ReportUserRepository();
        public IUserRepository UserRepository { get; set; } = new UserRepository();

        public void AddPost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public void EditPost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public void FollowUser(IPerson user)
        {
            throw new System.NotImplementedException();
        }

        public void LikePost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public void MakeReport(IReport<IPerson> report)
        {
            throw new System.NotImplementedException();
        }

        public void MakeReport(IReport<Post> report)
        {
            throw new System.NotImplementedException();
        }
    }
}