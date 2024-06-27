using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivo
{
    public class Xml : IArchivo
    {
        /// <summary>
        /// guarda la lista de patentes en un archivo XML
        /// </summary>
        /// <param name="datos">la lista de patentes a guardar</param>
        /// <returns>true si se guardó correctamente, false en caso contrario</returns>
        public bool Guardar(List<Patente> datos)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, datos);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// lee la lista de patentes desde un archivo XML
        /// </summary>
        /// <returns>una lista de patentes</returns>
        public List<Patente> Leer()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                using (StreamReader reader = new StreamReader(path))
                {
                    return (List<Patente>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                return new List<Patente>();
            }
        }
    
}
}
