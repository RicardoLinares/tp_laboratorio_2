using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListDePaquetes()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void NoIdRepetidos()
        {
            Correo correo = new Correo();

            Paquete paqueteA = new Paquete("Dir", "10");
            Paquete paqueteB = new Paquete("Dir", "10");

            try
            {
                correo += paqueteA;
                correo += paqueteB;
                Assert.Fail("los ids ingresados eran repetidos.");
            }
            catch(TrackingIdRepetidoException e)
            {
                // si Lanzo un trackingIdRepetidoException es por que detecto que los id son iguales...
                
            }
        }
    }
}
