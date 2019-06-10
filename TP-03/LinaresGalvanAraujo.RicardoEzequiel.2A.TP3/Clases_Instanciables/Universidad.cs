using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;
using System.Xml.Serialization;
using Archivos;
namespace Clases_Instanciables
{

    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        /// <summary>
        /// Propiedad de Listado de alumnos(Para la serializacion)
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                List<Alumno> alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de Listado de Profesores(Para la serializacion)
        /// </summary>
        public List<Profesor> Profesor
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad de Listado de Jornada(Para la serializacion)
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Propiedad indexacion de la lista jornada
        /// GET: devuelve la jornada en el indice i
        /// SET: añade la jornada a la lista.
        /// </summary>
        /// <param name="i">indice</param>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada.Add(value);
            }
        }
        /// <summary>
        /// Constructor por defecto de universidad
        /// Inicializa las listas alumnos,profesores y jornada
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        /// <summary>
        /// Guardara un objeto Universidad en un archivo XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True si todo salio bien</returns>
        /// <exception cref="ArchivosException">si algo salio mal</exception>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Tratara de leer un objeto Unversidad desde un archivo XML
        /// </summary>
        /// <returns>true, si todo salio bien</returns>
        /// <exception cref="ArchivosException">si algo salio mal</exception>
        public static Universidad Leer()
        {
            Universidad universidad;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out universidad);
            return universidad;
        }
        /// <summary>
        /// Creara una cadena gigante con todos los datos de las jornadas 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>String con los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("JORNADA:");
            foreach(Jornada j in uni.jornada)
            {
                builder.AppendFormat("{0}", j.ToString());
                builder.AppendLine("<---------------------------------------->");
            }
            return builder.ToString();
        }
        /// <summary>
        /// sobreescritura de ToString(), Publica los resultaod de MostrarDatos()
        /// </summary>
        /// <returns>String con los datos de universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Sobrecarga de operador == Universidad, profesor
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="profesor"></param>
        /// <returns>True si el profesor esta en la lista, False si no lo esta</returns>
        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            bool respuesta = false;
            foreach (Profesor a in universidad.profesores)
            {
                if (a == profesor)
                {
                    respuesta = true;
                    break;
                }
            }

            return respuesta;
        }
        /// <summary>
        /// Sobrecarga de operador == Universidad, Clases
        /// Se buscara un profesor que pueda tomar la clase
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clases"></param>
        /// <returns>Profesor, si se encontro un profesor de la clase</returns>
        /// <exception cref="SinProfesorException">si no se encuentra profesor de la clase</exception>
        public static Profesor operator ==(Universidad universidad, EClases clases)
        {
            Profesor instructor = null;
            bool encontrado = false;
            foreach (Profesor p in universidad.profesores)
            {
                if (p == clases)
                {
                    instructor = p;
                    encontrado = true;
                    break;
                }
            }
            if (encontrado == false)
            {
                throw new SinProfesorException();
            }
            return instructor;
        }
        /// <summary>
        /// Sobrecarga de operador != Universidad, Clases
        /// Se buscara un profesor no tome este tipo la clase
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clases"></param>
        /// <returns>Profesor</returns>
        /// <exception cref="SinProfesorException">si da la casualidad que todos los profesores toman esta clase</exception>
        public static Profesor operator !=(Universidad universidad, EClases clases)
        {
            Profesor instructor = null;
            bool encontrado = false;
            foreach (Profesor p in universidad.profesores)
            {
                if (p != clases)
                {
                    instructor = p;
                    encontrado = true;
                    break;
                }
            }
            if (encontrado == false)
            {
                throw new SinProfesorException();
            }
            return instructor;
        }
        /// <summary>
        /// Sobrecarga de operador + Universidad, Clase
        /// Agregara una jornada con el el tipo de clase, el profesor y alumnos que tomen esa clase
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clases"></param>
        /// <returns>Universidad</returns>
        /// <exception cref="SinProfesorException">Si no hay profesor que tome la clase</exception>
        public static Universidad operator +(Universidad universidad, EClases clases)
        {
            Profesor instructor = universidad == clases;
            Jornada nuevaJornada = new Jornada(clases, instructor);
            foreach(Alumno a in universidad.alumnos)
            {
                if(a == clases)
                {
                    nuevaJornada += a;
                }
            }
            universidad.jornada.Add(nuevaJornada);
            return universidad;

        }
        /// <summary>
        /// Sobrecarga de operador + Universidad, Clase
        /// Se tratara de agregar el alumno al listado
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns>Universidad</returns>
        /// <exception cref="AlumnoRepetidoException">si esta repetido en la lista</exception>
        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if(universidad != alumno)
            {
                universidad.alumnos.Add(alumno);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return universidad;
        }
        /// <summary>
        /// Sobrecarga de operador + Universidad, Profesor
        /// Agregara el profesor a la lista
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="profesor"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if(universidad != profesor)
            {
                universidad.profesores.Add(profesor);
            }
            return universidad;
        }
        /// <summary>
        /// Sobrecarga de operador == Universidad, Alumno
        /// Se pregunta si el alumno esta en el listado de alumnos
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns>True si esta, False si no lo esta</returns>
        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            bool respuesta = false;
            foreach(Alumno a in universidad.alumnos)
            {
                if(a == alumno)
                {
                    respuesta = true;
                    break;
                }
            }

            return respuesta;
        }
        /// <summary>
        /// S
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="profesor"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }
        /// <summary>
        /// Sobrecarga de operador != Universidad, profesor
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="profesor"></param>
        /// <returns>False si el profesor esta en la lista, True si no lo esta</returns>
        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

    }
}
