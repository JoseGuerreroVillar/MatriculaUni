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

        public async Task<bool> ActualizarAlumnos(List<AlumnoDto> alumnos)
        {
            using (var context = new MatriculaUntContext())
            {
                try
                {
                    var objAlumnos = alumnos.Select(s => new Alumno
                    {
                        i_IdAlumnos = s.i_IdAlumnos,
                        v_NombresApellidos = s.v_NombresApellidos,
                        v_Dni = s.v_Dni,
                        v_Carrera = s.v_Carrera
                    });

                    foreach (var item in objAlumnos)
                    {
                        if (item.i_IdAlumnos > 0)
                        {
                            context.Alumnos.Update(item);
                        }
                        else
                        {
                            await context.Alumnos.AddAsync(item);
                        }
                    }
                    var r = await context.SaveChangesAsync();
                    return r > 0;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public async Task<AlumnoDto> ObtenerAlumnoPorId(int id)
        {
            var listResult = new List<AlumnoDto>();
            using (var context = new MatriculaUntContext())
            {
                var data = await context.Alumnos.Where(w => w.i_IdAlumnos == id).ToListAsync();
                foreach (var item in data)
                {
                    var dto = new AlumnoDto();
                    dto.i_IdAlumnos = item.i_IdAlumnos;
                    dto.v_NombresApellidos = item.v_NombresApellidos;
                    dto.v_Carrera = item.v_Carrera;
                    dto.v_Dni = item.v_Dni;
                    listResult.Add(dto);
                }
                return listResult.FirstOrDefault();
            }
        }
    }
}
