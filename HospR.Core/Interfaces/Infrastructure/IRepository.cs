using System.Linq.Expressions;

namespace HospR.Core.Interfaces.Infrastructure;

public interface IRepository<T, K>
{
    IEnumerable<T> All();
    T GetById(K id);
    void Add(T entity);
    void Delete(K id);
    void Update(T entity);
}
