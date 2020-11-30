using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Diccionario : Libro
    {
        #region Atributos
        private string tipoDiccionario;
        #endregion

        #region Constructores
        /// <summary>
        /// constructor diccionario sin parametros
        /// </summary>
        public Diccionario()
        {

        }
        
        /// <summary>
        /// Constructor diccionario parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="cantidadPaginas"></param>
        /// <param name="idioma"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoDiccionario"></param>
        public Diccionario(int id, string nombre, int cantidadPaginas, string idioma, float precio, int stock, string tipoDiccionario) : base(id, nombre, cantidadPaginas, idioma, precio, stock)
        {
            this.tipoDiccionario = tipoDiccionario;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura tipo de diccionario
        /// </summary>
        public string TipoDiccionario
        {
            get
            {
                return this.tipoDiccionario;
            }
            set
            {
                this.tipoDiccionario = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve la informacion del libro cuento
        /// </summary>
        /// <returns></returns>
        public override string devolverInformacionLibro()
        {
            return base.devolverInformacionLibro() + "Tipo de diccionario: " + this.tipoDiccionario;
        }
        #endregion
    }
}
