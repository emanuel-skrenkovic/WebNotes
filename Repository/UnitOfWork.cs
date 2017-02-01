using DAL;
using DAL.Entities;
using Model;
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
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false; 

        private INotesContext _context;
        private IRepository<INote> _noteRepository;
        private IRepository<ICategory> _categoryRepository;

        public UnitOfWork(INotesContext context, 
            IRepository<INote> noteRepository,
            IRepository<ICategory> categoryRepository)
        {
            _context = context;
            _noteRepository = noteRepository;
            _categoryRepository = categoryRepository;
        }

        public IRepository<INote> NoteRepository
        {
            get
            {
                return _noteRepository;
            }
        }

        public IRepository<ICategory> CategoryRepository
        {
            get
            {
                return _categoryRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

    }
}
