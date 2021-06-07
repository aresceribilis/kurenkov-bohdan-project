using System.Collections.Generic;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models.Interfaces;

namespace Vismy.DataAccessLayer.Implementations
{
    public class ReportUserRepository : IReportUserRepository
    {
        public IEnumerable<IReport<IPerson>> GetAll()
        {
            return DatabaseMock.UsersReports;
        }

        public IReport<IPerson> GetById(int id)
        {
            return DatabaseMock.UsersReports.Find(p => p.Id == id);
        }

        public void Update(IReport<IPerson> entity)
        {
            Delete(GetById(entity.Id));
            Add(entity);
        }

        public void Delete(IReport<IPerson> entity)
        {
            DatabaseMock.UsersReports.Remove(entity);
        }

        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }

        public void Add(IReport<IPerson> entity)
        {
            DatabaseMock.UsersReports.Add(entity);
        }
    }
}