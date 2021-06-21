using System.Collections.Generic;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models;
using Vismy.Models.Interfaces;

namespace Vismy.DataAccessLayer.Implementations
{
    public class ReportPostRepository : IReportPostRepository
    {
        public string ConnectionString { get; set; }

        public ReportPostRepository(string connectionString) => ConnectionString = connectionString;

        public IEnumerable<IReport<Post>> GetAll()
        {
            return DatabaseMock.PostsReports;
        }

        public IReport<Post> GetById(int id)
        {
            return DatabaseMock.PostsReports.Find(p => p.Id == id);
        }

        public void Update(IReport<Post> entity)
        {
            Delete(GetById(entity.Id));
            Add(entity);
        }

        public void Delete(IReport<Post> entity)
        {
            DatabaseMock.PostsReports.Remove(entity);
        }

        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }

        public void Add(IReport<Post> entity)
        {
            DatabaseMock.PostsReports.Add(entity);
        }
    }
}