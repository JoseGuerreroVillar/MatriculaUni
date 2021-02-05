using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaUnt.Entities
{
    public class Tracker
    {
        public EstadoFila Estado { get; set; }
    }
    public enum EstadoFila
    {
        /// <summary>
        /// Indica que la fila no ha sido modificada
        /// </summary>
        sinCambios,
        /// <summary>
        /// Indica que la fila ha sido modificada
        /// </summary>
        conCambios
    }
}
