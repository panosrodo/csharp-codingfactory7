using AutoMapper;
using WebStarter7DBApp.DTO;
using WebStarter7DBApp.Models;

namespace WebStarter7DBApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<StudentInsertDTO, Student>().ReverseMap();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
            CreateMap<StudentReadOnlyDTO, Student>().ReverseMap();

        }
    }
}