using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Exceptions;
using Clases_Instanciables;
using EntidadesAbstractas;
namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExcepcionesArchivos()
        {
            try
            {
                Xml<int> xml = new Xml<int>();
                xml.Guardar(null, 5);
                Assert.Fail("Deberia haber Lanzado una excepcion");
            }
            catch (ArchivosException e)
            {
                // Se espera que sea archivoException la excepcion de la funcion guardar
            }
        }
        [TestMethod]
        public void ExcepcionesBuscarProfesorParaClaseIverso()
        {
            Universidad gim = new Universidad();
            Profesor profesor = new Profesor(1, "nombre", "Apellido", "1", Persona.ENacionalidad.Argentino);
            gim += profesor;
            try
            {
                Profesor resultado = profesor;
                resultado = gim != Universidad.EClases.Laboratorio;
                resultado = gim != Universidad.EClases.SPD;
                resultado = gim != Universidad.EClases.Programacion;
                resultado = gim != Universidad.EClases.Legislacion;
                Assert.Fail("Se tuvo que lanzar una excepcion tipo SinProfesorException a este punto...");
            }
            catch(SinProfesorException e)
            {
                
            }
        }

        [TestMethod]
        public void TestDniStringADniInt()
        {
            Alumno alumno = new Alumno(1, "Nombre", "Apellido", "1234567", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

            Assert.AreEqual<int>(1234567, alumno.DNI);
        }
        [TestMethod]
        public void TestUniversidadNullFree()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Profesor);
            Assert.IsNotNull(universidad.Jornadas);
        }
    }
}
