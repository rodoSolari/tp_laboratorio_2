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
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        private List<Alumno> Alumnos
        {
            get; set;
        }

        private Universidad.EClases Clase { get; set; }

        private Profesor Instructor { get; set; }
        #endregion

        #region Metodos
        public bool Guardar(Jornada jordana)
        {
            Texto ArchivoEscritura = new Texto();
            bool escritura = ArchivoEscritura.Guardar("ArchivoJornada", jordana.ToString());
            return escritura;
        }

        public string Leer()
        {
            Texto ArchivoLectura = new Texto();
            string datos = " ";
            ArchivoLectura.Leer("ArchivoJornada",out datos);
            return datos;
        }

        #endregion

        #region Sobrecarga de metodos
        public override string ToString()
        {
            StringBuilder strJornada = new StringBuilder();
            strJornada.AppendLine(this.instructor.ToString());
            foreach(Alumno item in this.alumnos)
            {
                strJornada.AppendLine(item.ToString());
            }
            return strJornada.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (j != a)
                {
                    j.alumnos.Add(a);
                }
            }
            return j;
        }
        #endregion
    }
}
