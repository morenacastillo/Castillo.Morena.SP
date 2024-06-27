using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Archivo
{
    public class Sql : IArchivo
    {
        private SqlCommand _comando;
        private SqlConnection _conexion;

        /// <summary>
        /// Inicializa la conexión a la base de datos
        /// </summary>
        public Sql()
        {
            _conexion = new SqlConnection("Data Source=DESKTOP-8R4GR3G\\SQLEXPRESS;Initial Catalog=lab_sp;Integrated Security=True");
            _comando = new SqlCommand();
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.Connection = _conexion;
        }

        /// <summary>
        /// Guarda la lista de patentes en la base de datos
        /// </summary>
        /// <param name="datos">La lista de patentes a guardar</param>
        /// <returns>True si se guardo correctamente, false en caso contrario</returns>
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                _conexion.Open();
                foreach (var patente in datos)
                {
                    _comando.CommandText = $"INSERT INTO patentes (patente, tipo) VALUES ('{patente.CodigoPatente}', '{patente.TipoCodigo}')";
                    _comando.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _conexion.Close();
            }
        }

        /// <summary>
        /// Lee la lista de patentes desde la base de datos
        /// </summary>
        /// <returns>Una lista de patentes</returns>
        public List<Patente> Leer()
        {
            List<Patente> patentes = new List<Patente>();
            try
            {
                _conexion.Open();
                _comando.CommandText = "SELECT patente, tipo FROM patentes";
                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patentes.Add(new Patente(reader["patente"].ToString(), (Tipo)Enum.Parse(typeof(Tipo), reader["tipo"].ToString())));
                    }
                }
            }
            catch (Exception)
            {
                return patentes;
                throw;
            }
            finally
            {
                _conexion.Close();
            }
            return patentes;
        }

    }
}
