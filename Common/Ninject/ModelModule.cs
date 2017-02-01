using Model;
using Model.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INote>().To<Note>();
        }
    }
}
