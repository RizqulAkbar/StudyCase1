using EnrollmentService.Models;

namespace EnrollmentService.Dtos
{
    public class CourseStudentDto
    {
        public string Title { get; set; }
        public Student Student { get; set; }
    }
}
