using System.Collections.Generic;

namespace Vismy.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void Add(TEntity entity);
    }
}