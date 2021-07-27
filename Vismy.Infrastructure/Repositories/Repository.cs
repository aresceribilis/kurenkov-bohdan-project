using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Interfaces;
using Vismy.Infrastructure.Context;

namespace Vismy.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly VismyContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(VismyContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T obj)
        {
            _dbSet.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id, string includeProperties)
        {
            return (await GetAsync(i => i.Id == id, includeProperties)).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int skip = 0, int take = 0)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                var split = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var property in split)
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != 0 && skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take != 0 && take > 0)
            {
                query = query.Take(take);
            }

            return await query.ToListAsync();
        }
    }
}