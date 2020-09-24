using AutoMapper;
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
        public PortalDbContext _Context { get; }

        private ILocationRepository _ILocationRepository;

        private IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UnitOfWork(PortalDbContext context)
        {
            _Context = context;
        }
        public UnitOfWork(PortalDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
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

        public ILocationRepository ILocationRepository
        {
            get
                {
                if (_ILocationRepository == null)
                {
                    _ILocationRepository = new LocationRepository(_Context);
                }
                return _ILocationRepository;
            }
        }
    }
}


