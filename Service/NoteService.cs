using Model;
using Model.Common;
using PagedList;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NoteService : INoteService
    {
        private IRepository<INote> _noteRepo;
        private IRepository<ICategory> _categoryRepo;

        public NoteService(IRepository<INote> noteRepo, 
            IRepository<ICategory> categoryRepo)
        {
            _noteRepo = noteRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<INote> GetNoteByIdAsync(int id)
        {
            return await _noteRepo.GetByIdAsync(id);
        }

        public async Task<ICategory> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<INote>> GetNotesAsync()
        {
            return await _noteRepo.GetAsync();
        }

        public async Task<IEnumerable<ICategory>> GetCategoriesAsync()
        {
            return await _categoryRepo.GetAsync();
        }

        public async Task<IPagedList<INote>> GetPagedNotesAsync(int pageNumber, int pageSize)
        {
            return await _noteRepo.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task<IPagedList<INote>> GetPagedCategoriesAsync(int pageNumber, int pageSize)
        {
            return await _noteRepo.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task CreateNote(INote model)
        {
            await _noteRepo.Create(model);
        }

        public async Task CreateCategory(ICategory model)
        {
            await _categoryRepo.Create(model);
        }

        public async Task UpdateNote(INote model)
        {
            await _noteRepo.Update(model);
        }

        public async Task UpdateCategory(ICategory model)
        {
            await _categoryRepo.Update(model);
        }

        public async Task DeleteNote(int id)
        {
            await _noteRepo.Delete(id);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepo.Delete(id);
        }
    }
}
