using MatriculaUni.DataModel.Model;
using MatriculaUnt.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaUnt.BL
{
    public class AlumnosBL : IAlumnosRepository
    {
        public async Task<List<AlumnoDto>> ObtenerAlumnos()
        {
            var listResult = new List<AlumnoDto>();
            using (var context = new MatriculaUntContext())
            {
                var data = await context.Alumnos.ToListAsync();
                foreach (var item in data)
                {
                    var dto = new AlumnoDto();
                    dto.i_IdAlumnos = item.i_IdAlumnos;
                    dto.v_NombresApellidos = item.v_NombresApellidos;
                    dto.v_Carrera = item.v_Carrera;
                    dto.v_Dni = item.v_Dni;
                    listResult.Add(dto);
                }
                return listResult;
            }
        }
    }
}
