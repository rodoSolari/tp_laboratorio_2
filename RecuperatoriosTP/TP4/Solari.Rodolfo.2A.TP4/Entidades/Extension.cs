using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extension
    {
        
        /// <summary>
        /// Devuelve los datos de la facturacion
        /// </summary>
        /// <param name="libreria">libreria</param>
        /// <param name="cli">cliente</param>
        /// <returns></returns>
        public static string GenerarDatosFactura(this Libreria libreria, Cliente cli)
        {
            StringBuilder strFactura = new StringBuilder();
            strFactura.AppendLine("\n--- LIBRERIA DE IDIOMAS ---\n");
            strFactura.AppendLine(cli.devolverInformacionCliente());
            strFactura.AppendLine(libreria.devolverVentasCliente());

            return strFactura.ToString();
        }
    }
}
