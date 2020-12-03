using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        #region Atributos
        private Libro libro;
        private int cantidad;
        private int precioFinal;
        private bool efectivo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor venta sin parametros
        /// </summary>
        public Venta()
        {
        }

        /// <summary>
        /// Constructor venta asignando libro
        /// </summary>
        /// <param name="libro"></param>
        public Venta(Libro libro) : this()
        {
            this.libro = libro;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura Libro
        /// </summary>
        public Libro Libro
        {
            get
            {
                return this.libro;
            }
            set
            {
                this.libro = value;
            }
        }

        /// <summary>
        /// Propiedad lectura y escritura cantidad
        /// </summary
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }

        /// <summary>
        /// Propiedad lectura y escritura efectivo
        /// </summary>
        public bool Efectivo
        {
            get
            {
                return this.efectivo;
            }
            set
            {
                this.efectivo = value;
            }
        }

        /// <summary>
        /// Propiedad lectura y escritura precio final
        /// </summary>
        public int PrecioFinal
        {
            get
            {
                return this.precioFinal;
            }
            set
            {
                this.precioFinal = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Realiza la venta, descontando el stock del libro y realizando el precio final de la venta
        /// </summary>
        /// <param name="cantidad"></param>
        public void Vender(Libro libro,int cantidad)
        {
            this.cantidad = cantidad;
            libro.Stock -= cantidad;
            this.precioFinal = cantidad * (int)libro.Precio;
            if (this.efectivo)
            {
                this.precioFinal -= (this.precioFinal/10);
            }
        }

        /// <summary>
        /// Devuelve el descuento del cliente
        /// </summary>
        /// <returns></returns>
        public string pagaEnEfectivo(bool efectivo)
        {
            string respuesta = "No";
            if (this.efectivo)
            {
                respuesta = "Si";
            }
            return respuesta;
        }

        /// <summary>
        /// Devuelve la informacion de la venta
        /// </summary>
        /// <returns></returns>
        public string DevolverInformacionVenta(Libro l)
        {
            StringBuilder strVenta = new StringBuilder();
            strVenta.AppendLine(l.devolverInformacionLibro());
            strVenta.AppendFormat("Cantidad : {0}\n", this.cantidad);
            strVenta.AppendFormat("Paga en efectivo? {0}\n", this.pagaEnEfectivo(this.efectivo));
            strVenta.AppendFormat("Importe a pagar : ${0}\n", this.precioFinal);
            strVenta.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            return strVenta.ToString();
        }

        #endregion
    }
}
