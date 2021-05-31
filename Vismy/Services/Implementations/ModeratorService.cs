using System;
using System.Linq;
using Vismy.DataAccessLayer.Implementations;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models;
using Vismy.Models.Interfaces;
using Vismy.Services.Interfaces;

namespace Vismy.Services.Implementations
{
    public class ModeratorService : IModeratorService
    {
        public IPostRepository PostRepository { get; set; } = new PostRepository();
        public IReportPostRepository ReportPostRepository { get; set; } = new ReportPostRepository();
        public IReportUserRepository ReportUserRepository { get; set; } = new ReportUserRepository();
        public IUserRepository UserRepository { get; set; } = new UserRepository();

        public void AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void FollowUser(IPerson user)
        {
            throw new NotImplementedException();
        }

        public void LikePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void MakeReport(IReport<IPerson> report)
        {
            throw new NotImplementedException();
        }

        public void MakeReport(IReport<Post> report)
        {
            throw new NotImplementedException();
        }

        public IOrderedEnumerable<IReport<IPerson>> GetUsersReports()
        {
            throw new NotImplementedException();
        }

        public IOrderedEnumerable<IReport<Post>> GetPostsReports()
        {
            throw new NotImplementedException();
        }

        public bool IsSensitiveContent(IReport<IPerson> report)
        {
            throw new NotImplementedException();
        }

        public bool IsSensitiveContent(IReport<Post> report)
        {
            throw new NotImplementedException();
        }
    }
}
