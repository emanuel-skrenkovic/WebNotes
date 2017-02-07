using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<TModel> GetByIdAsync(int id);
        Task<IList<TModel>> GetAllAsync();
        Task Create(TModel entity);
        Task Update(TModel entity);
        Task Delete(int id);
    }
}
