using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class SerializadorXml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos de tipo T en un archivo en formato XML
        /// </summary>
        /// <param name="archivo">nombre y/o ruta de archivo a guardar</param>
        /// <param name="datos">datos de tipo T a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool respuesta = false;
            try
            {
                using (XmlTextWriter archivoEscritura = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(archivoEscritura, datos);
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new ArchivosException();
            }
            return respuesta;
        }

        /// <summary>
        /// Lee los datos de tipo T de una archivo de formato XML
        /// </summary>
        /// <param name="archivo">nombre y/o ruta de archivo a guardar</param>
        /// <param name="datos">variable de tipo T en donde se guardan los datos a leer</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader archivoLectura = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(archivoLectura);
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
