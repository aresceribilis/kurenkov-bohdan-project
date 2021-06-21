using System.Collections.Generic;

namespace Vismy.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        string ConnectionString { get; set; }
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void Add(TEntity entity);
    }
}