using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data
{
    public class GUnitOfWork<TContext> : IDisposable, IGUnitOfWork<TContext> where TContext : DbContext
    {
        //private readonly ApplicationDbContext _Context;
        private TContext _Context { get; }
        public GUnitOfWork()
        {

        }

        public GUnitOfWork(TContext Context)
        {
            _Context = Context;
        }

        //private GenericRepository<MEDevice> _MEDeviceRepository;
        //public GenericRepository<MEDevice> MEDeviceRepository
        //{
        //    get
        //    {
        //        if (_MEDeviceRepository == null)
        //        {
        //            _MEDeviceRepository = new GenericRepository<MEDevice>(_Context);
        //        }
        //        return _MEDeviceRepository;
        //    }
        //}

        public IGenericRepository<TEntity> IGenericRepository<TEntity>() where TEntity : class
        {
            IGenericRepository<TEntity> repository = new GenericRepository<TEntity, TContext>(_Context);
            return repository;
        }

        public async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
