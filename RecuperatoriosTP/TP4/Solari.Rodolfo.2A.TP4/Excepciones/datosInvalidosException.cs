using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class datosInvalidosException : Exception
    {
        public datosInvalidosException() : base("Error al ingresar datos cliente")
        {

        }
    }
}
