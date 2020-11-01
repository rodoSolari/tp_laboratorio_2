using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructor
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Propiedades
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

        public Universidad.EClases Clase {
            get
            {
                return this.clase;
            }
            set 
            {
                this.clase = value;
            }
        }

        public Profesor Instructor { 
            get 
            {
                return this.instructor;
            }
            set 
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda la jornada en un archivo de formato .txt
        /// </summary>
        /// <param name="jordana"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jordana)
        {
            Texto ArchivoEscritura = new Texto();
            bool escritura = ArchivoEscritura.Guardar("ArchivoJornada.txt", jordana.ToString());
            return escritura;
        }

        /// <summary>
        /// Lee el archivo de la jornada en formato .txt
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto ArchivoLectura = new Texto();
            string datos;
            ArchivoLectura.Leer(@"\ArchivoJornada.txt",out datos);
            return datos;
        }

        #endregion

        #region Sobrecarga de metodos
        /// <summary>
        /// Devuelve los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder strJornada = new StringBuilder();
            strJornada.AppendFormat("CLASE DE: {0} POR {1}", this.clase,this.instructor.ToString());
            strJornada.AppendLine("\nALUMNOS:");
            foreach(Alumno item in this.alumnos)
            {
                strJornada.AppendLine(item.ToString());

            }
            return strJornada.ToString();
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Verifica que el alumno participa en dicha jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            bool respuesta = false;
            foreach (Alumno item in j.alumnos)
            {
                if (a.Equals(item))
                {
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Verifica que el alumno no participe en dicha jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega al alumno en la jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
