using System.Collections.Generic;
using System.Threading.Tasks;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Interfaces
{
    public interface IAdministratorService
    {
        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Report> ReportRepository { get; set; }
        public IRepository<AspNetUser> UserRepository { get; set; }

        Task<IEnumerable<Report>> GetReportsAsync();
        Task ApproveReportAsync(Report report);
        Task DeclineReportAsync(Report report);
    }
}