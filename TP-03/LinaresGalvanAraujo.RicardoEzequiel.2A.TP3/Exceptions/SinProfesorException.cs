using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor por defecto de SinProfesorException
        /// el mensaje sera por defecto sera ""No hay Profesor para la clase""
        /// </summary>
        public SinProfesorException() : base("No hay Profesor para la clase")
        {

        }
    }
}
