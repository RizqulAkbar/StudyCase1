using AutoMapper;
using StudyCase1.DTO;
using StudyCase1.Models;

namespace StudyCase1.Profiles
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