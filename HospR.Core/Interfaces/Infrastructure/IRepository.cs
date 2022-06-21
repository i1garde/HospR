using System.Linq.Expressions;

namespace HospR.Core.Interfaces.Infrastructure;

public interface IRepository<T, K>
{
    Task<IEnumerable<T>> All();
    Task<T> GetById(K id);
    Task Add(T entity);
    Task Delete(K id);
    Task Update(T entity);
}
