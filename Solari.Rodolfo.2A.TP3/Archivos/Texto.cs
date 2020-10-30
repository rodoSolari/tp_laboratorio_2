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
    }
}
