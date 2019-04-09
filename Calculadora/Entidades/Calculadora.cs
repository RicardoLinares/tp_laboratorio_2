using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                default:
                    break;
            }
            return resultado;
        }
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
