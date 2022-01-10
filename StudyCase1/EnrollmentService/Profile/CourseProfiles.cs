using AutoMapper;
using StudyCase1.DTO;
using StudyCase1.Models;

namespace StudyCase1.Profiles
{
    public class CourseProfiles
    {
        public class CourseProfile : Profile
        {
            public CourseProfile()
            {
                CreateMap<Course, CourseDTO>()
                    .ForMember(dest => dest.TotalHours,
                    opt => opt.MapFrom(src => $"{src.Credits * 1.5}"));

                CreateMap<CourseForCreateDTO, Course>();



            }
        }
    }
}
