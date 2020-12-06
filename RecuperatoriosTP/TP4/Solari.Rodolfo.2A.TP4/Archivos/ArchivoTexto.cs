using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivoTexto<T> : IArchivo<string>
    {
        /// <summary>
        /// Guardar los datos en un archivo de tipo texto
        /// </summary>
        /// <param name="archivo">nombre y/o ruta de archivo del archivo a guardar</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo,string datos)
        {
            try
            {
                using (StreamWriter archivoEscritura = new StreamWriter(archivo, true))
                {
                    archivoEscritura.WriteLine(datos);
                    archivoEscritura.WriteLine("Horario :" + DateTime.Now);
                    return true;
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
        }

        /// <summary>
        /// devuelve bool si se leyo el archivo, casop contrario devuelve false
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader archivoLectura = new StreamReader(archivo))
                {
                    datos = archivoLectura.ReadToEnd();
                }
                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
        }
    }
}
