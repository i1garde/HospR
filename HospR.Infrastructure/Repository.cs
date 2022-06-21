using HospR.Core.Entities;
using HospR.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HospR.Infrastructure
{
    public class Repository<T, K> : IRepository<T, K> where T : EntityBase<K>
    {
        protected HospRDbContext _hospRDbContext;

        public Repository(HospRDbContext context)
        {
            this._hospRDbContext = context;
        }

        public async Task Add(T entity)
        {
            await this._hospRDbContext.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _hospRDbContext.Set<T>().ToListAsync();
        }

        public async Task Delete(K id)
        {
            var get = await this.GetById(id);
            _hospRDbContext.Set<T>().Remove(get);
        }

        public async Task<T> GetById(K id)
        {
            return await _hospRDbContext.Set<T>().FindAsync(id) ?? throw new InvalidOperationException();
        }

        public async Task Update(T entity)
        {
            T find = await this.GetById(entity.Id);
            _hospRDbContext.Entry(find).CurrentValues.SetValues(entity);
        }
    }
}
