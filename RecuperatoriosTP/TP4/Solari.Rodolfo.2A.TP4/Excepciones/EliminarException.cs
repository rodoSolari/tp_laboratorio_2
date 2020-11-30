using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class EliminarException : Exception
    {
        public EliminarException() : base("No se pudo eliminar el libro marcado")
        {

        }
    }
}
