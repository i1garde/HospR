using System.Linq.Expressions;

namespace HospR.Core.Interfaces;

public interface IAsyncRepository<T> where T: class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Find(Expression<Predicate<T>> predicate);
    Task Add(T entity);
    Task Update(T entity);
    Task Remove(T entity);
}