using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    public class StudentForCreateDto
    {
        [Required(ErrorMessage = "FirstName must be inserted")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName must be inserted")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EnrollmentDate must be inserted")]
        public DateTime EnrollmentDate { get; set; }
    }
}
