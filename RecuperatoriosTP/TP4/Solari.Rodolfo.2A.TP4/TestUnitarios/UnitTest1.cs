using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Intenta leer un archivo de texto que no existe
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestLeerArchivoNoExistente()
        {
            ArchivoTexto<string> archivo = new ArchivoTexto<string>();
            string datos = "";
            archivo.Leer("OtroArchivo.txt",out datos);
        }

        /// <summary>
        /// Crea un cuento con un nombre no valido
        /// </summary>
        [TestMethod]
        public void CrearCuento()
        {
            Cuento cuento = new Cuento(2,null,300,"ingles",4000,40,5);
            bool cuentoValido = cuento.Nombre != null;
            Assert.IsFalse(cuentoValido);
        }

        /// <summary>
        /// prueba de conexion de base de datos
        /// </summary>
        [TestMethod]
        public void probarConexionBaseDeDatos()
        {
            AccesoBaseDeDatos ad = new AccesoBaseDeDatos();
            Assert.IsTrue(ad.ProbarConexion());
        }
    }
}
