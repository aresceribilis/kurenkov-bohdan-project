using System.Threading.Tasks;
using Vismy.Application.Interfaces;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;

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
        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Report> ReportRepository { get; set; }
        public IRepository<AspNetUser> UserRepository { get; set; }

        public UserService(
            IRepository<Post> postRepository,
            IRepository<Report> reportRepository,
            IRepository<AspNetUser> userRepository)
        {
            PostRepository = postRepository;
            ReportRepository = reportRepository;
            UserRepository = userRepository;
        }

        public async Task AddPostAsync(AspNetUser user, Post post)
        {
            //await PostRepository.AddAsync(post);
            throw new System.NotImplementedException();
        }

        public async Task EditPostAsync(Post post)
        {
            //await PostRepository.UpdateAsync(post);
            throw new System.NotImplementedException();
        }

        public async Task DeletePostAsync(Post post)
        {
            //await PostRepository.DeleteAsync(post);
            throw new System.NotImplementedException();
        }

        public async Task FollowUserAsync(AspNetUser user, AspNetUser follower)
        {
            throw new System.NotImplementedException();
        }

        public async Task LikePostAsync(AspNetUser user, Post post)
        {
            throw new System.NotImplementedException();
        }

        public async Task MakeReportAsync(AspNetUser author, Report report)
        {
            throw new System.NotImplementedException();
        }
    }
}