using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Repositories
{
    public class RepositorioProductos
    {
        private readonly string connectionString = "Data Source=100.122.79.72,1433;Initial Catalog=InventarioBD;User ID=Aniana;Password=12345;";

        public List<Productos> ObtenerProductos()
        {
            var productos = new List<Productos>();
            try
            {
                using (var conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new SqlCommand(@"
                SELECT id_producto, nombre_producto, precio_producto, 
                       descripcion_producto, foto_producto, fecha_creacion, costo_producto 
                FROM Productos 
                ORDER BY id_producto DESC", conexion);

                    using (var lector = comando.ExecuteReader())
                    {
                        // Obtener índice seguro de la columna binaria
                        int idxFoto = lector.GetOrdinal("foto_producto");

                        while (lector.Read())
                        {
                            byte[] foto = null;

                            if (!lector.IsDBNull(idxFoto))
                            {
                                // Validación extra por si el tipo no es exactamente byte[]
                                var valorFoto = lector[idxFoto];
                                if (valorFoto is byte[])
                                    foto = (byte[])valorFoto;
                                else
                                    Console.WriteLine("Advertencia: foto_producto no es del tipo esperado.");
                            }

                            productos.Add(new Productos
                            {
                                Id = lector.GetInt32(0),
                                Nombre = lector.GetString(1),
                                Precio = lector.GetDecimal(2),                                
                                Descripcion = lector.GetString(3),
                                Foto = foto,
                                Fecha = lector.GetDateTime(5),
                                Costo = lector.GetDecimal(6)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }
            return productos;
        }

        public Productos ObtenerProducto(int id)
        {
            Productos producto = null;
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                var comando = new SqlCommand("SELECT id_producto, nombre_producto, precio_producto, descripcion_producto, foto_producto, fecha_creacion, costo_producto FROM Productos WHERE id_producto = @id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                using (var lector = comando.ExecuteReader())
                {
                    int idxFoto = lector.GetOrdinal("foto_producto");

                    if (lector.Read())
                    {
                        byte[] foto = null;

                        if (!lector.IsDBNull(idxFoto))
                        {
                            // Validación extra por si el tipo no es exactamente byte[]
                            var valorFoto = lector[idxFoto];
                            if (valorFoto is byte[])
                                foto = (byte[])valorFoto;
                            else
                                Console.WriteLine("Advertencia: foto_producto no es del tipo esperado.");
                        }

                        producto = new Productos
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Precio = lector.GetDecimal(2),                            
                            Descripcion = lector.GetString(3),
                            Foto = foto,
                            Fecha = lector.GetDateTime(5),
                            Costo = lector.GetDecimal(6)
                        };
                    }
                }
            }
            return producto;
        }


        public void AgregarProducto(Productos producto)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("INSERT INTO Productos (nombre_producto, descripcion_producto, precio_producto, foto_producto, fecha_creacion, costo_producto) VALUES (@Nombre, @Descripcion, @Precio, @Foto, @Fecha, @Costo)", conexion);
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);                    
                    comando.Parameters.AddWithValue("@Fecha", producto.Fecha);
                    comando.Parameters.AddWithValue("@Costo", producto.Costo);

                    if (producto.Foto != null)
                        comando.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = producto.Foto;
                    else
                        comando.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = DBNull.Value;

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o mostrar un mensaje)
                Console.WriteLine("Error al agregar producto: " + ex.Message);                
            }
        }

        public void ActualizarProducto(Productos producto)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("UPDATE Productos SET nombre_producto = @Nombre, descripcion_producto = @Descripcion, precio_producto = @Precio, foto_producto = @Foto, costo_producto = @Costo WHERE id_producto = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id", producto.Id);
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);                    
                    comando.Parameters.AddWithValue("@Foto", (object)producto.Foto ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@Costo", producto.Costo);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o mostrar un mensaje)
                Console.WriteLine("Error al actualizar producto: " + ex.Message);                
            }
        }

        public void EliminarProducto(int id)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("DELETE FROM Productos WHERE id_producto = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto: " + ex.Message);                
            }
        }
    }
}
