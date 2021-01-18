using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaUnt.Entities
{
    public class AlumnoDto
    {
        public int i_IdAlumnos { get; set; }
        [Required]
        public string v_NombresApellidos { get; set; }
        [Required]
        public string v_Dni { get; set; }
        [Required]
        public string v_Carrera { get; set; }
    }
}
