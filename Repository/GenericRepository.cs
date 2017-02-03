using DAL;
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
        private readonly INotesContext _context;
        private DbSet<TEntity> _set;

        public GenericRepository(INotesContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            var result = await _set.FindAsync(id);
            return AutoMapper.Mapper.Map<TModel>(result);
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            var result = await _set.ToListAsync();
            return AutoMapper.Mapper.Map<List<TModel>>(result);
        }

        public void Create(TModel model)
        {
            var result = AutoMapper.Mapper.Map<TEntity>(model);
            _context.Set<TEntity>().Add(result);
        }

        public void Update(TModel model)
        {
            var result = AutoMapper.Mapper.Map<TEntity>(model);
            _context.Entry<TEntity>(result).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var result = await _set.FindAsync(id);
            _set.Remove(result);
        }

    }
}
