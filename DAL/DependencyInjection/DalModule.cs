using DAL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DependencyInjection
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INotesContext>().To<NotesContext>();
        }
    }
}
