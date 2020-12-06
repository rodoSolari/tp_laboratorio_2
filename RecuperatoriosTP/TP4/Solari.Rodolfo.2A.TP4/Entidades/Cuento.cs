using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuento : Libro
    {
        #region Atributos
        private int cantidadCapitulos;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor Cuento sin parametros
        /// </summary>
        public Cuento()
        {

        }
        /// <summary>
        /// Constructor cuento parametrizado
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="nombre">nombre</param>
        /// <param name="cantidadPaginas">cantidad de paginas</param>
        /// <param name="idioma">idioma</param>
        /// <param name="precio">precio</param>
        /// <param name="stock">stock</param>
        /// <param name="cantidadCapitulos">cantidad de capitulos</param>
        public Cuento(int id, string nombre, int cantidadPaginas, string idioma, float precio, int stock, int cantidadCapitulos) : base(id,nombre,cantidadPaginas,idioma,precio,stock)
        {
            this.cantidadCapitulos = cantidadCapitulos;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura cantidad capitulos
        /// </summary>
        public int CantidadCapitulos
        {
            get
            {
                return this.cantidadCapitulos;
            }
            set
            {
                this.cantidadCapitulos = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// devuelve la informacion del libro
        /// </summary>
        /// <returns></returns>
        public override string devolverInformacionLibro()
        {
            return base.devolverInformacionLibro() + "Cantidad de capitulos: " + this.cantidadCapitulos;
        }
        #endregion
    }
}
