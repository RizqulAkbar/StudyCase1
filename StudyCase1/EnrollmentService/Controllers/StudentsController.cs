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
    public class StudentsController : ControllerBase
    {
        private IStudent _student;
        private IMapper _mapper;

        public StudentsController(IStudent student, IMapper mapper)
        {
            _student = student ?? throw new ArgumentNullException(nameof(student));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Get()
        {
            var students = await _student.GetAll();

            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return Ok(dtos);
        }

        private ActionResult<IEnumerable<StudentDto>> OK(IEnumerable<StudentDto> dtos)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var result = await _student.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<StudentDto>(result));
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post([FromBody] StudentForCreateDto studentforcreatedto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentforcreatedto);
                var result = await _student.Insert(student);
                var studentResult = _mapper.Map<StudentDto>(result);
                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Put(int id,[FromBody] StudentForCreateDto studentfordto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentfordto);
                var result = await _student.Update(id.ToString(), student);
                var studentresult = _mapper.Map<StudentDto>(result);
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
                await _student.Delete(id.ToString());
                return Ok($"Data student {id} brehasil didelete");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("withcourses")]
        public async Task<IEnumerable<Student>> GetWithCourse()
        {
            var results = await _student.GetWithCourse();
            return results;
        }
    }
}
