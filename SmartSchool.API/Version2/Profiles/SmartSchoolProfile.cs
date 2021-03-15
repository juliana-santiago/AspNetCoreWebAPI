using AutoMapper;
using SmartSchool.API.Version1.DTO;
using SmartSchool.API.Models;
using SmartSchool.API.Helpers;

namespace SmartSchool.API.Version2.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge())
                );

            CreateMap<StudentDTO, Student>();
            CreateMap<Student, RegisterStudentDTO>().ReverseMap();

            CreateMap<Teacher, TeacherDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")
                );

            CreateMap<TeacherDTO, Teacher>();
            CreateMap<Teacher, RegisterTeacherDTO>().ReverseMap();
        }
    }
}
