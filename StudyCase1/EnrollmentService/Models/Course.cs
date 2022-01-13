using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EnrollmentService.Models
{
    public class Course
    {
        [Required]
        public int CourseID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
