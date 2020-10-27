using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

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
        protected string Apellido { get; set; }

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

        protected ENacionalidad Nacionalidad { get; set; }

        protected string Nombre { get; set; }

        protected string StringToDNI { set; }
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string ToString()
        {
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionanidad"> nacionalidad de la persona </param>
        /// <param name="dato"> dni de la persona a validar </param>
        /// <returns></returns>
        public int ValidarDni(ENacionalidad nacionanidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && dato > 9000000 && dato < 9999999) ||
            (nacionalidad == ENacionalidad.Extranjero && dato > 1 && dato < 8900000))
            {
                throw new NacionalidadInvalidaException();
            }
            else
            {
                return dato;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"> nacionalidad de la persona </param>
        /// <param name="dato"> dni de la persona a validar </param>
        /// <returns></returns>
        public int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            bool esNumerico;
            int datoInt;
            esNumerico = int.TryParse(dato, out datoInt);
            if (esNumerico)
            {
                return ValidarDni(nacionalidad, datoInt);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Validara que los nombres ingresados sean cadenas con caracteres validos, caso contrario no se cargara
        /// </summary>
        /// <param name="dato">nombre y apellido a validar </param>
        /// <returns></returns>
        public string validarNombreApellido(string dato) 
        {
            string respuesta = " ";
            if (Regex.IsMatch(dato,"[^a-zA-Z]"))
            {
                respuesta = dato;
            }
            return respuesta;
        }
        #endregion


    }
}
