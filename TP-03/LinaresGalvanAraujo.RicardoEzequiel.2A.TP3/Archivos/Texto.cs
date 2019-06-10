using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Exceptions;
namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        /// <summary>
        /// Guarda una cadena a un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Bool si se logro guardar correctamente</returns>
        /// <exception cref="ArchivosException">si hubo un error</exception>
        public bool Guardar(string archivo, string datos)
        {
            bool respuesta = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.Write(datos);
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return respuesta;
        }
        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>string si la lectura fue exitosa</returns>
        /// <exception cref="ArchivosException">si hubo un error</exception>
        public bool Leer(string archivo, out string datos)
        {
            bool respuesta = false;
            string cadenaExtraida = null;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                   cadenaExtraida = reader.ReadToEnd();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            datos = cadenaExtraida;
            return respuesta;
        }
    }
}
