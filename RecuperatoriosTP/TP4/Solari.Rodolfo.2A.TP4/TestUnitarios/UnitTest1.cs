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
        /// Prueba la insercion de un libro de tipo diccionario a la base de datos
        /// </summary>
        [TestMethod]
        public void TestInsertarLibroTipoDiccionario()
        {
            AccesoBaseDeDatos ad = new AccesoBaseDeDatos();
            Diccionario diccionario = new Diccionario(2, "Enciclopedia Universal", 500, "ingles", 2000, 4, "Visual");
            bool insertarLibro = ad.InsertarLibro(diccionario);

            Assert.IsTrue(insertarLibro);
        }

        /// <summary>
        /// Insertar y eliminar libro de tipo cuento
        /// </summary>
        [TestMethod]
        public void TestInsertarYEliminarLibroTipoCuento()
        {
            AccesoBaseDeDatos ad = new AccesoBaseDeDatos();
            Cuento cuento = new Cuento(2, "Enciclopedia Universal", 500, "ingles", 2000, 4, 30);
            ad.InsertarLibro(cuento);

            bool eliminoLibro = ad.EliminarLibro(cuento);
            Assert.IsTrue(eliminoLibro);
        }

        /// <summary>
        /// Se prueba con un libro que contiene un id que no esta ingresado en la base de datos
        /// devuelve null
        /// </summary>
        [TestMethod]
        public void TestobtenerLibroNoIngresado()
        {
            AccesoBaseDeDatos ad = new AccesoBaseDeDatos();
            Libro libro = ad.ObtenerLibroPorId(70000);
            Assert.IsNull(libro);
        }

        /// <summary>
        /// prueba de conexion de base de datos
        /// </summary>
        [TestMethod]
        public void TestprobarConexionBaseDeDatos()
        {
            AccesoBaseDeDatos ad = new AccesoBaseDeDatos();
            Assert.IsTrue(ad.ProbarConexion());
        }
    }
}
