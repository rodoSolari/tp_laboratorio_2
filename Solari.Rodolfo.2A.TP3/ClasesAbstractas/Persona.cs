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
        public string Apellido {
            get 
            {
                return this.apellido;
            }
            set 
            {
                if (this.validarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }

        public int DNI { 
            get 
            {
                return this.dni;
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
                if(this.validarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }
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
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI= dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder strPersona = new StringBuilder();
            strPersona.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.nombre, this.apellido);
            strPersona.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);
            return strPersona.ToString();

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
            int datoInt;
            bool esNumerico = int.TryParse(dato, out datoInt);
            if (esNumerico && dato.Length <= 9)
            {
                return ValidarDni(nacionalidad, datoInt);
            }
            else
            {
                throw new DniInvalidoException("Error en el formato numerico o la cantidad de digitos del dni ingresado");
            }
        }

        /// <summary>
        /// Validara que los nombres ingresados sean cadenas con caracteres validos, caso contrario no se cargara
        /// </summary>
        /// <param name="dato">nombre y apellido a validar </param>
        /// <returns></returns>
        private string validarNombreApellido(string dato) 
        {
            string respuesta = null;
            if (Regex.IsMatch(dato,"^[a-zA-Z]"))
            {
                respuesta = dato;
            }
            return respuesta;
        }
        #endregion


    }
}
