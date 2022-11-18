using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFinalKwiecinskiJoel.Data;
using WebApiFinalKwiecinskiJoel.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiFinalKwiecinskiJoel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly DbHospitalAPIContext _context;

        public DoctorController(DbHospitalAPIContext context)
        {
            _context = context;
        }


        // GET /api/doctor/listar
        [HttpGet("/api/doctor/listar")]
        public List<Doctor> Get()
        {
            List<Doctor> doctors = (from d in _context.Doctors
                                    select d).ToList();
            return doctors;
        }


        // GET /api/doctor/No
        [HttpGet("{No}")]
        public ActionResult<Doctor> Get(int No)
        {
            Doctor doctor = (from d in _context.Doctors
                             where d.No == No
                             select d).SingleOrDefault();
            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }


        // GET /api/doctor/especialidad
        [HttpGet("/api/doctor/especialidad/{especialidad}")]
        public ActionResult<List<Doctor>> Get(string especialidad)
        {
            var doctor = (from d in _context.Doctors
                          where d.Especialidad == especialidad
                          select d).ToList();
            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }


        // POST /api/doctor
        [HttpPost]
        public ActionResult Post([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return Ok();
        }


        // DELETE /api/doctor
        [HttpDelete("{No}")]
        public ActionResult Delete(int No, [FromBody] Doctor doctor)
        {
            if (No != doctor.No)
            {
                return BadRequest();
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return Ok();
        }


        // PUT /api/doctor/No
        [HttpPut("{No}")]
        public ActionResult Put(int No, [FromBody] Doctor doctor)
        {
            if (No != doctor.No)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }
    }
}
