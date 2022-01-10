using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EnrollmentService.Data;
using EnrollmentService.Models;

namespace EnrollmentService.DTO
{
    public class StudentCourseDTO : IValidatableObject
    {
        [Required]
        //[MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        //[MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public Course Course { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName == LastName)
            {
                yield return new ValidationResult("Last Name tidak boleh sama seperti First name",
                    new[] { "StudentForCreateDTO" });
            }
        }
    }
}
