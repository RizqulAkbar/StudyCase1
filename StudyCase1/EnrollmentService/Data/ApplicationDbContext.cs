using Microsoft.EntityFrameworkCore;
using StudyCase1.Models;

namespace StudyCase1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public object Student { get; internal set; }
    }
}
