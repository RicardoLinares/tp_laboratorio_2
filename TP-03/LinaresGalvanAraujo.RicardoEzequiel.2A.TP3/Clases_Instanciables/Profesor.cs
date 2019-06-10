using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace Clases_Instanciables
{
    [Serializable]
    public class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        static private Random random;

        /// <summary>
        /// Genera una cola de EClases para clasesDelDia
        /// </summary>
        private void _randomClases()
        {
            Array valores = Enum.GetValues(typeof(Universidad.EClases));
            this.clasesDelDia.Clear();
            int index = Profesor.random.Next(valores.Length);
            this.clasesDelDia.Enqueue((Universidad.EClases)index);
            this.clasesDelDia.Enqueue((Universidad.EClases)index);

        }
        /// <summary>
        /// Crea una cadena con toda la informacion de este profesor
        /// </summary>
        /// <returns>String una cadena con toda la informacion de ese profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.MostrarDatos());
            builder.AppendLine(this.ParticiparEnClase());
            return builder.ToString();
        }
        /// <summary>
        /// Crea un string con el listado de clasesDelDia
        /// </summary>
        /// <returns>String con dicha informacion</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("CLASES DEL DIA:");
            builder.AppendFormat("{0}\n{1}", this.clasesDelDia.Peek().ToString(), this.clasesDelDia.ElementAt(1).ToString());
            return builder.ToString();
        }
        /// <summary>
        /// Sobreescritura de tostring() hace publico el metodo MostrarDatos()
        /// </summary>
        /// <returns>String una cadena con toda la informacion de ese profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Constructor estatico de Profesor, inicializa el Atributo estatico random...
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random(); 
        }

        /// <summary>
        /// Necesario para la serializacion...
        /// </summary>
        private Profesor()
        {

        }


        /// <summary>
        /// El Constructor de Profesor, 
        /// Siempre es Inicializado con 2 elmentos en la cola clasesDelDia elegidos al azar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        /// <summary>
        /// Sobrecarga de operador == Profesor, Eclase
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns>True si el profesor tiene esta clase, false en el caso contrario</returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            bool respuesta = false;
            foreach(Universidad.EClases c in profesor.clasesDelDia)
            {
                if(c == clase)
                {
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Sobrecarga de operador != Profesor, Eclase
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns>False si el profesor tiene esta clase, True en el caso contrario</returns>
        public static bool operator !=(Profesor profesor, Universidad.EClases clases)
        {
            return !(profesor == clases);
        }
    }
}
