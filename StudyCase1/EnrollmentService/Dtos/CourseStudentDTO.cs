using EnrollmentService.Models;

namespace EnrollmentService.DTO
{
    public class CourseStudentDTO
    {
        public string Title { get; set; }
        public Student Student { get; set; }
    }
}
