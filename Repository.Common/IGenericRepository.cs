using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IGenericRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        Task<TModel> GetByIdAsync(int id);

        Task<IList<TModel>> GetAsync(Expression<Func<TModel, bool>> filter = null);
        Task<IList<TModel>> GetAsync<TKey>(Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool desc = false);

        Task<IPagedList<TModel>> GetPagedAsync(int pageNumber, int pageSize,
            Expression<Func<TModel, bool>> filter = null);
        Task<IPagedList<TModel>> GetPagedAsync<TKey>(int pageNumber, int pageSize,
            Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool desc = false);

        Task CreateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(int id);
    }
}
