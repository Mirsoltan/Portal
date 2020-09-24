using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        /// <summary>
        /// برای جاهایی که نیاز است به خود کانتکست دسترسی داشته باشیم
        /// مثل   _Context.Query
        /// </summary>
        PortalDbContext _Context { get; }
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        Task Commit();



        ILocationRepository ILocationRepository { get; }
    }
}
