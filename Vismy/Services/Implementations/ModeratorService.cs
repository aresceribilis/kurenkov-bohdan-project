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
        public IPostRepository PostRepository { get; set; }
        public IReportPostRepository ReportPostRepository { get; set; }
        public IReportUserRepository ReportUserRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public ModeratorService(string connectionString)
        {
            PostRepository = new PostRepository(connectionString);
            ReportPostRepository = new ReportPostRepository(connectionString);
            ReportUserRepository = new ReportUserRepository(connectionString);
            UserRepository = new UserRepository(connectionString);
        }

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
