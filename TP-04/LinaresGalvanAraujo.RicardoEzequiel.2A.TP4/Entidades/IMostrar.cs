using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Retornara Datos de la clase que implementa esta interfaz.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>String</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
