using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<INote> NoteRepository { get; }
        IRepository<ICategory> CategoryRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
