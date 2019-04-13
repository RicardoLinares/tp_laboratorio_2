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
        public static string BinarioDecimal(string strNumero)
        {
            string resultado = "Valor Invalido";
            if (Double.TryParse(strNumero, out double numero))
            {

                double acumResultado = 0;
                string parteEnteraBinaria = "";
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

        public static string DecimalBinario(double numero)
        {
            return DecimalBinario(numero);
        }

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
                resultado = numeroA.numero / NumeroB.numero;
            }
            else
            {
                resultado = Double.MinValue;
            }
            return resultado;
        }
        public override string ToString()
        {
            return numero.ToString();
        }
    }
}
