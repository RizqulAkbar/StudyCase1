using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnrollmentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using EnrollmentService.Data;
using System.Threading.Tasks;
using AutoMapper;
using EnrollmentService.DTO;
using Microsoft.AspNetCore.Authorization;

namespace EnrollmentService.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course ?? throw new ArgumentNullException(nameof(course));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        //public async Task<IEnumerable<Course>> Get()
        //{
        //    var results = await _course.GetAll();
        //    return results;
        //}

        public async Task<ActionResult<IEnumerable<CourseDTO>>> Get()
        {
            var courses = await _course.GetAll();

            return Ok(_mapper.Map<IEnumerable<CourseDTO>>(courses));
        }



        [HttpGet("{id}")]
        //public async Task<Course> Get(int id)
        //{
        //    var result = await _course.GetById(id.ToString());
        //    return result;
        //}

        public async Task<ActionResult<Course>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDTO>(result));
        }



        [HttpGet("bytitle")]
        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            var results = await _course.GetByTitle(title.ToString());
            return results;
        }

        [HttpGet("withstudents")]
        public async Task<IEnumerable<Course>> GetWithStudent()
        {
            var results = await _course.GetWithStudent();
            return results;
        }

        [HttpPost]
        //public async Task<IActionResult> Post([FromBody] Course course)
        //{
        //    try
        //    {
        //        var result = await _course.Insert(course);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        public async Task<ActionResult<CourseDTO>> Post([FromBody] CourseForCreateDTO courseforcreatedto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseforcreatedto);
                var result = await _course.Insert(course);
                var courseresult = _mapper.Map<CourseDTO>(result);
                return Ok(courseresult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDTO>> Put(int id, [FromBody] CourseForCreateDTO courseforcreatedto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseforcreatedto);
                var result = await _course.Update(id.ToString(), course);
                var studentresult = _mapper.Map<CourseDTO>(result);
                return Ok(studentresult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"Data course {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
