using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<IList<TEntity>> GetAllAsync<TEntity>() where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        Task SaveChangesAsync();
    }
}
