using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    abstract public class Persona
    {
        #region Atributos
        string nombre;
        string apellido;
        ENacionalidad nacionalidad;
        int dni;
        #endregion

        #region Enumerados
        public enum ENacionalidad {
            Argentino,Extranjero
        }
        #endregion

        #region Propiedades
        abstract public string Apellido { get; set; }

        abstract public int DNI { get; set; }

        abstract public ENacionalidad Nacionalidad { get; set; }

        abstract public string Nombre { get; set; }

        abstract public string StringToDNI { set; }
        #endregion

        #region Metodos
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        { 
        
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        { 
        }

        public override string ToString()
        {
            return "";
        }

        public int ValidarDni(ENacionalidad nacionanidad, int dato)
        {
            return 0;
        }

        public int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            return 0;
        }

        public string validarNombreApellido(string dato) 
        {
            return "";
        }
        #endregion


    }
}
