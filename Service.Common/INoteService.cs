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

        Task CreateNoteAsync(INote model);
        Task CreateCategoryAsync(ICategory model);

        Task UpdateNoteAsync(INote model);
        Task UpdateCategoryAsync(ICategory model);

        Task DeleteNoteAsync(int id);
        Task DeleteCategoryAsync(int id);
    }
}
