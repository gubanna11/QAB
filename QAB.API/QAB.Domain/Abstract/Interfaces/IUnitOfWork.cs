using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Abstract.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRpository<T> GenericRpository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
