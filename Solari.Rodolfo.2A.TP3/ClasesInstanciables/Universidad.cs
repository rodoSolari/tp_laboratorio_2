using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion,Laboratorio,Legislacion,SPD
        }
        #endregion

        #region Constructores
        public Universidad()
        {

        }
        #endregion

        #region Propiedades
        private List<Alumno> Alumnos { get; set; }
        private List<Profesor> Instructores { get; set; }
        private List<Jornada> Jornadas { get; set; }
     
        private Jornada this[int i] { 
            get 
            {
                return this.jornada[i];
            } 
            set 
            {
                this.jornada[i] = value;
            } 
        }
        #endregion

        #region Metodos
        public bool Guardar()
        {
            return true;
        }

        public Universidad Leer()
        {
            return this;
        }

        private static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool respuesta = false;
            foreach(Alumno item in g.alumnos) 
            {
                if(item == a)
                {
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool respuesta = false;
            foreach(Profesor item in g.profesores)
            {
                if (item == i)
                {
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }

        public static bool operator ==(Universidad u, EClases clase)
        {
            bool respuesta = false;
            foreach(EClases item in u.jornada)
            {
                if (item == clase)
                {
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }

        public static bool operator +(Universidad g, EClases clase)
        {

        }

        public static bool operator +(Universidad g, Alumno a)
        {

        }

        public static bool operator +(Universidad g, Profesor i)
        {

        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static bool operator !=(Universidad g, EClases clase)
        {
            return !(g == clase);
        }
        #endregion
    }
}
