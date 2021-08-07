using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Vismy.Core.Interfaces
{
    public interface IRepository<T>
    {
        public Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
        public Task AddAsync(T obj);
        public Task UpdateAsync(T obj);
        public Task DeleteAsync(T obj);
        //public Task<T> GetByIdAsync(int id, string includeProperties);
        public Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null, 
            //List<Expression<Func<T, object>>> includes = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int skip = 0, 
            int take = 0);
    }
}