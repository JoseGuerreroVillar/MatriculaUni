using MatriculaUnt.BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaUnt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : Controller
    {
        public readonly IAlumnosRepository _repository;
        public AlumnosController(IAlumnosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult> ObtenerAlumnos()
        {
            try
            {
                var resul = await _repository.ObtenerAlumnos();
                return Ok(resul);
            }
            catch (Exception)
            {

                throw;
            } 
        }

        [HttpGet("ObtenerporId/{id}")]
        public async Task<ActionResult> ObtenerAlumnosPorId(int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id no puede ser 0");
                var resul = await _repository.ObtenerAlumnoPorId(id);

                return Ok(resul);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
