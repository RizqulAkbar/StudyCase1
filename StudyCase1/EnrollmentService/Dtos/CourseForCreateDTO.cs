using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    public class CourseForCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }
    }
}
