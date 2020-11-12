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

        #region Constructores
        /// <summary>
        /// Constructor profesor que inicializa coleccion de clases del dia
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        /// <summary>
        /// Constructor estatico profesor que inicializa random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor profesor que hereda atributos de universitario, inicializa coleccion de clases del dia e inicializa 2 clases random
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id,string nombre,string apellido,string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genera 2 numeros random del 0 al 3 del enumerado EClases
        /// </summary>
        public void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,3));
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,3));
        }

        /// <summary>
        /// Sobreescribe el metodo MostrarDatos : devuelve los datos del profesor con la clase que participa
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Devuelve las clases que participa el profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder strClases = new StringBuilder();
            strClases.AppendLine("CLASES DEL DIA");
            foreach(Universidad.EClases item in this.clasesDelDia)
            {
                strClases.AppendFormat("{0}\n",item);
            }
            return strClases.ToString();
        }

        /// <summary>
        /// Devuelve los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Verifica si el profesor da la clase ingresada
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clase">clase</param>
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
        /// Verifica si el profesor no da la clase ingresada
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
