using ProyectoFinalAlgoritmos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAlgoritmos.Repositories
{
    public class RepositorioMateriaPrima
    {
        private readonly string connectionString = "Data Source=100.122.79.72,1433;Initial Catalog=InventarioBD;User ID=Aniana;Password=12345;";


        public List<MateriaPrima> ObtenerMateriaPrima()
        {
            var materiaPrima = new List<MateriaPrima>();
            try
            {
                using (var conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new SqlCommand(@"
                SELECT id_materiaPrima, nombre_materiaPrima,unidad_materiaPrima, precioUnitario,
                       minimoPermitido, fechaIngreso 
                FROM MateriaPrima 
                ORDER BY id_materiaPrima DESC", conexion);

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            materiaPrima.Add(new MateriaPrima
                            {
                                Id = lector.GetInt32(0),
                                Nombre = lector.GetString(1),
                                Unidad = lector.GetString(2),
                                Precio = lector.GetDecimal(3),
                                Minimo = lector.GetDecimal(4),
                                Fecha = lector.GetDateTime(5),

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener materia prima: " + ex.Message);
            }
            return materiaPrima;
        }

        public MateriaPrima ObtenerMateriaPrima(int id)
        {
            MateriaPrima materiaPrima = null;
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                var comando = new SqlCommand("SELECT id_materiaPrima, nombre_materiaPrima,unidad_materiaPrima, precioUnitario, minimoPermitido, FechaIngreso FROM MateriaPrima WHERE id_materiaPrima = @id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                using (var lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        materiaPrima = new MateriaPrima
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Unidad = lector.GetString(2),
                            Precio = lector.GetDecimal(3),
                            Minimo = lector.GetDecimal(4),
                            Fecha = lector.GetDateTime(5),
                        };
                    }
                }
            }
            return materiaPrima;
        }
        public void AgregarMateriaPrima(MateriaPrima materiaPrima)
        {

            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("INSERT INTO MateriaPrima (nombre_materiaPrima, unidad_materiaPrima, precioUnitario, minimoPermitido, FechaIngreso) VALUES (@Nombre, @Unidad, @Precio, @Minimo, @Fecha)", conexion);
                    comando.Parameters.AddWithValue("@Nombre", materiaPrima.Nombre);
                    comando.Parameters.AddWithValue("@Unidad", materiaPrima.Unidad);
                    comando.Parameters.AddWithValue("@Precio", materiaPrima.Precio);
                    comando.Parameters.AddWithValue("@Minimo", materiaPrima.Minimo);
                    comando.Parameters.AddWithValue("@Fecha", materiaPrima.Fecha);


                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o mostrar un mensaje)
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarMateriaPrima(MateriaPrima materiaPrima)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("UPDATE MateriaPrima SET nombre_materiaPrima = @Nombre, unidad_materiaPrima = @Unidad, precioUnitario = @Precio, minimoPermitido = @Minimo,FechaIngreso= @Fecha WHERE id_materiaPrima = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id", materiaPrima.Id);
                    comando.Parameters.AddWithValue("@Nombre", materiaPrima.Nombre);
                    comando.Parameters.AddWithValue("@Unidad", materiaPrima.Unidad);
                    comando.Parameters.AddWithValue("@Precio", materiaPrima.Precio);
                    comando.Parameters.AddWithValue("@Minimo", materiaPrima.Minimo);
                    comando.Parameters.AddWithValue("@Fecha", materiaPrima.Fecha);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o mostrar un mensaje)
                Console.WriteLine("Error al actualizar materia prima: " + ex.Message);
            }
        }

        public void EliminarMateriaPrima(int id)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("DELETE FROM MateriaPrima WHERE id_materiaPrima = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar materia prima: " + ex.Message);
            }
        }

    }
}
