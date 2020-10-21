using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructor
        public Profesor()
        {
            random = new Random();
        }

        static Profesor()
        {

        }

        public Profesor(int id,string nombre,string apellido,string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {

        }
        #endregion

        #region Metodos
        public void _randomClases()
        {

        }

        protected override string MostrarDatos()
        {
            return "";
        }

        protected override string ParticiparEnClase()
        {
            return "";
        }

        protected override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Profesor i, EClases clase)
        {
            return (i.clasesDelDia == clase);
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
