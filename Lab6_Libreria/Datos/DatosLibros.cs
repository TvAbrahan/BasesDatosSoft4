
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Lab6_Libreria.Datos
{
    public class DatosLibros
    {
        private readonly Conexion conexion;

        public DatosLibros()
        {
            conexion = new Conexion();
        }

     
        public DataTable ConsultarLibros(bool soloDisponibles = false)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.CrearConexion())
            {
                using (SqlCommand comando =
                    new SqlCommand("dbo.Libros_Listar", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add(
                        "@SoloDisponibles", SqlDbType.Bit).Value =
                        soloDisponibles;

                    cn.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }

        public int AgregarLibro(string titulo, string autor, int cantidad)
        {
            using (SqlConnection cn = conexion.CrearConexion())
            {
                using (SqlCommand comando =
                    new SqlCommand("dbo.Libros_Agregar", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add(
                        "@Titulo", SqlDbType.NVarChar, -1).Value =
                        (object)titulo ?? DBNull.Value;

                    comando.Parameters.Add(
                        "@Autor", SqlDbType.NVarChar, -1).Value =
                        (object)autor ?? DBNull.Value;

                    comando.Parameters.Add(
                        "@CantidadDisponible", SqlDbType.Int).Value =
                        cantidad;

                    SqlParameter nuevoId = comando.Parameters.Add(
                        "@NuevoId", SqlDbType.Int);

                    nuevoId.Direction = ParameterDirection.Output;

                    cn.Open();
                    comando.ExecuteNonQuery();

                    return Convert.ToInt32(nuevoId.Value);
                }
            }
        }

        public void ActualizarCantidad(int id, int cantidad)
        {
            using (SqlConnection cn = conexion.CrearConexion())
            {
                using (SqlCommand comando =
                    new SqlCommand("dbo.Libros_ActualizarCantidad", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add(
                        "@Id", SqlDbType.Int).Value = id;

                    comando.Parameters.Add(
                        "@CantidadDisponible", SqlDbType.Int).Value =
                        cantidad;

                    cn.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarLibro(int id)
        {
            using (SqlConnection cn = conexion.CrearConexion())
            {
                using (SqlCommand comando =
                    new SqlCommand("dbo.Libros_Eliminar", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add(
                        "@Id", SqlDbType.Int).Value = id;

                    cn.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
