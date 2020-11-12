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

        #region Propiedades
        /// <summary>
        /// Propiedad de escritura y lectura alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura jornadas
        /// </summary>
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

        /// <summary>
        /// Propiedad de indexador jornada, el indice debe ser un valor entre cero y la cantidad de jornadas
        /// Lectura : si no supera el limite de los elementos, devuelve la jornada, caso contrario devuelve null
        /// Escritura : Si el indice es uno que exista, lo asigna directamente, y si coincide con la cantidad de jornadas actuales, lo agrega
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                if (i >= this.jornada.Count || i < 0)
                {
                    return null;
                }
                else
                {
                    return this.jornada[i];
                }
            }
            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
                else if (i == this.jornada.Count)
                {
                    this.jornada.Add(value);
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor universidad que inicializa las listas alumnos,jornada y profesores
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda una universidad en un archivo xml
        /// </summary>
        /// <param name="uni">Universidad a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> ArchivoXmlUniversidad = new Xml<Universidad>();
            bool escritura = ArchivoXmlUniversidad.Guardar("Universidad", uni);

            return escritura;
        }

        /// <summary>
        /// Lee un archivo xml que contiene datos de tipo Universidad
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> ArchivoXmlUniversidad = new Xml<Universidad>();
            Universidad UniversidadLeida = new Universidad();
            ArchivoXmlUniversidad.Leer("Universidad",out UniversidadLeida);

            return UniversidadLeida;
        }

        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad a mostrar</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder strJornada = new StringBuilder();
            foreach(Jornada item in uni.jornada)
            {
                strJornada.Append(item.ToString());
            }

            return strJornada.ToString();
        }
        #endregion

        #region Sobrecarga de metodos
        /// <summary>
        /// Sobrecarga metodo ToString que devuelve los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Devuelve true si el alumno esta contenido en la universidad, caso contrario devuelve false
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
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
        /// Devuelve true si el profesor esta contenido en la universidad, caso contrario devuelve false
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
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
        /// Devuelve el profesor que de la clase ingresada, caso contrario devolvera excepcion por no tener profesor de esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega una nueva jornada con la clase ingresada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">clase</param>
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
        /// Agrega alumno a la universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Agregar un profesor a la universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
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
        /// Devuelve true si el alumno no pertenece a la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Devuelve true si el profesor no pertenece a la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Devuelve el profesor que de esa clase ingresada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor prof = new Profesor();
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
