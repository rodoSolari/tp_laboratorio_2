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
        /// <summary>
        /// Verifica que el nombre del alumno no se cargue debido a que contiene caracteres no validos
        /// </summary>
        [TestMethod]
        public void TestNombreAlumnoInvalido()
        {
            Alumno alumno = new Alumno(1, "&$#34#@@", "Suarez", "13234333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            bool nombreValido = alumno.Nombre == null;
            Assert.IsTrue(nombreValido);
        }

        /// <summary>
        /// Se espera una excepcion de tipo DniInvalido por contener caracteres no validos para un dni
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            Profesor profesor = new Profesor(1, "Fernando", "Suarez", "EEEE3%$3", Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        /// Verifica que la jornada no sea nula al agregar un alumno
        /// </summary>
        [TestMethod]
        public void TestColeccionJornadaAgregarAlumno()
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
