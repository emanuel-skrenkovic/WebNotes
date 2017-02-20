using AutoMapper.QueryableExtensions;
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
            var result = await _uow.FindAsync<TEntity>(id);
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

        public async Task<IList<TModel>> GetPagedAsync(int pageNumber, int pageSize, 
            Expression<Func<TModel, bool>> filter = null)
        {
            var skippedRows = (pageNumber - 1) * pageSize;
            var entities = _uow.Entities<TEntity>();

            if (filter != null)
            {
                var mappedFilter = AutoMapper.Mapper.Map<Expression<Func<TEntity, bool>>>(filter);
                entities = entities.Where(mappedFilter);
            }

            var entitiesList = await entities.OrderBy(x => 0)
                .Skip(skippedRows)
                .Take(pageSize)
                .ToListAsync();

            return AutoMapper.Mapper.Map<IList<TModel>>(entitiesList);
        }

        public async Task<IList<TModel>> GetPagedAsync<TKey>(int pageNumber, int pageSize,
            Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TKey>> sort = null,
            bool desc = false)
        {
            var skippedRows = (pageNumber - 1) * pageSize;
            var entities = _uow.Entities<TEntity>();

            if (filter != null)
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

            var entitiesList = await entities
                .Skip(skippedRows)
                .Take(pageSize)
                .ToListAsync();

            return AutoMapper.Mapper.Map<IList<TModel>>(entitiesList);
        }

        public Task CreateAsync(TModel model)
        {
            var result = AutoMapper.Mapper.Map<TEntity>(model);

            _uow.Add(result);
            return _uow.SaveChangesAsync();
        }

        public Task UpdateAsync(TModel model)
        {
            var result = AutoMapper.Mapper.Map<TEntity>(model);

            _uow.Update(result);
            return _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            var entity = AutoMapper.Mapper.Map<TEntity>(model);

            _uow.Delete(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
