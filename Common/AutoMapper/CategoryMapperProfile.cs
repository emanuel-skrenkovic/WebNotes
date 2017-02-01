using AutoMapper;
using DAL.Entities;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AutoMapper
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<ICategory, CategoryEntity>();
            CreateMap<CategoryEntity, ICategory>();
        }
    }
}
