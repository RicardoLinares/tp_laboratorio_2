using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad del listado de alumnos, Usado para la serializacionXml
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// propiedad de clase, Usado para la serializacionXml
        /// </summary>
        public Universidad.EClases Clases
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad de Instructor, Usado para la serializacionXml
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Constructor por defecto de jornada Inicializa el listado de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de Jornada, llama al constructor por defecto e Inicializa los atributos clase y instructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Sobrecarga de == para Jornada, Alumno. Para ver si el alumno esta en la jornada/clase
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns>True, Si esta en la clase, False si no esta en la clase</returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            bool respuesta = false;
            foreach(Alumno a in jornada.alumnos)
            {
                if(a == alumno)
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Sobrecarga de != para Jornada, Alumno. Para ver si el alumno esta en la jornada/clase
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns>False, Si esta en la clase, True si no esta en la clase</returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }
        /// <summary>
        /// Sobrecarga de + para Jornada, Alumno. Añade el alumno al listado si este no esta en el
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns>parametro Jornada</returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if(jornada != alumno)
            {
                jornada.alumnos.Add(alumno);
            }
            return jornada;
        }
        /// <summary>
        /// Sobreescritura de ToString()
        /// </summary>
        /// <returns>String con toda la informacion de la jornada</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("CLASE DE {0} POR\n", this.clase.ToString());
            builder.AppendLine(instructor.ToString());
            builder.AppendLine("ALUMNOS:");
            foreach(Alumno a in this.alumnos)
            {
                builder.AppendLine(a.ToString());
            }
            return builder.ToString();
        }
        /// <summary>
        /// Estatico, Guarda el objeto jornada en un archivo de texto plano
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si se pudo guardar correctamente</returns>
        /// <exception cref="Exceptions.ArchivosException">Si algo sale mal</exception>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Leera un archivo de texto...
        /// </summary>
        /// <returns>String, si se pudo leer el Archivo</returns>
        /// <exception cref="Exceptions.ArchivosException">si algo sale mal</exception>
        public static string Leer()
        {
            string jornada = "";
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out jornada);
            return jornada;
        }
    }
}
