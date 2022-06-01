using HospR.Core.Entities;
using HospR.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Infrastructure
{
    public class Repository<T, K> : IRepository<T, K> where T : EntityBase<K>
    {
        protected HospRDbContext _hospRDbContext;

        public Repository(HospRDbContext context)
        {
            this._hospRDbContext = context;
        }

        public void Add(T entity)
        {
            this._hospRDbContext.Set<T>().Add(entity);
        }

        public IEnumerable<T> All()
        {
            return _hospRDbContext.Set<T>();
        }

        public void Delete(K id)
        {
            _hospRDbContext.Set<T>().Remove(this.GetById(id));
        }

        public T GetById(K id)
        {
            return _hospRDbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            T find = this.GetById(entity.Id);
            _hospRDbContext.Entry(find).CurrentValues.SetValues(entity);
        }
    }
}
