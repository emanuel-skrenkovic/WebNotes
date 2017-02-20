using DAL;
using DAL.Entities;
using Model.Common;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : 
        GenericRepository<CategoryEntity, ICategory>, 
        ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
