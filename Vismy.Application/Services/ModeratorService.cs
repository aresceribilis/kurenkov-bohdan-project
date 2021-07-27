using System;
using System.Collections.Generic;
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
    public class ModeratorService : IModeratorService
    {
        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Report> ReportRepository { get; set; }
        public IRepository<AspNetUser> UserRepository { get; set; }

        public ModeratorService(
            IRepository<Post> postRepository,
            IRepository<Report> reportRepository,
            IRepository<AspNetUser> userRepository)
        {
            PostRepository = postRepository;
            ReportRepository = reportRepository;
            UserRepository = userRepository;
        }

        public async Task<IEnumerable<Report>> GetReportsAsync()
        {
            // TODO: solve how to get reports OrderByDescending(urm => urm.Name == "Approved" - urm.Name = "Disapproved")
            //return await ReportRepository.GetAsync(null, null,
            //    rq => rq
            //        .OrderByDescending(r => r
            //            .UserReportAuthors.Count)
            //    , 0, 10);
            throw new NotImplementedException();
        }

        public async Task IsSensitiveContentAsync(AspNetUser moderator, Report report, bool decision)
        {
            throw new NotImplementedException();
        }
    }
}
