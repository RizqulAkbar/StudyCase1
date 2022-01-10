namespace PaymentService.Dtos
{
    public class PaymentReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string CommandLine { get; set; }
        public int EnrollmentId { get; set; }
    }
}
