using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

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
        public List<Alumno> Alumnos { 
            get 
            {
                return this.alumnos;
            }
            set 
            {
                this.alumnos = value;
            } 
        }

        public List<Profesor> Instructores {
            get 
            {
                return this.profesores;
            }
            set 
            {
                this.profesores = value;
            } 
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
     
        public Jornada this[int i] { 
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Guardar(Universidad uni)
        {
            Xml<Universidad> ArchivoXmlUniversidad = new Xml<Universidad>();
            bool escritura = ArchivoXmlUniversidad.Guardar("ArchivoXmlUniversidad", uni);

            return escritura;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> ArchivoXmlUniversidad = new Xml<Universidad>();
            Universidad UniversidadLeida = new Universidad();
            ArchivoXmlUniversidad.Leer("ArchivoXmlUniversidad",out UniversidadLeida);

            return UniversidadLeida;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder strJornada = new StringBuilder();
            strJornada.AppendLine("JORNADA:");
            foreach(Jornada item in uni.jornada)
            {
                strJornada.AppendLine(item.ToString());
            }
            return strJornada.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor prof = u == clase;    //Utilizo la sobrecarga de operador ==
            if (prof == clase)
            {
                return prof;
            }
            else
            {
                throw new SinProfesorException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase); // utilizo la sobrecarga de operador ==
            foreach(Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    nuevaJornada += item;   //utilizo sobrecarga de operador + de jornada
                }
            }
            g.jornada.Add(nuevaJornada);
            return g;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor prof = null;
            foreach(Profesor item in u.profesores)
            {
                if(item != clase)
                {
                    prof = item;
                    break;
                }
            }
            return prof;
        }
        
        #endregion
    }
}
