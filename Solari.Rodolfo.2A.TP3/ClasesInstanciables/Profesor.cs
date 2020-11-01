using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructor
        public Profesor()
        {

        }

        static Profesor()
        {
            //random = new Random();
        }

        public Profesor(int id,string nombre,string apellido,string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            Profesor.random = new Random();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        public void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,3));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder strClases = new StringBuilder();
            strClases.AppendLine("CLASES DEL DIA \n");
            foreach(Universidad.EClases item in this.clasesDelDia)
            {
                strClases.AppendFormat("{0}\n",item);
            }
            return strClases.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool respuesta = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
