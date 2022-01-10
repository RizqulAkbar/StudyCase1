using System.Collections.Generic;
using System.Threading.Tasks;
using StudyCase1.Models;

namespace StudyCase1.Data
{
    public interface IStudent : ICrud<Student>
    {
        Task<IEnumerable<Student>> GetWithCourse();
    }
}
