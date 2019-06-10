using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor de ArchivosException:
        /// El mensaje de la excepcion sera "Hubo un error con el archivo: "
        /// se establece un innerException.
        /// </summary>
        public ArchivosException(Exception innerException) : base("Hubo un error con el archivo: ",innerException)
        {

        }
    }
}
