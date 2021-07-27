using System.Collections.Generic;
using System.Threading.Tasks;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Interfaces
{
    public interface IModeratorService
    {
        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Report> ReportRepository { get; set; }
        public IRepository<AspNetUser> UserRepository { get; set; }

        Task<IEnumerable<Report>> GetReportsAsync();
        Task IsSensitiveContentAsync(AspNetUser moderator, Report report, bool decision);
    }
}