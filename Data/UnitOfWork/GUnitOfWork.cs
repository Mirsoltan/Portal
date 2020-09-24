using Entities.LocationsEntities;
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

        private GenericRepository<Locations,TContext> _LocationsRepository;
        public GenericRepository<Locations,TContext> LocationsRepository
        {
            get
            {
                if (_LocationsRepository == null)
                {
                    _LocationsRepository = new GenericRepository<Locations,TContext>(_Context);
                }
                return _LocationsRepository;
            }
        }

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
