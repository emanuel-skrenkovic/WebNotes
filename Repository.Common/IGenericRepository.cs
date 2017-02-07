using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IGenericRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        Task<TModel> GetByIdAsync(int id);
        Task<IList<TModel>> GetAllAsync();
        Task Create(TModel model);
        Task Update(TModel model);
        Task Delete(int id);
    }
}
