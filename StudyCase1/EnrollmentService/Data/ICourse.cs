using System.Threading.Tasks;
using System.Collections.Generic;
using EnrollmentService.Models;
using EnrollmentService.DTO;

namespace EnrollmentService.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);

        Task<IEnumerable<Course>> GetWithStudent();
        //Task<IEnumerable<CourseStudent>> GetWithStudent();
    }
}
