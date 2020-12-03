using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class sinTipoException : Exception
    {
        public sinTipoException() : base("No se ha ingresado el tipo de libro")
        {

        }
    }
}
