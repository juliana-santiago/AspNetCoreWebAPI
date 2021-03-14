using AutoMapper;
using SmartSchool.API.DTO;
using SmartSchool.API.Models;

namespace SmartSchool.API.Helpers
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
