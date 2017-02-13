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

            entities = (filter != null) ? FilterEntities(entities, filter) : entities;

            return await MapToModelsList(entities);
        }

        public async Task<IList<TModel>> GetAsync<TKey>(Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool desc = false)
        {
            var entities = _uow.Entities<TEntity>();

            entities = (filter != null) ? FilterEntities(entities, filter) : entities;
            entities = (sort != null) ? SortEntities(entities, sort, desc) : entities;

            return await MapToModelsList(entities);
        }

        public async Task<IPagedList<TModel>> GetPagedAsync(int pageNumber, int pageSize, 
            Expression<Func<TModel, bool>> filter = null)
        {
            var entities = _uow.Entities<TEntity>();

            entities = (filter != null) ? FilterEntities(entities, filter) : entities;
            var models = await MapToModelsList(entities);

            return models.ToPagedList(pageNumber, pageSize);
        }

        public async Task<IPagedList<TModel>> GetPagedAsync<TKey>(int pageNumber, int pageSize,
            Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool desc = false)
        {
            var entities = _uow.Entities<TEntity>();

            entities = (filter != null) ? FilterEntities(entities, filter) : entities;
            entities = (sort != null) ? SortEntities(entities, sort, desc) : entities;

            var models = await MapToModelsList(entities);

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

        protected IQueryable<TEntity> FilterEntities(IQueryable<TEntity> entities, 
            Expression<Func<TModel, bool>> filter = null)
        {
            var mappedFilter = AutoMapper.Mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            return entities.Where(mappedFilter);
        }

        protected IQueryable<TEntity> SortEntities<TKey>(IQueryable<TEntity> entities,    
            Expression<Func<TModel, TKey>> sort = null, 
            bool desc = false)
        {
            var mappedSort = AutoMapper.Mapper.Map<Expression<Func<TEntity, TKey>>>(sort);

            return (desc) ? entities.OrderByDescending(mappedSort)
                          : entities.OrderBy(mappedSort);
        }

        protected async Task<IList<TModel>> MapToModelsList(IQueryable<TEntity> entities)
        {
            var entitiesList = await entities.ToListAsync();
            return AutoMapper.Mapper.Map<IList<TModel>>(entitiesList);
        }
    }
}
