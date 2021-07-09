using System;
using System.Linq;
using Vismy.DataAccessLayer.Implementations;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models;
using Vismy.Models.Interfaces;
using Vismy.Services.Interfaces;

namespace Vismy.Services.Implementations
{
    public class AdministratorService : IAdministratorService
    {
        public IPostRepository PostRepository { get; set; }
        public IReportPostRepository ReportPostRepository { get; set; }
        public IReportUserRepository ReportUserRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public AdministratorService(string connectionString)
        {
            PostRepository = new PostRepository(connectionString);
            ReportPostRepository = new ReportPostRepository(connectionString);
            ReportUserRepository = new ReportUserRepository(connectionString);
            UserRepository = new UserRepository(connectionString);
        }

        public void AddPost(Post post)
        {
            PostRepository.Add(post);
        }

        public void EditPost(Post post)
        {
            PostRepository.Update(post);
        }

        public void DeletePost(Post post)
        {
            PostRepository.Delete(post);
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
            ReportUserRepository.Add(report);
        }

        public void MakeReport(IReport<Post> report)
        {
            ReportPostRepository.Add(report);
        }

        public IOrderedEnumerable<IReport<IPerson>> GetUsersReports()
        {
            return ReportUserRepository.GetAll().OrderByDescending(r => r.Moderators.Count);
        }

        public IOrderedEnumerable<IReport<Post>> GetPostsReports()
        {
            return ReportPostRepository.GetAll().OrderByDescending(r => r.Moderators.Count);
        }

        public void Approve(IReport<IPerson> report)
        {
            PostRepository
                .GetAll()
                .Where(a => a.Id == report.Entity.Id)
                .ToList()
                .ForEach(p => PostRepository.Delete(p));
            UserRepository.Delete(report.Entity);
            ReportUserRepository.Delete(report);
        }

        public void Approve(IReport<Post> report)
        {
            // TODO: delete video from hard disk
            PostRepository.Delete(report.Entity);
            ReportPostRepository.Delete(report);
        }

        public void Decline(IReport<IPerson> report)
        {
            ReportUserRepository.Delete(report);
        }

        public void Decline(IReport<Post> report)
        {
            ReportPostRepository.Delete(report);
        }
    }
}