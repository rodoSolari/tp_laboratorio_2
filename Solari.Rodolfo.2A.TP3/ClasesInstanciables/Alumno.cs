using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Enumerados
        public enum EEstadoCuenta
        {
            AlDia,Deudor,Becado
        }
        #endregion

        #region Constructores
        public Alumno() 
        {
        
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nESTADO DE LA CUENTA : " + this.estadoCuenta + this.ParticiparEnClase() + "\n";
        }
        #endregion


        #region Sobrecarga de metodos
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase) 
        {
            return !(a == clase);
        }
        #endregion
    }
}
