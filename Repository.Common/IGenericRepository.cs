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
        Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel, bool>> filter = null);
        Task<IPagedList<TModel>> GetPagedResult(int pageNumber, int pageSize);
        Task Create(TModel model);
        Task Update(TModel model);
        Task Delete(int id);
    }
}
