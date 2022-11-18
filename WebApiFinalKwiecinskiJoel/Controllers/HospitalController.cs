using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFinalKwiecinskiJoel.Data;
using WebApiFinalKwiecinskiJoel.Models;
using System.Linq;

namespace WebApiFinalKwiecinskiJoel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {

        private readonly DbHospitalAPIContext _context;

        public HospitalController(DbHospitalAPIContext context)
        {
            _context = context;
        }


        // GET /api/hospital
        [HttpGet]
        public dynamic Get()
        {
            var hospitals = (from h in _context.Hospitals
                             select new { h.Nombre, h.Telefono, h.Num_Cama }).ToList();
            if (hospitals == null)
            {
                return NotFound();
            }

            return hospitals;
        }


        // GET /api/hospital/NumCama
        [HttpGet("{NumCama}")]
        public dynamic Get(int NumCama)
        {
            var hospitals = (from h in _context.Hospitals
                             where h.Num_Cama > NumCama
                             select new { h.Nombre, h.Telefono, h.Num_Cama }).ToList();
            if (hospitals == null)
            {
                return NotFound();
            }

            return hospitals;
        }


        // POST /api/hospital
        [HttpPost]
        public ActionResult Post([FromBody] Hospital hospital)
        {
            if (hospital == null)
            {
                return BadRequest();
            }

            _context.Hospitals.Add(hospital);
            _context.SaveChanges();

            return Ok();
        }

    }
}
