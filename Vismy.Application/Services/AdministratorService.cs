using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vismy.Application.Interfaces;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;
using System.Linq;
using Vismy.Core.Models.Statuses;

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
    public class AdministratorService : IAdministratorService
    {
        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Report> ReportRepository { get; set; }
        public IRepository<AspNetUser> UserRepository { get; set; }

        public AdministratorService(
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
            //return await ReportRepository.GetAsync(null, null,
            //    rq => rq
            //        .OrderByDescending(r => r
            //                    .UserReportModerators
            //                    .Count
            //                - r
            //                    .UserReportModerators
            //                    .Count(urm => urm
            //                        .UserReportModeratorStatus
            //                        .Name == "Disapproved"))
            //, 0, 10);
            throw new NotImplementedException();
        }

        public async Task ApproveReportAsync(Report report)
        {
            //await PostRepository.DeleteAsync(report.Post);
            throw new NotImplementedException();
        }

        public async Task DeclineReportAsync(Report report)
        {
            //await ReportRepository.DeleteAsync(report);
            throw new NotImplementedException();
        }
    }
}