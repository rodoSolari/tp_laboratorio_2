using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Libro
    {
        #region Atributos
        private int id;
        private string nombre;
        private int cantidadPaginas;
        private string idioma;
        private float precio;
        private int stock;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura id
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Propiedad lectura y escritura nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Propiedad lectura y escritura cantidad de paginas
        /// </summary>
        public int CantidadPaginas
        {
            get { return this.cantidadPaginas; }
            set { this.cantidadPaginas = value; }
        }

        /// <summary>
        /// Propiedad lectura y escritura idioma
        /// </summary>
        public string Idioma
        {
            get { return this.idioma; }
            set { this.idioma = value; }
        }

        /// <summary>
        /// Propiedad lectura y escritura precio
        /// </summary>
        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        /// <summary>
        /// Propiedad lectura y escritura stock
        /// </summary>
        public int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// constructor libro sin parametros
        /// </summary>
        public Libro()
        {

        }

        /// <summary>
        /// Constructor libro parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="cantidadPaginas"></param>
        /// <param name="idioma"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Libro(int id, string nombre, int cantidadPaginas, string idioma, float precio, int stock)
        {
            this.id = id;
            this.nombre = nombre;
            this.cantidadPaginas = cantidadPaginas;
            this.idioma = idioma;
            this.precio = precio;
            this.stock = stock;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve la informacion del libro
        /// </summary>
        /// <returns></returns>
        public virtual string devolverInformacionLibro()
        {
            StringBuilder strLibro = new StringBuilder();
            strLibro.AppendLine("Nombre : " + this.nombre);
            strLibro.AppendLine("Precio : " + this.precio);
            strLibro.AppendLine("Stock : " + this.stock);
            return strLibro.ToString();
        }

        #endregion 
    }
}
