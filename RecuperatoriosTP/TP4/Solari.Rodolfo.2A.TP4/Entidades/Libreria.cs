using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libreria
    {
        #region Atributos
        private List<Venta> listaVentas;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor libreria inicializando lista de ventas
        /// </summary>
        public Libreria()
        {
            this.listaVentas = new List<Venta>();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura lista de ventas
        /// </summary>
        public List<Venta> ListaVentas
        {
            get
            {
                return this.listaVentas;
            }
        }
        #endregion

        #region Atributos
        /// <summary>
        /// devuelve la lista de libros comprados(ventas) realizada por el cliente
        /// </summary>
        /// <returns></returns>
        public string devolverVentasCliente()
        {
            StringBuilder strVenta = new StringBuilder();
            foreach(Venta item in this.listaVentas)
            {
                strVenta.AppendLine(item.DevolverInformacionVenta(item.Libro));
            }
            return strVenta.ToString();
        }
        #endregion
    }
}
