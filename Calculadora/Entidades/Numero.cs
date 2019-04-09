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


        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        private double ValidarNumero(string strNumero)
        {
            double resultado;
            Double.TryParse(strNumero, out resultado);
            return resultado;
        }
        public string BinarioDecimal(string binario)
        {
            string resultado;
            try
            {
                resultado = Convert.ToInt32(binario, 2).ToString();
            }
            catch
            {
                resultado = "Valor Invalido";
            }
            finally
            {

            }
            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            string binario;
            try
            {
                int conversion = Convert.ToInt32(numero);
                binario = Convert.ToString(conversion, 2);
                double parteDecimal = numero - conversion;
                if(parteDecimal > 0)
                {
                    binario += ",";
                }
                for (int i = 0; i < 20 && parteDecimal != 0d; i++)
                {
                    parteDecimal = parteDecimal * 2;
                    if (parteDecimal >= 1d)
                    {
                        parteDecimal -= 1.0;
                        binario += "1";
                    }
                    else
                    {
                        binario += "0";
                    }
                }
            }
            catch(OverflowException)
            {
                binario = "Valor Invalido";
            }
            finally
            {

            }

            return binario;
        }

        public string DecimalBinario(string strNumero)
        {
            string binario = "Valor Invalido";
            double numero;
            if(Double.TryParse(strNumero, out numero))
            {
                binario = DecimalBinario(numero);
            }
            return binario;
        }
        public Numero() : this(0d.ToString())
        {

        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        public Numero(double numero) : this(numero.ToString())
        {

        }

        public static double operator  +(Numero numeroA, Numero NumeroB)
        {
            return numeroA.numero + NumeroB.numero;
        }
        public static double operator -(Numero numeroA, Numero NumeroB)
        {
            return numeroA.numero - NumeroB.numero;
        }
        public static double operator *(Numero numeroA, Numero NumeroB)
        {
            return numeroA.numero * NumeroB.numero;
        }
        public static double operator /(Numero numeroA, Numero NumeroB)
        {
            Double resultado;
            if(NumeroB.numero != 0)
            {
                resultado = numeroA.numero + NumeroB.numero;
            }
            else
            {
                resultado = Double.MinValue;
            }
            return resultado;
        }

    }
}
