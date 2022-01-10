using AutoMapper;
using EnrollmentService.DTO;
using EnrollmentService.Models;

namespace EnrollmentService.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<StudentForCreateDTO, Student>();
        }
    }
}