using AutoMapper;
using Ninject;
using Ninject.Modules;
using Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Ninject
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(t => Kernel.Get(t));

                cfg.AddProfile<NoteMapperProfile>();
                cfg.AddProfile<CategoryMapperProfile>();
            });
        }
    }
}
