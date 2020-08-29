using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        //PortalDbContext _Context { get; }
        Task Commit();
    }
}
