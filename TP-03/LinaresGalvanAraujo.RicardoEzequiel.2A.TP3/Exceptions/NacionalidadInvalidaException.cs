using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto de NacionalidadInvalidaException
        /// el mensaje sera por defecto sera ""La Nacionalidad no es valida""
        /// </summary>
        public NacionalidadInvalidaException() : this("La Nacionalidad no es valida")
        {

        }
        /// <summary>
        /// Sobrecarga de Constructor de NacionalidadInvalidaException
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
