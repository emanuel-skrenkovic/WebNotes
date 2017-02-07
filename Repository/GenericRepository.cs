using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class GenericRepository<TEntity, TModel> 
        : IGenericRepository<TEntity, TModel>
        where TModel : class
        where TEntity : class
    {
        protected IUnitOfWork _uow;

        public GenericRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            var result = await _uow.GetByIdAsync<TEntity>(id);
            return AutoMapper.Mapper.Map<TModel>(result);
        }

        public async Task<IList<TModel>> GetAllAsync()
        {
            var result = await _uow.GetAllAsync<TEntity>();
            return AutoMapper.Mapper.Map<IList<TModel>>(result);
        }

        public async Task Create(TModel model)
        {
            var result = AutoMapper.Mapper.Map<TEntity>(model);
            _uow.Add(result);
            await _uow.SaveChangesAsync();
        }

        public async Task Update(TModel model)
        {
            var result = AutoMapper.Mapper.Map<TEntity>(model);
            _uow.Update<TEntity>(result);
            await _uow.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await GetByIdAsync(id);
            var entity = AutoMapper.Mapper.Map<TEntity>(model);

            _uow.Delete<TEntity>(entity);
            await _uow.SaveChangesAsync();
        }

    }
}
