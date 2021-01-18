﻿using MatriculaUnt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaUnt.BL
{
    public interface IAlumnosRepository
    {
        public Task<List<AlumnoDto>> ObtenerAlumnos();
    }
}
