using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using ClasesAbstractas;
using Excepciones;

namespace TestUnitariosTP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNombreAlumnoInvalido()
        {
            Alumno alumno = new Alumno(1, "EEE34#@@", "Suarez", "13234333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            bool nombre = alumno.Nombre == " ";
            Assert.IsTrue(nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            Profesor profesor = new Profesor(1, "Fernando", "Suarez", "EEEE3%$3", Persona.ENacionalidad.Argentino);

        }

        [TestMethod]
        public void TestColeccionJornadaNula()
        {
            Profesor profesor = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);

            Alumno alumno = new Alumno(1, "Jose", "Herrera", "32955875", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            
            //Se agrega un alumno a la jornada
            jornada += alumno;

            Assert.IsNotNull(jornada);
        }
    }
}
