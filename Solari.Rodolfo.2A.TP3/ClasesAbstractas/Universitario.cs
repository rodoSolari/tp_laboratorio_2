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
        protected virtual string MostrarDatos() 
        {
            return base.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de operadores

        public static bool operator ==(Universitario pg1, Universitario pg2) 
        {
            return (pg1.Nacionalidad == pg2.Nacionalidad && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo) );
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

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
