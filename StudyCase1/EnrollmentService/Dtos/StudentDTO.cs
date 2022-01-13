using System;

namespace EnrollmentService.Dtos
{
    public class StudentDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
