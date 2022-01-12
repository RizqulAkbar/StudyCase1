using EnrollmentService.Models;

namespace EnrollmentService.Dtos
{
    public class EnrollmentReadDto
    {
        public int EnrollmentId { get; set; }
        public string CourseId { get; set; }
        public string StudentId { get; set; }
        public Grade? Grade { get; set; }
        // public Course Courses { get; set; }
        // public Student Students { get; set; }
    }
}
