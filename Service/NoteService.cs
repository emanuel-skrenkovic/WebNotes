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

        public async Task CreateNoteAsync(INote model)
        {
            await _noteRepo.CreateAsync(model);
        }

        public async Task CreateCategoryAsync(ICategory model)
        {
            await _categoryRepo.CreateAsync(model);
        }

        public async Task UpdateNoteAsync(INote model)
        {
            await _noteRepo.UpdateAsync(model);
        }

        public async Task UpdateCategoryAsync(ICategory model)
        {
            await _categoryRepo.UpdateAsync(model);
        }

        public async Task DeleteNoteAsync(int id)
        {
            await _noteRepo.DeleteAsync(id);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepo.DeleteAsync(id);
        }
    }
}
