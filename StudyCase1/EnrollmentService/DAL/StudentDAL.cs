using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyCase1.Data;
using StudyCase1.Models;

namespace StudyCase1.DAL
{
    public class StudentDAL : IStudent
    {
        private ApplicationDbContext _db;

        public StudentDAL(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Delete(string id)
        {
            var result = await GetById(id);
            if (result == null) throw new Exception("Data tidak ditemukan !");
            try
            {
                _db.Students.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var result = await (from s in _db.Students 
                                orderby s.ID ascending
                                select s).ToListAsync();
            //_db.Students.OrderBy(s => s.FirstName).ToListAsync();
            return result;
            
        }

        public async Task<Student> GetById(string id)
        {
            var result = await _db.Students.Where(s => s.ID == Convert.ToInt32(id)).SingleOrDefaultAsync<Student>();
            if (result != null)
                return result;
            else
                throw new Exception("Data tidak Ditemukan");
            
        }

        public async Task<IEnumerable<Student>> GetWithCourse()
        {
            var result = await _db.Students.Include("Enrollments.Course")
                .AsNoTracking().ToListAsync();
            //var result = await (from s in _db.Students
            //              join e in _db.Enrollments on s.ID equals e.StudentID
            //              select new Student()
            //              {
            //                  ID = s.ID,
            //                  FirstName = s.FirstName,
            //                  LastName = s.LastName,
            //                  Course = e.Course
            //              }).ToListAsync();
            return result;
        }

        public async Task<Student> Insert(Student obj)
        {
            try
            {
                _db.Students.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception($"Error : {dbEx.Message}");
            }
        }

        public async Task<Student> Update(string id, Student obj)
        {
            try
            {
                var result = await GetById(id);
                result.FirstName = obj.FirstName;
                result.LastName = obj.LastName;
                result.EnrollmentDate = obj.EnrollmentDate;
                await _db.SaveChangesAsync();
                obj.ID = Convert.ToInt32(id);
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }


    }
}
