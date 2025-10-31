using ProyectoFinalAlgoritmos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Repositories
{
    public class RepositorioTransacciones
    {
        private readonly string connectionString = "Data Source=100.122.79.72,1433;Initial Catalog=InventarioBD;User ID=Aniana;Password=12345;";

        public List<Transacciones> ObtenerTransacciones()
        {
            var transacciones = new List<Transacciones>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id_transaccion, id_producto , tipo_transaccion, cantidad, comentario, id_usuario, fecha
                         FROM TransaccionesInventario ORDER BY fecha DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transacciones.Add(new Transacciones
                                {
                                    Id = reader.GetInt32(0),
                                    ProductoId = reader.GetInt32(1),
                                    Tipo = reader.GetString(2),
                                    Cantidad = reader.GetInt32(3),
                                    Comentario = reader.GetString(4),
                                    UsuarioId = reader.GetInt32(5),
                                    Fecha = reader.GetDateTime(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener transacciones: " + ex.Message);

            }
            return transacciones;
        }

        public Transacciones ObtenerTransaccion(int idTransaccion)
        {
            Transacciones transaccion = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id_transaccion, id_producto , tipo_transaccion, cantidad, comentario, id_usuario, fecha
                         FROM TransaccionesInventario WHERE id_transaccion = @IdTransaccion";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                transaccion = new Transacciones
                                {
                                    Id = reader.GetInt32(0),
                                    ProductoId = reader.GetInt32(1),
                                    Tipo = reader.GetString(2),
                                    Cantidad = reader.GetInt32(3),
                                    Comentario = reader.GetString(4),
                                    UsuarioId = reader.GetInt32(5),
                                    Fecha = reader.GetDateTime(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener transaccion: " + ex.Message);
            }
            return transaccion;
        }

        public void RegistrarTransaccion(Transacciones transaccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO TransaccionesInventario (id_producto, tipo_transaccion, cantidad, comentario, id_usuario)
                         VALUES (@IdProducto, @Tipo, @Cantidad, @Comentario, @Usuario)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", transaccion.ProductoId);
                    cmd.Parameters.AddWithValue("@Tipo", transaccion.Tipo);
                    cmd.Parameters.AddWithValue("@Cantidad", transaccion.Cantidad);
                    cmd.Parameters.AddWithValue("@Comentario", transaccion.Comentario);
                    cmd.Parameters.AddWithValue("@Usuario", transaccion.UsuarioId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int ObtenerCantidadActual(int idProducto)
        {
            int cantidadActual = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ISNULL(SUM(cantidad), 0) 
                         FROM TransaccionesInventario 
                         WHERE id_producto = @IdProducto";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cantidadActual = (int)cmd.ExecuteScalar();
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error al obtener cantidad actual: " + ex.Message);
            }

            return cantidadActual;
        }

        public DataTable ObtenerReporteTransacciones() { 
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ti.id_transaccion AS 'ID Transacción',
                                    p.nombre_producto AS 'Producto',
                                    ti.tipo_transaccion AS 'Tipo',
                                    ti.cantidad AS 'Cantidad',
                                    ti.fecha AS 'Fecha',
                                    u.nombre AS 'Usuario',
                                    ti.comentario AS 'Comentario'
                             FROM TransaccionesInventario ti
                             JOIN Productos p ON ti.id_producto = p.id_producto
                             JOIN Usuarios u ON ti.id_usuario = u.id_usuario
                             ORDER BY ti.fecha DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener reporte de transacciones: " + ex.Message);
            }
            return dt;
        }
    }
}
