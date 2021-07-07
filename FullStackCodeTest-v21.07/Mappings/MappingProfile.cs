using AutoMapper;
using FullStackCodeTest.BLL.DTOs;
using FullStackCodeTest_v21_07.Models;

namespace FullStackCodeTest_v21_07.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserVM, UserDTO>().ReverseMap();
        }
    }
}
