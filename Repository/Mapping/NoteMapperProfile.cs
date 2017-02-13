using AutoMapper;
using DAL.Entities;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapping
{
    public class NoteMapperProfile : Profile
    {
        public NoteMapperProfile()
        {
            CreateMap<INote, NoteEntity>().ReverseMap();
        }
    }
}
