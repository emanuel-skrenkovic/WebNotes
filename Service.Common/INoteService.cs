using Model.Common;
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

        Task<IList<INote>> GetNotesAsync();
        Task<IList<ICategory>> GetCategoriesAsync();

        Task<IList<INote>> GetPagedNotesAsync(int pageNumber, int pageSize);
        Task<IList<INote>> GetPagedCategoriesAsync(int pageNumber, int pageSize);

        Task CreateNoteAsync(INote model);
        Task CreateCategoryAsync(ICategory model);

        Task UpdateNoteAsync(INote model);
        Task UpdateCategoryAsync(ICategory model);

        Task DeleteNoteAsync(int id);
        Task DeleteCategoryAsync(int id);
    }
}
