using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnrollmentService.Data;
using EnrollmentService.Models;

namespace EnrollmentService.DAL
{
    public class CourseDal : ICourse
    {

        private ApplicationDbContext _db;

        public CourseDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            var result = await GetById(id);
            if (result == null) throw new Exception("Data tidak ditemukan !");
            try
            {
                _db.Courses.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var result = await (from c in _db.Courses
                                orderby c.CourseID ascending
                                select c).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Course> GetById(string id)
        {
            //var result = await _db.Courses.Where(c => c.CourseID == Convert.ToInt32(id)).SingleOrDefaultAsync<Course>();
            var result = await (from c in _db.Courses 
                                where c.CourseID == Convert.ToInt32(id) 
                                select c).SingleOrDefaultAsync<Course>();
            if (result != null)
                return result;
            else
                throw new Exception($"data {id} tidak ditemukan");
        }

        public async Task<IEnumerable<Course>> GetWithStudent()
        {
            var results = await _db.Courses.Include("Enrollments.Student")
                .AsNoTracking().ToListAsync();

            return results;
        }

        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            var result = await (from c in _db.Courses
                                where c.Title.ToLower().Contains(title.ToLower())
                                orderby c.CourseID ascending
                                select c).AsNoTracking().ToListAsync();
            if (result != null)
                return result;
            else
                throw new Exception("Data tidak Ditemukan");
        }


        public async Task<Course> Insert(Course obj)
        {
            try
            {
                _db.Courses.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error : {dbEx.Message}");
            }
        }

        public async Task<Course> Update(string id, Course obj)
        {
            try
            {
                var result = await GetById(id);
                if (result == null) throw new Exception($"data course id {id} tidak ditemukan");
                result.Title = obj.Title;
                result.Credits = obj.Credits;
                await _db.SaveChangesAsync();
                //obj.CourseID = Convert.ToInt32(id);
                return result;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }
    }
}
