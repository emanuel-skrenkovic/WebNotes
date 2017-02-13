using AutoMapper.QueryableExtensions;
using PagedList;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            var result = await _uow.Find<TEntity>(id);
            return AutoMapper.Mapper.Map<TModel>(result);
        }
        
        public async Task<IList<TModel>> GetAsync(Expression<Func<TModel, bool>> filter = null)
        {
            var entities = _uow.Entities<TEntity>();

            if(filter != null)
            {
                var mappedFilter = AutoMapper.Mapper.Map<Expression<Func<TEntity, bool>>>(filter);
                entities = entities.Where(mappedFilter);
            }

            var entitiesList = await entities.ToListAsync();

            return AutoMapper.Mapper.Map<IList<TModel>>(entitiesList);
        }

        public async Task<IList<TModel>> GetAsync<TKey>(Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool desc = false)
        {
            var entities = _uow.Entities<TEntity>();

            if(filter != null)
            {
                var mappedFilter = AutoMapper.Mapper.Map<Expression<Func<TEntity, bool>>>(filter);
                entities = entities.Where(mappedFilter);
            }

            if(sort != null)
            {
                var mappedSort = AutoMapper.Mapper.Map<Expression<Func<TEntity, TKey>>>(sort);
                entities = (desc) ? entities.OrderByDescending(mappedSort)
                                  : entities.OrderBy(mappedSort);
            }

            var entitiesList = await entities.ToListAsync();

            return AutoMapper.Mapper.Map<IList<TModel>>(entitiesList);
        }

        public async Task<IPagedList<TModel>> GetPagedAsync(int pageNumber, int pageSize, 
            Expression<Func<TModel, bool>> filter = null)
        {
            var models = await GetAsync(filter);

            return models.ToPagedList(pageNumber, pageSize);
        }

        public async Task<IPagedList<TModel>> GetPagedAsync<TKey>(int pageNumber, int pageSize,
            Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool desc = false)
        {
            var models = await GetAsync(filter, sort, desc);

            return models.ToPagedList(pageNumber, pageSize);
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

            _uow.Update(result);
            await _uow.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await GetByIdAsync(id);
            var entity = AutoMapper.Mapper.Map<TEntity>(model);

            _uow.Delete(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
