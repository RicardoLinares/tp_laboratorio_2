using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;
using System.Xml.Serialization;
namespace EntidadesAbstractas
{
    [Serializable]
    [XmlInclude(typeof(Persona))]
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        /// <summary>
        /// Propiedad de Apellido
        /// Set: validara si el formato es correcto
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de Nombre
        /// Set: validara si el formato es correcto
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de dni
        /// SET: Se va a validar el dni antes de asignar.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad,value);
            }
        }
        /// <summary>
        /// Propiedad de nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad para convertir una cadena a un entero formato dni
        /// Set: valida si la cadena puede ser convertida y si esta en el rango
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        

        /// <summary>
        /// Constructor por defecto de persona
        /// Valores se inicializan en "NADA", 1 argentino respectivamente
        /// </summary>
        public Persona() : this("Nada","Nada","1",ENacionalidad.Argentino)
        {

        }
        /// <summary>
        /// Sobrecarga de Constructor de persona
        /// el dni se inicializa en 1
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) :  this(nombre,apellido,"1",nacionalidad)
        {

        }
        /// <summary>
        /// Sobrecarga de Constructor de persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,dni.ToString(),nacionalidad)
        {

        }
        /// <summary>
        /// Sobrecarga de Constructor de persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Valida si el formato del dni es correcto
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>int El dni validado</returns>
        /// <exception cref="DniInvalidoException">Si el numero no tiene el formato correcto</exception>
        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            try
            {
                dni = int.Parse(dato);
                if(99999999 < dni)
                {
                    throw new Exception("Numero de dni demasiado grande");
                }
            }
            catch (Exception e)
            {

                throw new DniInvalidoException(e);
            }
            return this.ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Valida si el dni ingresado es valido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>int El dni validado</returns>
        /// <exception cref="NacionalidadInvalidaException">Si la nacionalidad es invalida con ese numero de dni</exception>
        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino)
            {
                if(!(dato > 0 && dato < 90000000))
                {
                    throw new NacionalidadInvalidaException("Dni invalido para la Nacionalidad Argentina.");
                }
            }
            else
            {
                if(dato < 90000000 || dato > 99999999)
                {
                    throw new NacionalidadInvalidaException("Dni invalido para la Nacionalidad Extrajero.");
                }
            }
            return dato;
        }

        /// <summary>
        /// Valida si la cadena tiene el formato correcto para un nombre
        /// solo letras permitidas
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>String con el nombre si es correcto, String Vacio si no es correcto</returns>
        private string ValidarNombreApellido(string dato)
        {
            string resultado = "";
            if (dato.All(char.IsLetter))
            {
                resultado = dato;
            }
            return resultado;
        }
        /// <summary>
        /// Override de toString, muestra toda la informacion de persona
        /// </summary>
        /// <returns>String con la informacion de persona</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.nombre);
            builder.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad.ToString());
            return builder.ToString();
        }
    }
}
