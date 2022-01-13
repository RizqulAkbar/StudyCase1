using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EnrollmentService.Data;
using EnrollmentService.Models;

namespace EnrollmentService.Dtos
{
    public class StudentCourseDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Course Course { get; set; }
    }
}
