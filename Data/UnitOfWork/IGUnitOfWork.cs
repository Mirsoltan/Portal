using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data
{
    public interface IGUnitOfWork<TContext> : IDisposable
    {
        IGenericRepository<TEntity> IGenericRepository<TEntity>() where TEntity : class;
        //IGenericRepository<TEntity> IGenericRepository<TEntity>(TContext context) where TEntity : class;

        Task Commit();
    }
}
