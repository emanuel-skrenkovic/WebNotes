using DAL.Entities;
using Model;
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
        Task<INote> GetByIdAsync(int id);
        Task<List<INote>> GetAllAsync();
        void Update(INote entity);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
