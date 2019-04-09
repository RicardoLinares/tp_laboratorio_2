using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero numero = new Numero("2,2");
            Numero numero2 = new Numero("0");
            
            Console.WriteLine("{0}", Calculadora.Operar(numero,numero2,"*"));
            Console.ReadLine();

        }
    }
}
