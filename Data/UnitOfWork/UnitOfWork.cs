using Data.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PortalDbContext _Context { get; }
        //private IMapper _mapper;
        private readonly IConfiguration _configuration;


        public UnitOfWork(PortalDbContext context, IConfiguration configuration)
        {
            _Context = context;
            //_mapper = mapper;
            _configuration = configuration;
        }

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class
        {
            IBaseRepository<TEntity> repository = new BaseRepository<TEntity, PortalDbContext>(_Context);
            return repository;
        }

        public async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Context.DisposeAsync();
        }
    }
}
