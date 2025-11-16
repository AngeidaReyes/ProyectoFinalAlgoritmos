using ProyectoFinalAlgoritmos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAlgoritmos.Repositories
{
    public class RepositorioTransaccionesMP
    {
        private readonly string connectionString = "Data Source=100.122.79.72,1433;Initial Catalog=InventarioBD;User ID=Aniana;Password=12345;";

        public List<TransaccionesMP> ObtenerTransacciones()
        {
            var transacciones = new List<TransaccionesMP>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id_transaccionMP, id_materiaPrima , tipo_transaccion, cantidad, comentario, id_usuario, fecha
                         FROM TransaccionesMateriaPrima ORDER BY fecha DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var transaccion = new TransaccionesMP
                                {
                                    Id = Convert.ToInt32(reader["id_transaccionMP"]),
                                    MateriaPrimaId = Convert.ToInt32(reader["id_materiaPrima"]),
                                    Tipo = reader["tipo_transaccion"]?.ToString() ?? "",
                                    Cantidad = Convert.ToInt32(reader["cantidad"]),
                                    Comentario = reader["comentario"]?.ToString() ?? "",
                                    UsuarioId = Convert.ToInt32(reader["id_usuario"]),
                                    Fecha = reader["fecha"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["fecha"])
                                };

                                transacciones.Add(transaccion);
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

        public TransaccionesMP ObtenerTransaccion(int idTransaccion)
        {
            TransaccionesMP transaccion = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id_transaccionMP, id_materiaPrima , tipo_transaccion, cantidad, comentario, id_usuario, fecha
                         FROM TransaccionesMateriaPrima WHERE id_transaccionMP = @IdTransaccion";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                transaccion = new TransaccionesMP
                                {
                                    Id = Convert.ToInt32(reader["id_transaccionMP"]),
                                    MateriaPrimaId = Convert.ToInt32(reader["id_materiaPrima"]),
                                    Tipo = reader["tipo_transaccion"]?.ToString() ?? "",
                                    Cantidad = Convert.ToInt32(reader["cantidad"]),
                                    Comentario = reader["comentario"]?.ToString() ?? "",
                                    UsuarioId = Convert.ToInt32(reader["id_usuario"]),
                                    Fecha = reader["fecha"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["fecha"])
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

        public void RegistrarTransaccionMP(TransaccionesMP transaccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO TransaccionesMateriaPrima (id_materiaPrima, tipo_transaccion, cantidad, comentario, id_usuario)
                         VALUES (@IdMateriaPrima, @Tipo, @Cantidad, @Comentario, @Usuario)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdMateriaPrima", transaccion.MateriaPrimaId);
                    cmd.Parameters.AddWithValue("@Tipo", transaccion.Tipo);
                    cmd.Parameters.AddWithValue("@Cantidad", transaccion.Cantidad);
                    cmd.Parameters.AddWithValue("@Comentario", transaccion.Comentario);
                    cmd.Parameters.AddWithValue("@Usuario", transaccion.UsuarioId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int ObtenerCantidadActual(int idMateriaPrima)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ISNULL(SUM(cantidad), 0) 
                             FROM TransaccionesMateriaPrima 
                             WHERE id_materiaPrima = @MateriaPrimaId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MateriaPrimaId", idMateriaPrima);
                        object result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cantidad actual: " + ex.Message);
                return 0;
            }
        }

        public DataTable ObtenerReporteTransacciones()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ti.id_transaccionMP AS 'ID Transacción',
                                    mp.nombre_materiaPrima AS 'Materia Prima',
                                    ti.tipo_transaccion AS 'Tipo',
                                    ti.cantidad AS 'Cantidad',
                                    ti.fecha AS 'Fecha',
                                    u.nombre AS 'Usuario',
                                    ti.comentario AS 'Comentario'
                             FROM TransaccionesMateriaPrima ti
                             JOIN MateriaPrima mp ON ti.id_materiaPrima = mp.id_materiaPrima
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
