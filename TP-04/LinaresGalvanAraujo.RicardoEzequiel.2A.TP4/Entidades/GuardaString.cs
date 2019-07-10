using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    static public class GuardaString
    {
        /// <summary>
        /// Guarda el string a un archivo en el escritorio
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        static public bool Guardar(this String texto, string archivo)
        {
            bool respuesta = false;
            try
            {
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (StreamWriter writer = new StreamWriter(escritorio + "\\" + archivo, true))
                {
                    writer.WriteLine(texto);
                    respuesta = true;
                }
            }
            catch
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}
