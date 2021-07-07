using AutoMapper;
using FullStackCodeTest.BLL.DTOs;
using FullStackCodeTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackCodeTest.BLL.Mappings
{
    public class DBMappingProfile : Profile
    {
        public DBMappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
