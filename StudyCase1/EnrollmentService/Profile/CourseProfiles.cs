using AutoMapper;
using EnrollmentService.DTO;
using EnrollmentService.Models;

namespace EnrollmentService.Profiles
{
    public class CourseProfiles : Profile

    {
            public CourseProfiles()
            {
                CreateMap<Course, CourseDTO>()
                    .ForMember(dest => dest.TotalHours,
                    opt => opt.MapFrom(src => $"{src.Credits * 1.5}"));

                CreateMap<CourseForCreateDTO, Course>();

            }
    }
}
