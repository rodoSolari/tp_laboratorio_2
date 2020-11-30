using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivo<T>
    {
        #region Metodos
        bool Leer(string archivo, out T datos);

        bool Guardar(string archivo, T datos);
        #endregion
    }
}
