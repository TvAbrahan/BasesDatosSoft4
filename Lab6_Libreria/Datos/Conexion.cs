
using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Lab6_Libreria.Datos
{
    public class Conexion
    {
        private readonly string nombreCadena;

        public Conexion()
        {
            nombreCadena = "Libreria";
        }

        // Crea la conexión con SQL Server
        public SqlConnection CrearConexion()
        {
            ConnectionStringSettings configuracion =
                ConfigurationManager.ConnectionStrings[nombreCadena];

            // Verifica que exista la cadena en App.config
            if (configuracion == null)
            {
                throw new InvalidOperationException(
                    "No se encontró la cadena de conexión 'Libreria' en App.config.");
            }

            return new SqlConnection(configuracion.ConnectionString);
        }
    }
}
