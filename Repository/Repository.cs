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
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly INotesContext _context;
        private DbSet<T> _set;

        public Repository(INotesContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var test = await _set.FindAsync(id);
            return AutoMapper.Mapper.Map<T>(test);
        }

        public async Task<List<T>> GetAllAsync()
        {
            var temp = await _set.ToListAsync();
            return AutoMapper.Mapper.Map<List<T>>(temp);
        }

        public void Update(T entity)
        {
            var temp = AutoMapper.Mapper.Map<T>(entity);
            _context.Entry<T>(temp).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await _set.FindAsync(id);
            _set.Remove(entity);
        }
    }
}
