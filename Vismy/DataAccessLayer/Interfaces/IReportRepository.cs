using Vismy.Models.Interfaces;

namespace Vismy.DataAccessLayer.Interfaces
{
    public interface IReportRepository<T> : IRepository<IReport<T>>
    {
    }
}