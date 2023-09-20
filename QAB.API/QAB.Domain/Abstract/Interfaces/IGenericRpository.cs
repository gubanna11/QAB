using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Abstract.Interfaces
{
    public interface IGenericRpository<T> where T : class
    {
        public IQueryable<T> Table { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(object id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(object id);
        void RemoveRange(IEnumerable<T> entitities);
    }
}
