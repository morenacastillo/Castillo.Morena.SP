using System;

namespace Entidades
{
    public class PatenteInvalidaException : Exception
    {

        /// <summary>
        /// Inicializa una instancia de la clase Excepcion cuando la patente no cumple con un formato esperado.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        public PatenteInvalidaException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Inicializa una instancia de la clase Excepcion cuando la patente no cumple con un formato esperado y una referencia a la excepción interna.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual.</param>
        public PatenteInvalidaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
