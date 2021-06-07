using System.Linq;
using Vismy.Models;
using Vismy.Models.Interfaces;

namespace Vismy.Services.Interfaces
{
    public interface IModeratorService : IPersonService
    {
        IOrderedEnumerable<IReport<IPerson>> GetUsersReports();
        IOrderedEnumerable<IReport<Post>> GetPostsReports();
        bool IsSensitiveContent(IReport<IPerson> report);
        bool IsSensitiveContent(IReport<Post> report);
    }
}