using Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface INoteService
    {
        Task<INote> GetNoteByIdAsync(int id);
        Task<ICategory> GetCategoryByIdAsync(int id);

        Task<IEnumerable<INote>> GetNotesAsync();
        Task<IEnumerable<ICategory>> GetCategoriesAsync();

        Task<IPagedList<INote>> GetPagedNotesAsync(int pageNumber, int pageSize);
        Task<IPagedList<INote>> GetPagedCategoriesAsync(int pageNumber, int pageSize);

        Task CreateNote(INote model);
        Task CreateCategory(ICategory model);

        Task UpdateNote(INote model);
        Task UpdateCategory(ICategory model);

        Task DeleteNote(int id);
        Task DeleteCategory(int id);
    }
}
