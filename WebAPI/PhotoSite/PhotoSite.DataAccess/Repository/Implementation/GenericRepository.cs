using Microsoft.EntityFrameworkCore;
using PhotoSite.Data.Context;
using PhotoSite.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSite.DataAccess.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PhotoSiteDbContext _context;
        private DbSet<T> table;

        public GenericRepository(PhotoSiteDbContext context)
        {
            _context = context;
            table = _context.Set<T>();  
        }

        public async Task Add(T entity)
        {
            await table.AddAsync(entity);
        }

        public async Task AddRange(IList<T> entities)
        {
            await table.AddRangeAsync(entities);
        }

        public async Task Delete(Guid EntityId)
        {
            var entity = await ReadSingle(EntityId);
            table.Remove(entity);
        }

        public void DeleteRange(IList<T> entities)
        {
            table.RemoveRange(entities);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();   
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            return await table.ToListAsync();
        }

        public IQueryable<T> ReadAllQuery()
        {
            return table.AsQueryable(); 
        }

        public async Task<T> ReadSingle(Guid EntityId)
        {
            return await table.FindAsync(EntityId);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IList<T> entities)
        {
            table.UpdateRange(entities);
        }
    }
}
