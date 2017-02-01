using Ninject.Modules;
using Repository.Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Common
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<INote>)).To(typeof(NoteRepository));
            Bind(typeof(IRepository<ICategory>)).To(typeof(CategoryRepository));
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
