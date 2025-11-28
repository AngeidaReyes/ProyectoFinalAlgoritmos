using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Repositories
{
    public class RepositorioUsuarios
    {
        private readonly string connectionString = "Data Source=100.122.79.72,1433;Initial Catalog=InventarioBD;User ID=Aniana;Password=12345;";

        public List<Models.Usuarios> ObtenerUsuarios()
        {
            var usuarios = new List<Models.Usuarios>();
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("SELECT id_usuario, nombre, usuario, contrasena, tipo_usuario FROM Usuarios ORDER BY id_usuario DESC", conexion);
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            usuarios.Add(new Models.Usuarios
                            {
                                Id = lector.GetInt32(0),
                                Nombre = lector.GetString(1),
                                Usuario = lector.GetString(2),
                                Contrasena = lector.GetString(3),
                                TipoUsuario = lector.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error al obtener usuarios: " + ex.Message);
            }
            return usuarios;
        }
        
        public Models.Usuarios ObtenerUsuario(int id)
        {
            Models.Usuarios usuario = null;
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("SELECT id_usuario, nombre, usuario, contrasena, tipo_usuario FROM Usuarios WHERE id_usuario = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            usuario = new Models.Usuarios
                            {
                                Id = lector.GetInt32(0),
                                Nombre = lector.GetString(1),
                                Usuario = lector.GetString(2),
                                Contrasena = lector.GetString(3),
                                TipoUsuario = lector.GetString(4)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o mostrar un mensaje)
                Console.WriteLine("Error al obtener usuario: " + ex.Message);
            }
            return usuario;
        }

        public void AgregarUsuario(Models.Usuarios usuario)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("INSERT INTO Usuarios (nombre, usuario, contrasena, tipo_usuario) VALUES (@Nombre, @Usuario, @Contrasena, @TipoUsuario)", conexion);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    comando.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    comando.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al agregar usuario: " + ex.Message);
            }
        }

        public void ActualizarUsuario(Models.Usuarios usuario)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("UPDATE Usuarios SET nombre = @Nombre, usuario = @Usuario, contrasena = @Contrasena, tipo_usuario = @TipoUsuario WHERE id_usuario = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id", usuario.Id);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    comando.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    comando.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error al actualizar usuario: " + ex.Message);
            }
        }
        public void EliminarUsuario(int id)
        {
            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new System.Data.SqlClient.SqlCommand("DELETE FROM Usuarios WHERE id_usuario = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
            }
        }

    }
}
