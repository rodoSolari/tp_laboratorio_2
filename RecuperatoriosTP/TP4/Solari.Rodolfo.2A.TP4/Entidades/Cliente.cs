using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        #region Atributos
        private string dni;
        private string nombre;
        private string apellido;
        #endregion

        #region Constructores
        /// <summary>
        /// constructor Cliente
        /// </summary>
        public Cliente()
        {

        }

        /// <summary>
        /// Constructor cliente parametrizado
        /// </summary>
        /// <param name="dni">dni</param>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        public Cliente(string dni, string nombre, string apellido)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura dni
        /// </summary>
        public string DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        /// <summary>
        /// Propiedad lectura y escritura nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        /// <summary>
        /// Propiedad lectura y escritura apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// devuelve la informacion del cliente
        /// </summary>
        /// <returns></returns>
        public string devolverInformacionCliente()
        {
            StringBuilder strCliente = new StringBuilder();
            strCliente.AppendLine("DATOS DEL CLIENTE: ");
            strCliente.AppendLine("DNI: " + this.dni);
            strCliente.AppendLine("Nombre y Apellido: " + this.nombre +" "+ this.apellido);
            strCliente.AppendLine("\n- - - - - - - - - - - - - - - - - - -\n");
            return strCliente.ToString();
        }

        #endregion
    }
}
