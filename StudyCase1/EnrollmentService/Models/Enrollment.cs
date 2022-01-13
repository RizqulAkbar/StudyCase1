﻿using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int CourseID {get; set;}
        public int StudentID { get; set;}
        public string Grade { get; set;}


        public Course Course { get; set;}
        public Student Student { get; set;}
    }
}
