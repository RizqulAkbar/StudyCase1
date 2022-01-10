using System;

namespace EnrollmentService.DTO
{
    public class StudentForUpdate
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
