using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Opera dos instancia de la clase Numero
        /// </summary>
        /// <param name="numero1">Instancia de Numero</param>
        /// <param name="numero2">Instancia de Numero</param>
        /// <param name="operador">el operador que se quiere usar. se acepta: "*" "+" "-" "/", tienendo al "+" en caso de una cadena invalida</param>
        /// <returns>N el resultado de la operacion</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            operador = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "/":
                    resultado = numero1 / numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                default:
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// valida si la cadena es: "+" o "*" o "-" o "/"
        /// </summary>
        /// <param name="operador">la cadena a validar</param>
        /// <returns>operador si la cadena es uno de los operadores, "+" si la cadena es invalida</returns>
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "+":
                case "/":
                case "-":
                case "*":
                    break;
                default:
                    operador = "+";
                    break;
            }
            return operador;
        } 
    }
}
