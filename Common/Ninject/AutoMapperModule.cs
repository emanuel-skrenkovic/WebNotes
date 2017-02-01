using AutoMapper;
using AutoMapper.Configuration;
using Common.AutoMapper;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Ninject
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
