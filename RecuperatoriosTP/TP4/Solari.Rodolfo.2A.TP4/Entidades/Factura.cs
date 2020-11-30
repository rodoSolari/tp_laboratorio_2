using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Factura
    {
        
        /// <summary>
        /// Devuelve los datos de la facturacion
        /// </summary>
        /// <param name="libreria"></param>
        /// <param name="cli"></param>
        /// <returns></returns>
        public static string GenerarFactura(this Libreria libreria, Cliente cli)
        {
            return cli.devolverInformacionCliente() + libreria.devolverVentasCliente();
        }
    }
}
