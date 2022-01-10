using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudyCase1.DTO
{
    public class CourseForCreateDTO  /*: IValidatableObject*/
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!Title.StartsWith("Training") || Title.Length <= 50)
        //    {
        //        yield return new ValidationResult("Title must start with training and max 50 character",
        //           new[] { "Title" });
        //    }
            
        //    if(Credits >= 10)
        //    {
        //        yield return new ValidationResult("Credit max 10 character",
        //           new[] { "Credits" });
        //    }
               
        //}
    }
}
