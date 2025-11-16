using ProyectoFinalAlgoritmos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Repositories
{
    public class RepositorioReceta
    {
        private readonly string connectionString = "Data Source=100.122.79.72,1433;Initial Catalog=InventarioBD;User ID=Aniana;Password=12345;";

        public void AgregarMateriaAProducto(int productoId, int materiaPrimaId, decimal cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");

            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                var checkCmd = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM RecetaProducto 
                    WHERE ProductoId = @ProductoId AND MateriaPrimaId = @MateriaId", conexion);
                checkCmd.Parameters.AddWithValue("@ProductoId", productoId);
                checkCmd.Parameters.AddWithValue("@MateriaId", materiaPrimaId);

                int existe = (int)checkCmd.ExecuteScalar();

                if (existe > 0)
                {
                    var updateCmd = new SqlCommand(@"
                        UPDATE RecetaProducto 
                        SET CantidadRequerida = CantidadRequerida + @Cantidad 
                        WHERE ProductoId = @ProductoId AND MateriaPrimaId = @MateriaId", conexion);
                    updateCmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    updateCmd.Parameters.AddWithValue("@ProductoId", productoId);
                    updateCmd.Parameters.AddWithValue("@MateriaId", materiaPrimaId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    var insertCmd = new SqlCommand(@"
                        INSERT INTO RecetaProducto (ProductoId, MateriaPrimaId, CantidadRequerida)
                        VALUES (@ProductoId, @MateriaId, @Cantidad)", conexion);
                    insertCmd.Parameters.AddWithValue("@ProductoId", productoId);
                    insertCmd.Parameters.AddWithValue("@MateriaId", materiaPrimaId);
                    insertCmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        // Cargar materias de un producto (para el grid)
        public List<Receta> ObtenerRecetaPorProducto(int productoId)
        {
            var lista = new List<Receta>();

            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                var cmd = new SqlCommand(@"
    SELECT 
        rp.Id,
        rp.ProductoId,
        rp.MateriaPrimaId,
        rp.CantidadRequerida,
        mp.nombre_materiaPrima,
        mp.precioUnitario
    FROM RecetaProducto rp
    INNER JOIN MateriaPrima mp ON rp.MateriaPrimaId = mp.id_materiaPrima
    WHERE rp.ProductoId = @ProductoId", conexion);


                cmd.Parameters.AddWithValue("@ProductoId", productoId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var receta = new Receta
                        {
                            Id = reader.GetInt32(0),
                            ProductoId = reader.GetInt32(1),
                            MateriaPrimaId = reader.GetInt32(2),
                            CantidadRequerida = reader.GetDecimal(3),
                            NombreMateria = reader.GetString(4),
                            PrecioUnitarioMateria = reader.GetDecimal(5)
                            // CostoParcial se calcula automáticamente en el modelo
                        };

                        lista.Add(receta);
                    }
                }
            }

            return lista;
        }

        public void EliminarMateriaDeProducto(int recetaId)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                var cmd = new SqlCommand("DELETE FROM RecetaProducto WHERE Id = @Id", conexion);
                cmd.Parameters.AddWithValue("@Id", recetaId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
