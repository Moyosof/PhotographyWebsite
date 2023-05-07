using PhotoSite.Data.Context;
using PhotoSite.DataAccess.Repository.Implementation;
using PhotoSite.DataAccess.Repository.Interface;
using PhotoSite.DataAccess.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSite.DataAccess.UnitOfWork.Implementation
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly PhotoSiteDbContext _context;
        private IGenericRepository<T> _repository;

        public UnitOfWork(PhotoSiteDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> Repository => _repository ??= new GenericRepository<T>(_context);

        public void BeginTransaction() => _context.Database.BeginTransaction();


        public void CommitTransaction() => _context.Database.CommitTransaction();


        public void RollbackTransaction() => _context.Database.RollbackTransaction();
       

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            try
            {
                result = await _context.SaveChangesAsync() >= 0;
            }
            catch(Exception)
            {
                throw;
            }

            return result;
        }
    }
}
