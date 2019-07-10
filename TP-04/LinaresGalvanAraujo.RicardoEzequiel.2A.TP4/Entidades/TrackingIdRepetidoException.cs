using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Conrtructor de Excepcion con mensaje
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        /// Conrtructor de Excepcion con mensaje y una excepcion interna
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje,inner)
        {

        }
    }
}
