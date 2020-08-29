using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = null);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = null);
        Task<TEntity> GetFirstValueAsync(object id = null);
        TEntity GetValueFirst(object id = null);
        Task<TEntity> FindByIdAsync(object id);
        TEntity FindById(object id);

        Task Create(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entity);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entity);
        Task DeleteByIdAsync(object id);
        void DeleteById(object id);

        Task Commit();
        int GetCount();

        Task<List<TEntity>> GetPaginateResultAsync(int CurrentPage, int PageSize = 1);
    }
}
