using System.ComponentModel.DataAnnotations;
using StudyCase1.DTO;

namespace StudyCase1.ValidationAttributes
{
    public class StudentFirstlastMustBeDiffAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var student = (StudentForCreateDTO)validationContext.ObjectInstance;
            if(student.FirstName == student.LastName)
            {
                return new ValidationResult("FirstName dan LastName tidak boelh sama",
                    new[] { nameof(StudentForCreateDTO) });
            }

            return ValidationResult.Success;
        }
            
    }
}
