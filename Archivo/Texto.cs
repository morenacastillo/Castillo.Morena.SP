using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Archivo
{
    public class Texto : IArchivo
    {
        /// <summary>
        /// Guarda la lista de patentes en un archivo txt
        /// </summary>
        /// <param name="datos">la lista de patentes a guardar</param>
        /// <returns>True si se guardó correctamente, false en caso contrario</returns>
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.txt");
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var patente in datos)
                    {
                        writer.WriteLine($"{patente.CodigoPatente},{patente.TipoCodigo}");
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// lee la lista de patentes desde un archivo txt
        /// </summary>
        /// <returns>Una lista de patentes</returns>
        public List<Patente> Leer()
        {
            List<Patente> patentes = new List<Patente>();
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.txt");
                using (StreamReader reader = new StreamReader(path))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        
                        patentes.Add(new Patente(datos[0], (Tipo)Enum.Parse(typeof(Tipo), datos[1])));
                        
                    }
                }
            }

            catch (Exception)
            {
                return new List<Patente>();
            }
            return patentes;
        }
    }
}
