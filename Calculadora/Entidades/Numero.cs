using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// la propiedad es de solo escritura, asigna el valor de instancia numero.
        /// </summary>
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida la cadena y devuelve el valor equivalente en Double
        /// </summary>
        /// <param name="strNumero">la cadena a validar(se espera que sea un numero)</param>
        /// <returns>N si la cadena es valida o 0 cuando no lo es</returns>
        private double ValidarNumero(string strNumero)
        {
            double resultado;
            Double.TryParse(strNumero, out resultado);
            return resultado;
        }
        /// <summary>
        /// Convierte la cadena numerica binaria(base 2) a un cadena numerica decimal(base 10)
        /// </summary>
        /// <param name="strNumero">el cadena base 2 a convetir</param>
        /// <returns>Cadena con un numero base 10 equivalente si la cadena es valida o "Valor Invalido" ERROR ""</returns>
        public static string BinarioDecimal(string strNumero)
        {
            string resultado = "Valor Invalido";
            if (Double.TryParse(strNumero, out double numero))
            {

                double acumResultado = 0;
                bool esDecimal = false;
                string parteEntera = "";
                string parteDecimal = "";
                bool valorValido = true;
                foreach (char caracterNumerico in strNumero)
                {
                    if (Int32.TryParse(caracterNumerico.ToString(), out int x))
                    {
                        if (esDecimal)
                        {
                            parteDecimal += caracterNumerico;
                        }
                        else
                        {
                            parteEntera += caracterNumerico;
                        }
                    }
                    else if (caracterNumerico == '.' && esDecimal == false)
                    {
                        esDecimal = true;
                    }
                    else
                    {
                        valorValido = false;
                    }
                }
                if (valorValido)
                {
                    for (int i = parteEntera.Length; i > 0 ; i--)
                    {
                        acumResultado += Convert.ToInt32(parteEntera.ElementAt(parteEntera.Length - i).ToString()) * Math.Pow(2, i - 1);
                    }
                    if (esDecimal)
                    {
                        for (int i = 0; i < parteDecimal.Length; i++)
                        {
                            acumResultado += Convert.ToInt32(parteDecimal.ElementAt(i).ToString()) * Math.Pow(2, -(i + 1));
                        }
                    }
                    resultado = acumResultado.ToString();
                }

            }
            return resultado;
        }
        /// <summary>
        /// Convierte un numero Base 10 a un numero Base 2
        /// </summary>
        /// <param name="numero">el numero a convertir</param>
        /// <returns>"Cadena numerica base 2" si el numero es valido, "Valor Invalido" Error</returns>
        public static string DecimalBinario(double numero)
        {
            return DecimalBinario(numero);
        }
        /// <summary>
        /// Convierte una cadena numerica Base 10 a un numero Base 2
        /// </summary>
        /// <param name="strNumero">la cadena a convertir</param>
        /// <returns>"Cadena numerica base 2" si el numero es valido, "Valor Invalido" Error</returns>
        public static string DecimalBinario(string strNumero)
        {
            string binario = "Valor Invalido";
            double numero;
            if (Double.TryParse(strNumero, out numero))
            {
                bool esDecimal = false;
                string parteEnteraStr = "";
                double parteEntera;
                double parteDecimal = 0;
                bool valorValido = true;
                foreach (char caracterNumerico in strNumero)
                {
                    if (Int32.TryParse(caracterNumerico.ToString(), out int x))
                    {
                        if (!esDecimal)
                        {
                            parteEnteraStr += caracterNumerico;
                        }
                    }
                    else if (caracterNumerico == '.' && esDecimal == false)
                    {
                        esDecimal = true;
                        parteDecimal = numero - ((long)numero);
                    }
                    else
                    {
                        valorValido = false;
                    }
                }
                if (valorValido)
                {
                    parteEntera = Convert.ToInt32(parteEnteraStr);
                    binario = Convert.ToString(Convert.ToInt32(parteEntera), 2);
                    if (esDecimal)
                    {
                        binario += ".";
                        for (int i = 0; i < 40; i++)
                        {
                            parteDecimal = parteDecimal * 2;
                            if(parteDecimal >= 1)
                            {
                                binario += "1";
                                parteDecimal -= 1d;
                                if(parteDecimal == 0d)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                binario += "0";
                            }
                        }
                    }
                }

            }
            return binario;
        }
        /// <summary>
        /// Contructor por defecto. el valor por defecto de la variable de instancia "numero" es 0
        /// </summary>
        public Numero() : this(0d.ToString())
        {

        }
        /// <summary>
        /// Sobrecarga Contructor de Numero. 
        /// </summary>
        /// <param name="strNumero">al pasar una cadena numerica se la "parsea" a double y se la asignara a "numero" </param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Sobrecarga Contructor de Numero. 
        /// </summary>
        /// <param name="numero">el parametro Double numero se asignara a "numero"</param>
        public Numero(double numero) : this(numero.ToString())
        {

        }
        /// <summary>
        /// Sobrecarga del operador "+" cuando se trabaja con Numero
        /// </summary>
        /// <param name="NumeroA">instancia de la Clase Numero</param>
        /// <param name="NumeroB">instancia de la Clase Numero</param>
        /// <returns>N, la suma de los valores "numero" de las clases</returns>
        public static double operator  +(Numero NumeroA, Numero NumeroB)
        {
            return NumeroA.numero + NumeroB.numero;
        }
        /// <summary>
        /// Sobrecarga del operador "-" cuando se trabaja con Numero
        /// </summary>
        /// <param name="NumeroA">instancia de la Clase Numero</param>
        /// <param name="NumeroB">instancia de la Clase Numero</param>
        /// <returns>N, la resta de los valores "numero" de las clases</returns>
        public static double operator -(Numero numeroA, Numero NumeroB)
        {
            return numeroA.numero - NumeroB.numero;
        }
        /// <summary>
        /// Sobrecarga del operador "*" cuando se trabaja con Numero
        /// </summary>
        /// <param name="NumeroA">instancia de la Clase Numero</param>
        /// <param name="NumeroB">instancia de la Clase Numero</param>
        /// <returns>N, el producto de los valores "numero" de las clases</returns>
        public static double operator *(Numero numeroA, Numero NumeroB)
        {
            return numeroA.numero * NumeroB.numero;
        }
        /// <summary>
        /// Sobrecarga del operador "-" cuando se trabaja con Numero
        /// </summary>
        /// <param name="NumeroA">instancia de la Clase Numero, este sera el dividendo</param>
        /// <param name="NumeroB">instancia de la Clase Numero, este sera el Divisor.</param>
        /// <returns>N, el cociente de la division entre los "numero" de las clases. Double.MinValue si el divisor es 0.</returns>
        public static double operator /(Numero dividendo, Numero Divisor)
        {
            Double resultado;
            if(Divisor.numero != 0)
            {
                resultado = dividendo.numero / Divisor.numero;
            }
            else
            {
                resultado = Double.MinValue;
            }
            return resultado;
        }
        //public override string ToString()
        //{
        //    return numero.ToString();
        //}
    }
}
