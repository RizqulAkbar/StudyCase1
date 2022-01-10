using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudyCase1.ValidationAttributes;

namespace StudyCase1.DTO
{
    [StudentFirstlastMustBeDiff]
    public class StudentForCreateDTO /*: IValidatableObject*/
    {
        [Required(ErrorMessage = "Kolom FirstName harus diisi")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kolom lastName harus diisi")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kolom EnrollmentDate harus diisi")]
        public DateTime EnrollmentDate { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (FirstName == LastName)
        //    {
        //        yield return new ValidationResult("Firstname dan Lastname tidak boleh sama",
        //            new[] { "StudentForCreateDto" });
        //    }
        //}
    }
}
