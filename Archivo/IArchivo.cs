using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    public interface IArchivo
    {
            /// <summary>
            /// Guardar una lista de patentes
            /// </summary>
            /// <param name="datos">La lista de patentes</param>
            /// <returns>True si se guardó correctamente, false en caso contrario</returns>
            bool Guardar(List<Patente> datos);

            /// <summary>
            /// Lee y retorna una lista de patentes
            /// </summary>
            /// <returns>Una lista de patentes</returns>
            List<Patente> Leer();
        

    }
}
