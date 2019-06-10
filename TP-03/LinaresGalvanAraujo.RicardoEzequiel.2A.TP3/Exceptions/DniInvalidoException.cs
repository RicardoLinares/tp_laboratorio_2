using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        /// <summary>
        /// Constructor por defecto de DniInvalidoException
        /// el mensaje sera por defecto sera ""Dni invalido""
        /// </summary>
        public DniInvalidoException() : this("Dni invalido")
        {
        }
        /// <summary>
        /// Sobrecarga de Constructor de DniInvalidoException
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        {
            this.mensajeBase = "";
        }
        /// <summary>
        /// Sobrecarga de Constructor de DniInvalidoException
        /// el mensaje sera por defecto sera ""Dni invalido""
        /// </summary>
        /// <param name="innerException"></param>
        public DniInvalidoException(Exception innerException) : this("Dni invalido", innerException)
        {

        }
        /// <summary>
        /// Sobrecarga de Constructor de DniInvalidoException
        /// mensajeBase sera igual al mensaje de la innerException...
        /// </summary>
        public DniInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
            this.mensajeBase = innerException.Message;
        }
    }
}
