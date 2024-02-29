using AutoMapper;
using SchoolAPI.Shared.Dto.ModelsDto;
using SchoolAPI.Shared.Models;

namespace SchoolAPI.Business.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<School, SchoolCreateDto>().ReverseMap();
            CreateMap<School, SchoolEditDto>().ReverseMap();
            CreateMap<Course, ProfessorCreatedDto>().ReverseMap();
            CreateMap<Course, ProfessorEditDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseEditDto>().ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudenEditDto>().ReverseMap();
        }
    }
}
