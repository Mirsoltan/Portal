using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class where TContext : DbContext
    {
        //private readonly ApplicationDbContext _context;
        protected TContext _context { get; set; }
    private DbSet<TEntity> _db;

    public GenericRepository()
    {

    }
    public GenericRepository(TContext context)
    {
        _context = context;
        _db = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> where = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
        string includes = null)
    {
        IQueryable<TEntity> query = _db;
        if (where != null)
        {
            query = query.Where(where);
        }
        if (orderby != null)
        {
            query = orderby(query);
        }
        if (includes != null)
        {
            foreach (string inc in includes.Split(","))
            {
                query = query.Include(inc);
            }
        }
        return await query.AsNoTracking().ToListAsync();
    }

    public IEnumerable<TEntity> GetAll(
        Expression<Func<TEntity, bool>> where = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
        string includes = null)
    {
        IQueryable<TEntity> query = _db;
        if (where != null)
        {
            query = query.Where(where);
        }
        if (orderby != null)
        {
            query = orderby(query);
        }
        if (includes != null)
        {
            foreach (string inc in includes.Split(","))
            {
                query = query.Include(inc);
            }
        }
        return query.AsNoTracking().ToList();
    }
    public virtual IEnumerable<TEntity> GetAll_Old(
        Expression<Func<TEntity, bool>> where = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
        string includes = null)
    {
        IQueryable<TEntity> query = _db;
        if (where != null)
        {
            query = query.Where(where);
        }
        if (orderby != null)
        {
            query = orderby(query);
        }
        if (includes != null)
        {
            foreach (string inc in includes.Split(","))
            {
                query = query.Include(inc);
            }
        }
        return query.AsNoTracking().ToList();
    }

    public virtual async Task<TEntity> GetFirstValueAsync(object id = null) => await _db.FirstOrDefaultAsync();
    public virtual TEntity GetValueFirst(object id = null) => _db.FirstOrDefault();

    public virtual async Task<TEntity> FindByIdAsync(object id) => await _db.FindAsync(id);
    public virtual TEntity FindById(object id) => _db.Find(id);

    public virtual async Task Create(TEntity entity) => await _db.AddAsync(entity);
    public virtual async Task CreateRangeAsync(IEnumerable<TEntity> entity) => await _db.AddRangeAsync(entity);

    public virtual void Update(TEntity entity) => _db.Update(entity);
    public virtual void UpdateRange(IEnumerable<TEntity> entity) => _db.UpdateRange(entity);

    public virtual void Delete(TEntity entity) => _db.Remove(entity);
    public virtual void DeleteRange(IEnumerable<TEntity> entity) => _db.RemoveRange(entity);

    public virtual async Task DeleteByIdAsync(object id)
    {
        var x = await FindByIdAsync(id);
        _db.Remove(x);
    }
    public virtual void DeleteById(object id)
    {
        var x = FindById(id);
        _db.Remove(x);
    }

    public virtual async Task Commit() => await _context.SaveChangesAsync();


    public async Task<List<TEntity>> GetPaginateResultAsync(int CurrentPage, int PageSize = 1)
    {
        var Entities = await GetAllAsync();
        return Entities.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
    }

    public int GetCount() => _db.AsNoTracking().Count();

}
}
