using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Persona
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

        public int DNI { 
            get 
            {
                return ValidarDni(this.nacionalidad, this.dni);
            }
            set 
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            } 
        }

        abstract public ENacionalidad Nacionalidad { get; set; }

        abstract public string Nombre { get; set; }

        abstract public string StringToDNI { set; }
        #endregion

        #region Constructores
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
        #endregion

        #region Metodos
        protected virtual string ToString()
        {
            return "";
        }

        public int ValidarDni(ENacionalidad nacionanidad, int dato)
        {
            if((nacionalidad == ENacionalidad.Argentino && dato > 9000000 && dato < 9999999) || 
            nacionalidad == ENacionalidad.Extranjero && dato > 1 && dato < 8900000)
            {
                //throw new NacionalidadInvalidaException();
            }
            
            return dato;
        }

        public int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            return ValidarDni(nacionalidad,Convert.ToInt32(dato));
        }

        public string validarNombreApellido(string dato) 
        {
            return "";
        }
        #endregion


    }
}
