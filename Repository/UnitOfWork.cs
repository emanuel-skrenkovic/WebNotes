﻿using DAL;
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

        public UnitOfWork(INotesContext context, 
            IRepository<INote> noteRepository)
        {
            _context = context;
            _noteRepository = noteRepository;
        }

        public IRepository<INote> NoteRepository
        {
            get
            {
                return _noteRepository;
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