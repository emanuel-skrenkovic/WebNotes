using Ninject.Modules;
using Repository.Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(NoteRepository));
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
