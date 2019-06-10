using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {   
        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;
        /// <summary>
        /// Constructor por defecto de Alumno
        /// se recomienda cambiar los valores mas tarde...
        /// </summary>
        public Alumno() : this(1,"Nada","Nada","1",ENacionalidad.Argentino,Universidad.EClases.Laboratorio, EEstadoCuenta.AlDia)
        {
            
        }
        /// <summary>
        /// Sobrecarga de Constructor de Alumno 
        /// se asume que la cuota esta al dia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
                                : this(id,nombre,apellido,dni,nacionalidad,claseQueToma,EEstadoCuenta.AlDia)
        {
        
        }
        /// <summary>
        /// Sobrecarga del Constructor de alumno
        /// version completa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
                                : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Crea un string con la clase que toma el alumno
        /// </summary>
        /// <returns>String con dicha informacion</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.clasesQueToma.ToString();
        }
        /// <summary>
        /// Crea una cadena con toda la informacion de este alumno
        /// </summary>
        /// <returns>String una cadena con toda la informacion de ese alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.MostrarDatos());
            builder.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta.ToString());
            builder.AppendLine(this.ParticiparEnClase());
            return builder.ToString();
        }

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        /// <summary>
        /// Sobreescritura de Tostring, hace publico el metodo MostrarDatos().
        /// </summary>
        /// <returns>String una cadena con toda la informacion de ese alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Sobrecarga de operador == alumno, Eclases
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clases"></param>
        /// <returns>True si el alumno toma esa clase y NO es un deudor, False de lo contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clases)
        {
            bool respuesta = false;
            if(a.clasesQueToma == clases)
            {
                if(a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Sobrecarga de operador != alumno, Eclases
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clases"></param>
        /// <returns>true si El alumno NO asiste a la clase, false de lo contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clases)
        {
            bool respuesta = false;
            if(a.clasesQueToma != clases)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
