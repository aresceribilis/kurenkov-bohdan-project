using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Vismy.Core.Models.Interfaces
{
    public interface IRepository<T>
    {
        public Task Add(T obj);
        public Task Update(T obj);
        public Task Delete(T obj);
        public Task<T> GetById(int id, string includeProperties);
        public Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null, 
            string includeProperties = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int skip = 0, 
            int take = 0);
    }
}