using Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IRepository<TModel> : IGenericRepository<TModel, TModel> where TModel : class
    {
    }
}
