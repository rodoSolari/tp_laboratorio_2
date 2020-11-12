using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        #region Metodos
        /// <summary>
        /// Guardar los datos en un archivo de tipo texto
        /// </summary>
        /// <param name="archivo">nombre y/o ruta de archivo del archivo a guardar</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter archivoEscritura = new StreamWriter(archivo,true))
                {
                    archivoEscritura.WriteLine(datos);
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }


        /// <summary>
        /// Lee los datos de un archivo de formato texto
        /// </summary>
        /// <param name="archivo">nombre y/o ruta de archivo a leer</param>
        /// <param name="datos">variable en donde se guardan los datos a leer</param>
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
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        #endregion
    }
}
