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
            //Creacion de la conexion con la base de datos
            AccesoBaseDeDatos ad = new AccesoBaseDeDatos();

            if (ad.ProbarConexion())
            {
                Console.WriteLine("se conectó a la base de datos\n");
            }
            else
            {
                Console.WriteLine("no se conectó a la base de datos\n");
            }

            Console.WriteLine("**** Imprimo un libro con el id 6 ****\n");
            int idLibro = 6;
            Libro encontrarLibro = ad.ObtenerLibroPorId(idLibro);
            Console.WriteLine(encontrarLibro.devolverInformacionLibro());

            //Obtengo la lista de libros y las imprimo por consola
            Console.WriteLine("**** Imprimir lista de libros ****");
            List<Libro> lista = ad.ObtenerListaLibros();
            
            foreach (Libro item in lista)
            {
                Console.WriteLine(item.devolverInformacionLibro());
                Console.WriteLine("- - - - - - - - - - - - - - - - -\n");
            }

            //Agrego un objeto cuento
            Console.WriteLine("****Agregar Objeto cuento****\n");
            Cuento objetoCuento = new Cuento();
            objetoCuento.Nombre = "The New era";
            objetoCuento.Idioma = "Ingles";
            objetoCuento.Precio = 250f;
            objetoCuento.Stock = 10;
            objetoCuento.CantidadCapitulos = 6;
            Console.WriteLine(objetoCuento.devolverInformacionLibro());

            bool agrego = ad.InsertarLibro(objetoCuento);

            if (agrego)
            {
                Console.WriteLine("se agregó a la base de datos");
            }
            else
            {
                Console.WriteLine("no se agregó a la base de datos");
            }

            //eliminar libro
            Console.WriteLine("**** Eliminar objeto cuento ****\n");
            bool elimino = ad.EliminarLibro(objetoCuento);
            if (elimino)
            {
                Console.WriteLine("se elimina con exito\n");
            }
            else
            {
                Console.WriteLine("no se elimin\n");
            }

            //Venta de un diccionario
            Console.WriteLine("**** Venta de diccionario ****\n");
            Diccionario dic = new Diccionario(1, "Enciclopedia portuguesa", 500, "portugues", 2000, 20, "Visual");
            Venta venta = new Venta(dic);
            venta.Efectivo = true;  //Obtiene un descuento del 10%
            venta.Vender(dic, 3);
            Console.WriteLine(venta.DevolverInformacionVenta(dic));

            Console.ReadKey(true);

        }
    }
}
