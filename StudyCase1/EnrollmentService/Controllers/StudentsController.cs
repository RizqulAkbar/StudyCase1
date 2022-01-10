using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnrollmentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using EnrollmentService.Data;
using System.Threading.Tasks;
using EnrollmentService.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

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


        //private List<Student> lstStudent = new List<Student>
        //{
        //    new Student { ID=1,FirstName="Agus",LastName="Kurniawan",
        //    EnrollmentDate=DateTime.Now},
        //    new Student { ID=2,FirstName="Erick",LastName="Kurniawan",
        //    EnrollmentDate=DateTime.Now},
        //    new Student { ID=2,FirstName="Agus",LastName="Kurnia",
        //    EnrollmentDate=DateTime.Now}
        //};

        [HttpGet]
        //public async Task<IEnumerable<Student>> Get()
        //{
        //var result = await _student.GetAll();
        //return result;
        //}
        public async Task<ActionResult<IEnumerable<StudentDTO>>> Get()
        {
            var students = await _student.GetAll();

            //List<StudentDTO> lstStudentDTO = new List<StudentDTO>();
            //foreach (var student in students)
            //{
            //    lstStudentDTO.Add(new StudentDTO
            //    {
            //    ID = student.ID,
            //    Name = $"{student.FirstName} {student.LastName}",
            //    EnrollmentDate = student.EnrollmentDate
            //    });
            //}

            var dtos = _mapper.Map<IEnumerable<StudentDTO>>(students);

            return Ok(dtos);
        }

        private ActionResult<IEnumerable<StudentDTO>> OK(IEnumerable<StudentDTO> dtos)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        //public async Task<Student> Get(int id)
        //{
        //    var result = await _student.GetById(id.ToString());
        //    return result;
        //}
        public async Task<ActionResult<Student>> Get(int id)
        {
            var result = await _student.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<StudentDTO>(result));
        }

        [HttpPost]
        //public async Task<IActionResult> Post([FromBody]Student student)
        //{
        //    try
        //    {
        //        var result = await _student.Insert(student);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        public async Task<ActionResult<StudentDTO>> Post([FromBody] StudentForCreateDTO studentforcreatedto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentforcreatedto);
                var result = await _student.Insert(student);
                var studentResult = _mapper.Map<StudentDTO>(result);
                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO>> Put(int id,[FromBody] StudentForCreateDTO studentfordto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentfordto);
                var result = await _student.Update(id.ToString(), student);
                var studentresult = _mapper.Map<StudentDTO>(result);
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

        ////[HttpGet("{id}")]
        //public Student Get(int id)
        //{
        //    ////var result = lstStudent.Where(s => s.ID == id).SingleOrDefault();
        //    //var result = (from s in lstStudent select s).SingleOrDefault();
        //    //if (result != null)
        //    //    return result;
        //    //else
        //    //    return new Student { };

        //}

        //[HttpGet("byname")]
        //public List<Student> Get(string firstname = "", string lastname = "")
        //{
        //    //if (firstname == null)
        //    //    firstname == "";
        //    //if (lastname == null)
        //    //    lastname == "";
        //    var result = lstStudent.Where(s => s.FirstName.StartsWith(firstname) && s.LastName.StartsWith(lastname)).ToList();
        //    //var result = (from s in lstStudent where s.FirstName.ToLower().StartsWith(firstname.ToLower()) 
        //                 //select s).ToList();
        //    return result;
        //}
    }
}
