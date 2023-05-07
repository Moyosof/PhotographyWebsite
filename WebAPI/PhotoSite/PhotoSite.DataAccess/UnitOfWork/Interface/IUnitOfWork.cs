using PhotoSite.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSite.DataAccess.UnitOfWork.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Repository { get; }
        Task<bool> SaveAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction(); 
    }
}
