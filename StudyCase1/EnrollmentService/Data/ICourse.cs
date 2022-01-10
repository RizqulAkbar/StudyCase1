using System.Threading.Tasks;
using System.Collections.Generic;
using StudyCase1.Models;
using StudyCase1.DTO;

namespace StudyCase1.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);

        Task<IEnumerable<Course>> GetWithStudent();
        //Task<IEnumerable<CourseStudent>> GetWithStudent();
    }
}
