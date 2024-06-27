using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Patente
    {
        private string _codigoPatente;
        private Tipo _tipoCodigo;

        /// <summary>
        /// Obtiene o establece el código de la patente.
        /// </summary>
        public string CodigoPatente
        {
            get { return _codigoPatente; }
            set { _codigoPatente = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de código de la patente.
        /// </summary>
        public Tipo TipoCodigo
        {
            get { return _tipoCodigo; }
            set { _tipoCodigo = value; }
        }
        /// <summary>
        /// Constructor vacio que inicializa la clase Patente
        /// </summary>
        public Patente() { }

        /// <summary>
        /// Constructor que inicializa la clase Patente y los atributos de Codigo de patente y Tipo de codigo
        /// </summary>
        /// <param name="codigoPatente">El código de la patente.</param>
        /// <param name="tipoPatente">El tipo de la patente.</param>
        public Patente(string codigoPatente, Tipo tipoPatente)
        {
            this._codigoPatente = codigoPatente;
            this._tipoCodigo = tipoPatente;
        }

        /// <summary>
        /// Devuelve una cadena que representa la patente actual.
        /// </summary>
        /// <returns>El código de la patente.</returns>
        public override string ToString()
        {
            return _codigoPatente;
        }

    }

}
