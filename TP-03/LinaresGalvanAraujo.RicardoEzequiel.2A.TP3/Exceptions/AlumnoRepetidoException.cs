using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de AlumnoRepetidoException
        /// el mensaje sera por defecto sera ""Alumno repetido.""
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
    }
}
