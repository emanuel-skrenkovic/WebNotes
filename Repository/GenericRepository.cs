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
        
        public async Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel, bool>> filter = null)
        {
            var entities = await _uow.List<TEntity>();

            if(filter != null)
            {
                entities = Filter(entities, filter);
            }

            var result = AutoMapper.Mapper.Map<IEnumerable<TModel>>(entities);

            return result;
        }

        public async Task<IEnumerable<TModel>> GetAsync<TKey>(Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool descending = false)
        {
            var entities = await _uow.List<TEntity>();

            if(filter != null)
            {
                entities = Filter(entities, filter);
            }

            if(sort != null)
            {
                entities = Sort(entities, sort, descending);
            }

            var result = AutoMapper.Mapper.Map<IEnumerable<TModel>>(entities);

            return result;
        }

        public async Task<IPagedList<TModel>> GetPagedAsync(int pageNumber, int pageSize, 
            Expression<Func<TModel, bool>> filter = null)
        {
            var entities = await _uow.List<TEntity>();

            if(filter != null)
            {
                entities = Filter(entities, filter);
            }

            var models = AutoMapper.Mapper.Map<IEnumerable<TModel>>(entities);
            var result = models.ToPagedList(pageNumber, pageSize);

            return result;
        }

        public async Task<IPagedList<TModel>> GetPagedAsync<TKey>(int pageNumber, int pageSize,
            Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool descending = false)
        {
            var entities = await _uow.List<TEntity>();

            if(filter != null)
            {
                entities = Filter(entities, filter);
            }

            if(sort != null)
            {
                entities = Sort(entities, sort, descending);
            }

            var models = AutoMapper.Mapper.Map<IEnumerable<TModel>>(entities);
            var result = models.ToPagedList(pageNumber, pageSize);
                
            return result;
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

        protected IEnumerable<TEntity> Filter(IEnumerable<TEntity> entities, 
            Expression<Func<TModel, bool>> filter = null)
        {
            var mappedFilter = AutoMapper.Mapper.Map<Expression<Func<TEntity, bool>>>(filter);
            var mappedEntities = entities.AsQueryable().Where(mappedFilter);

            return mappedEntities.AsEnumerable();
        }

        protected IEnumerable<TEntity> Sort<TKey>(IEnumerable<TEntity> entities, 
            Expression<Func<TModel, TKey>> sort = null, 
            bool descending = false)
        {
            var mappedSort = AutoMapper.Mapper.Map<Expression<Func<TEntity, TKey>>>(sort);

            if (descending)
            {
                var mappedEntities = entities.AsQueryable().OrderByDescending(mappedSort);
                return mappedEntities.AsEnumerable();
            }
            else
            {
                var mappedEntities = entities.AsQueryable().OrderBy(mappedSort);
                return mappedEntities.AsEnumerable();
            }
        }

    }
}
