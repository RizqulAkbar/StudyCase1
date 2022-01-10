using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Dtos;
using System;
using System.Collections.Generic;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IPaymentRepo _repository;
        private readonly IMapper _mapper;

        public EnrollmentsController(IPaymentRepo repository,
        IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult<IEnumerable<EnrollmentReadDto>> GetEnrollments()
        {
            Console.WriteLine("-->Ambil Enrollments dari PaymentsService");
            var enrollmentItems = _repository.GetAllEnrollments();
            return Ok(_mapper.Map<IEnumerable<EnrollmentReadDto>>(enrollmentItems));
        }

        [HttpPost]
        public ActionResult TestIndboundConnection()
        {
            Console.WriteLine("--> Inbound POST command services");
            return Ok("Inbound test from enrollments controller");
        }
    }
}