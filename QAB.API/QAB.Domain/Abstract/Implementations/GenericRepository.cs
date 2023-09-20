using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QAB.Domain.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Abstract.Implementations
{
    public class GenericRepository<T> : IGenericRpository<T> where T : class
    {
        private readonly DbContext _context;
        public DbSet<T> _dbSet;
        public IQueryable<T> Table { get; }

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            Table = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(object id)
        {
            T? entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
