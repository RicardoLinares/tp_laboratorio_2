using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        /// <summary>
        /// Constructor por defecto de Unversitario
        /// usa el constructor base()...
        /// legajo se inicializa en 0
        /// </summary>
        public Universitario() : base()
        {
            
        }
        /// <summary>
        /// sobrecarga de constructor de universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
                                                                            : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Muestra todos los datos de Universitario
        /// </summary>
        /// <returns>String con todos los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo.ToString());
            return builder.ToString();
        }
        /// <summary>
        /// Firma de Metodo Abstracto.
        /// </summary>
        /// <returns>String relacionado con clases...</returns>
        protected abstract string ParticiparEnClase(); 

        /// <summary>
        /// Sobrecarga de Operador == Universitarios.
        /// 2 objetos universitarios seran iguales si tienen el mismo legajo o tienen el mismo dni
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True si son iguales False si no</returns>
        public static bool operator ==(Universitario a, Universitario b)
        {
            bool respuesta = false;
            if(a.legajo == b.legajo || a.DNI == b.DNI)
            {
                respuesta = true;
            }
            return respuesta;
        }
        /// <summary>
        /// Sobrecarga de Operador != Universitarios.
        /// 2 objetos universitarios NO seran iguales si tienen el mismo legajo o tienen el mismo dni
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>False si son iguales True si no</returns>
        public static bool operator !=(Universitario a, Universitario b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Sobreescritura de Equals
        /// un objeto sera igual a un universitario si es del mismo tipo y comparten el mismo dni o legajo.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si son iguales, False si no</returns>
        public override bool Equals(object obj)
        {
            bool respuesta = false;
            if(obj is Universitario)
            {
                respuesta = this == (Universitario)obj;
            }
            return respuesta;
        }
    }
}
