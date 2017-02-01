using DAL;
using Model.Common;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> /*: IRepository<T>*/ where T : class
    {
        private readonly INotesContext _context;
        private DbSet<T> _set;

        public Repository(INotesContext context)
        {
            _context = context;

            _set = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }
        
        public async Task<List<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }    
        
        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await _set.FindAsync(id);
            _set.Remove(entity);
        } 
    }
}
