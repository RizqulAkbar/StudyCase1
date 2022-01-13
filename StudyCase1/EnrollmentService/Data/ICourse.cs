using System.Threading.Tasks;
using System.Collections.Generic;
using EnrollmentService.Models;

namespace EnrollmentService.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);

        Task<IEnumerable<Course>> GetWithStudent();
    }
}
