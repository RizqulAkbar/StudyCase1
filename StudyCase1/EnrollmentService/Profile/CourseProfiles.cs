using AutoMapper;
using EnrollmentService.Dtos;
using EnrollmentService.Models;

namespace EnrollmentService.Profiles
{
    public class CourseProfiles : Profile

    {
            public CourseProfiles()
            {
                CreateMap<Course, CourseDto>()
                    .ForMember(dest => dest.TotalHours,
                    opt => opt.MapFrom(src => $"{src.Credits * 1.5}"));

                CreateMap<CourseForCreateDto, Course>();

            }
    }
}
