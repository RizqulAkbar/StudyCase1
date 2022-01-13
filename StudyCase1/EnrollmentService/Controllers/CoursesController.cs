using Microsoft.AspNetCore.Mvc;
using EnrollmentService.Models;
using System;
using System.Collections.Generic;
using EnrollmentService.Data;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using EnrollmentService.Dtos;

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
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var courses = await _course.GetAll();

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDto>(result));
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
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto courseforcreatedto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseforcreatedto);
                var result = await _course.Insert(course);
                var courseresult = _mapper.Map<CourseDto>(result);
                return Ok(courseresult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForCreateDto courseforcreatedto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseforcreatedto);
                var result = await _course.Update(id.ToString(), course);
                var studentresult = _mapper.Map<CourseDto>(result);
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
