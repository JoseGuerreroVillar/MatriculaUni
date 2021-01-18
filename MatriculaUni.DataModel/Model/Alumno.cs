using System;
using System.Collections.Generic;

#nullable disable

namespace MatriculaUni.DataModel.Model
{
    public partial class Alumno
    {
        public int i_IdAlumnos { get; set; }
        public string v_NombresApellidos { get; set; }
        public string v_Dni { get; set; }
        public string v_Carrera { get; set; }
    }
}
