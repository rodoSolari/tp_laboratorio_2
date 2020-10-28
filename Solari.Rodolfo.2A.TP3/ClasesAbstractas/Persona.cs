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
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Enumerados
        public enum ENacionalidad {
            Argentino,Extranjero
        }
        #endregion

        #region Propiedades
        protected string Apellido {
            get 
            {
                return this.apellido;
            }
            set 
            {
                this.apellido = value;
            }
        }

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

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre { 
            get 
            {
                return this.nombre;
            }
            set 
            {
                this.nombre = value;
            }
        
        }

        public string StringToDNI {
            set 
            {
                this.dni = ValidarDni(this.nacionalidad,value);
            }
        }
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
            this.dni = dni;
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
        public override string ToString()
        {
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionanidad"> nacionalidad de la persona </param>
        /// <param name="dato"> dni de la persona a validar </param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionanidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && dato > 9000000 && dato < 9999999) ||
            (nacionalidad == ENacionalidad.Extranjero && dato > 1 && dato < 8999999))
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
        private int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            bool esNumerico;
            int datoInt;
            esNumerico = int.TryParse(dato, out datoInt);
            if (esNumerico && dato.Length <= 9)
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
        private string validarNombreApellido(string dato) 
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
