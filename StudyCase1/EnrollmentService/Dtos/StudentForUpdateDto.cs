using System;

namespace EnrollmentService.Dtos
{
    public class StudentForUpdateDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
