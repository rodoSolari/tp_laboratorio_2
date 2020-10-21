using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructor
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
        {

        }
        #endregion

        #region Propiedades
        private List<Alumno> Alumnos
        {
            get; set;
        }

        private EClases Clase { get; set; }

        private Profesor Instructor { get; set; }
        #endregion

        #region Metodos
        public bool Guardar(Jornada jordana)
        {
            return true;
        }

        public string Leer()
        {
            return "";
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
                else
                {
                    
                }
            }
            return j;
        }
        #endregion
    }
}
