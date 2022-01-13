using System;
using System.Linq;
using EnrollmentService.Models;

namespace EnrollmentService.Data
{
    public static class DbInitializer
    {
        public static void Initializer(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstName = "Clark", LastName = "Kent", EnrollmentDate = DateTime.Parse("2021-12-12")},
                new Student{FirstName = "Bruce", LastName = "Wayne", EnrollmentDate = DateTime.Parse("2021-03-25")},
                new Student{FirstName = "Diana", LastName = "Prince", EnrollmentDate = DateTime.Parse("2021-02-20")},
                new Student{FirstName = "Tony", LastName = "Stark", EnrollmentDate = DateTime.Parse("2021-05-11")},
                new Student{FirstName = "Steve", LastName = "Rogers", EnrollmentDate = DateTime.Parse("2021-03-09")},
            };

            foreach(var s in students)
            {
                context.Students.Add(s);
            }

            var courses = new Course[]
            {
                new Course{Title ="Fly",Credits =6},
                new Course{Title ="Martial Art",Credits=6},
                new Course{Title = "Leadership",Credits =4},
                new Course{Title = "Engineering",Credits = 8},
                new Course{Title = "History",Credits =2 },
                new Course{Title = "Magic",Credits = 8},
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1,Grade="A"},
                new Enrollment{StudentID=1,CourseID=2,Grade="B"},
                new Enrollment{StudentID=1,CourseID=3,Grade="C"},
                new Enrollment{StudentID=2,CourseID=1,Grade="C"},
                new Enrollment{StudentID=2,CourseID=2,Grade="C"},
                new Enrollment{StudentID=2,CourseID=3,Grade="C"},
                new Enrollment{StudentID=3,CourseID=1,Grade="A"},
                new Enrollment{StudentID=3,CourseID=2,Grade="B"},
                new Enrollment{StudentID=3,CourseID=3,Grade="C"},
            };

            foreach (var e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();

        }
    }
}
