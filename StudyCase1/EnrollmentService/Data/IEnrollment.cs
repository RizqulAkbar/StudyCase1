using EnrollmentService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnrollmentService.Data
{
    public interface IEnrollment
    {
        bool SaveChanges();
        Task<IEnumerable<Enrollment>> GetAllEnrollments();
        //Enrollment GetEnrollmentById(int id);
        Task<Enrollment> GetEnrollmentById(string id);
        Task<Enrollment> CreateEnrollment(Enrollment enroll);
        Task DeleteEnrollment(string id);
    }
}
