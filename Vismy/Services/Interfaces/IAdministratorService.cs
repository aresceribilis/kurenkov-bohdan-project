using System.Linq;
using Vismy.Models;
using Vismy.Models.Interfaces;

namespace Vismy.Services.Interfaces
{
    public interface IAdministratorService : IPersonService
    {
        IOrderedEnumerable<IReport<IPerson>> GetUsersReports();
        IOrderedEnumerable<IReport<Post>> GetPostsReports();
        void Approve(IReport<IPerson> report);
        void Approve(IReport<Post> report);
        void Decline(IReport<IPerson> report);
        void Decline(IReport<Post> report);
    }
}