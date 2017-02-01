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
            var test = await _set.FindAsync(id);
            return AutoMapper.Mapper.Map<TModel>(test);
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            var temp = await _set.ToListAsync();
            return AutoMapper.Mapper.Map<List<TModel>>(temp);
        }

        public void Update(TModel entity)
        {
            var temp = AutoMapper.Mapper.Map<TEntity>(entity);
            _context.Entry<TEntity>(temp).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await _set.FindAsync(id);
            _set.Remove(entity);
        }

    }
}
