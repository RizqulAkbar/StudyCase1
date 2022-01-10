using System.ComponentModel.DataAnnotations;

namespace PaymentService.Dtos
{
    public class PaymentCreateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}
