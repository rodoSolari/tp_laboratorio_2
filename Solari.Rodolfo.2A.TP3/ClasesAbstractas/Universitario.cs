using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        public Universitario() 
        {
        
        }

        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Devuelve los datos del universitario con su numero de legajo
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos() 
        {
            StringBuilder strUniversitario = new StringBuilder();
            strUniversitario.AppendLine(base.ToString());
            strUniversitario.AppendFormat("NUMERO DE LEGAJO: {0}\n", this.legajo);
            return strUniversitario.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2) 
        {
            return (pg1.Nacionalidad == pg2.Nacionalidad && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool rta = false;
            if (obj is Universitario)
            {
                rta = this == (Universitario)obj;
            }
            return rta;
        }

        #endregion

    }
}
