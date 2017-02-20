using Model;
using Model.Common;
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
        private INoteRepository _noteRepo;
        private ICategoryRepository _categoryRepo;

        public NoteService(INoteRepository noteRepo, 
            ICategoryRepository categoryRepo)
        {
            _noteRepo = noteRepo;
            _categoryRepo = categoryRepo;
        }

        public Task<INote> GetNoteByIdAsync(int id)
        {
            return _noteRepo.GetByIdAsync(id);
        }

        public Task<ICategory> GetCategoryByIdAsync(int id)
        {
            return _categoryRepo.GetByIdAsync(id);
        }

        public Task<IList<INote>> GetNotesAsync()
        {
            return _noteRepo.GetAsync();
        }

        public Task<IList<ICategory>> GetCategoriesAsync()
        {
            return _categoryRepo.GetAsync();
        }

        public Task<IList<INote>> GetPagedNotesAsync(int pageNumber, int pageSize)
        {
            return _noteRepo.GetPagedAsync(pageNumber, pageSize);
        }

        public Task<IList<INote>> GetPagedCategoriesAsync(int pageNumber, int pageSize)
        {
            return _noteRepo.GetPagedAsync(pageNumber, pageSize);
        }

        public Task CreateNoteAsync(INote model)
        {
            return _noteRepo.CreateAsync(model);
        }

        public Task CreateCategoryAsync(ICategory model)
        {
            return _categoryRepo.CreateAsync(model);
        }

        public Task UpdateNoteAsync(INote model)
        {
            return _noteRepo.UpdateAsync(model);
        }

        public Task UpdateCategoryAsync(ICategory model)
        {
            return _categoryRepo.UpdateAsync(model);
        }

        public Task DeleteNoteAsync(int id)
        {
            return _noteRepo.DeleteAsync(id);
        }

        public Task DeleteCategoryAsync(int id)
        {
            return _categoryRepo.DeleteAsync(id);
        }
    }
}
