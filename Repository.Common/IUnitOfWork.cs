using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class;
        IQueryable<TEntity> Entities<TEntity>() where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        Task SaveChangesAsync();
    }
}
