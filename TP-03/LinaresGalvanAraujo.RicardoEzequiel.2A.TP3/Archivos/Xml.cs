using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Exceptions;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda un objeto en un archivo Xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Bool si se pudo guardar correctamente</returns>
        /// <exception cref="ArchivosException">si hubo un error</exception>
        public bool Guardar(string archivo, T datos)
        {
            bool resultado = false;
            try  // muchas de las lineas de este codigo pueden lanzar una excepcion
            {

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    serializer.Serialize(writer, datos);

                }
                resultado = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return resultado;
        }
        /// <summary>
        /// Lee un objeto de un archivo Xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>T si la lectura fue exitosa</returns>
        /// <exception cref="ArchivosException">Si hubo un error</exception>
        public bool Leer(string archivo, out T datos)
        {
            bool respuesta = false;
            T nuevoObjeto = default(T);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StreamReader reader = new StreamReader(archivo))
                {
                    nuevoObjeto = (T)serializer.Deserialize(reader);

                }
                respuesta = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e); 
            }
            datos = nuevoObjeto;
            return respuesta;
        }
    }
}
