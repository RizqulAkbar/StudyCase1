using AutoMapper;
using EnrollmentService.Dtos;
using EnrollmentService.Models;

namespace EnrollmentService.Profiles
{
    public class EnrollmentProfiles : Profile
    {
        public EnrollmentProfiles()
        {
            CreateMap<Enrollment, EnrollmentReadDto>();
            CreateMap<EnrollmentCreateDto, Enrollment>();
            CreateMap<EnrollmentReadDto, EnrollmentPublishedDto>();
        }
    }
}
