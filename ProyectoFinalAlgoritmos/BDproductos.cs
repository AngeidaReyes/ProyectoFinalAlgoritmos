using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos
{
    public class BDproductos
    {
        private int id_producto;
        private string nombreProducto;
        private string descripcion;
        private decimal precio;
        private byte[] imagen;
        private int cantidad;
        private DateTime fecha;

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }


        SqlConnection conexion = new SqlConnection("server=100.122.79.72,1433; database=InventarioBD; User ID=Aniana; Password=12345;");

        public void LlenarBotones(UserCtrlCatalogo Contenedor)
        {
            conexion.Open();
            string transactSql = "Select * from Productos";
            SqlCommand comando = new SqlCommand(transactSql, conexion);
            comando.CommandType = CommandType.Text;
            SqlDataReader reader = comando.ExecuteReader();

            int x = 10; // margen inicial X
            int y = 10; // margen inicial Y
            int spacing = 40; // espacio entre botones
            

            while (reader.Read())
            {
                int idxFoto = reader.GetOrdinal("foto_producto");
                byte[] foto = null;

                if (!reader.IsDBNull(idxFoto))
                {
                    // Validación extra por si el tipo no es exactamente byte[]
                    var valorFoto = reader[idxFoto];
                    if (valorFoto is byte[])
                        foto = (byte[])valorFoto;
                    else
                        Console.WriteLine("Advertencia: foto_producto no es del tipo esperado.");
                }
                Id_producto = Convert.ToInt32(reader[0]);
                NombreProducto = reader[1].ToString();
                Precio = Convert.ToDecimal(reader[2]);
                Cantidad = Convert.ToInt32(reader[3]);
                Descripcion = reader[4].ToString();
                Fecha = Convert.ToDateTime(reader[5]);
                Imagen = foto;

                Botones btn = new Botones();
                btn.Id = Id_producto;
                btn.NameProducto = NombreProducto;
                btn.Precio = "$" + Precio.ToString("N2");
                btn.CantidadProducto = Cantidad;
                btn.Descripcion = Descripcion;
                btn.FechaCreacion = Fecha;
                if (Imagen != null && Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(Imagen))
                    {
                        btn.ImgProducto = Image.FromStream(ms);
                    }
                }
                else
                {
                    btn.ImgProducto = null; // o una imagen por defecto si prefieres
                }

                // Establecer tamaño y posición
                btn.Size = new Size(450, 250);
                btn.Location = new Point(x, y);

                // Agregar al contenedor
                Contenedor.Controls.Add(btn);

                // Calcular posición para el siguiente botón
                x += btn.Width + spacing;
                if (x + btn.Width > Contenedor.Width) // salto de línea
                {
                    x = 10;
                    y += btn.Height + spacing;
                }



            }
            conexion.Close();
            conexion.Dispose();

        }

        public void LlenarBotones(UserCtrlCatalogo Contenedor, string nombreFiltro = "", string categoriaFiltro = "")
        {
            conexion.Open();

            string query = "SELECT * FROM Productos WHERE 1=1";
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(nombreFiltro))
            {
                query += " AND nombre_Producto LIKE @nombreProducto";
                parametros.Add(new SqlParameter("@nombreProducto", "%" + nombreFiltro + "%"));
            }

            if (!string.IsNullOrWhiteSpace(categoriaFiltro))
            {
                query += " AND categoria = @categoria";
                parametros.Add(new SqlParameter("@categoria", categoriaFiltro));
            }

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddRange(parametros.ToArray());

            SqlDataReader reader = comando.ExecuteReader();

            // Limpia solo el panel de resultados
            Contenedor.panelResultados.Controls.Clear();

            int x = 10;
            int y = 10;
            int spacing = 10;

            while (reader.Read())
            {
                Id_producto = Convert.ToInt32(reader["Id_producto"]);
                NombreProducto = reader["nombre_producto"].ToString();
                Precio = Convert.ToDecimal(reader["precio_producto"]);
                Cantidad = Convert.ToInt32(reader["cantidad_producto"]);
                Descripcion = reader["descripcion_producto"].ToString();
                Fecha = Convert.ToDateTime(reader["fecha_creacion"]);
                if (reader["foto_producto"] != DBNull.Value)
                {
                    Imagen = (byte[])reader["foto_producto"];
                }
                else
                {
                    Imagen = null;
                }

                Image imagenProducto = null;
                if (Imagen != null && Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(Imagen))
                    {
                        imagenProducto = Image.FromStream(ms);
                    }
                }

                Botones btn = new Botones
                {
                    Id = Id_producto,
                    NameProducto = NombreProducto,
                    Precio = "$" + Precio.ToString("N2"),
                    CantidadProducto = Cantidad,
                    Descripcion = Descripcion,
                    FechaCreacion = Fecha,
                    ImgProducto = imagenProducto,
                    Size = new Size(350, 150),
                    Location = new Point(x, y)                              
               
                };

                // Agrega al panel de resultados
                Contenedor.panelResultados.Controls.Add(btn);

                x += btn.Width + spacing;
                if (x + btn.Width > Contenedor.panelResultados.Width)
                {
                    x = 10;
                    y += btn.Height + spacing;
                }
            }

            reader.Close();
            conexion.Close();
            conexion.Dispose();
        }

        private List<BDproductos> OrdenarPorNombreBurbuja(List<BDproductos> productos)
        {
            for (int i = 0; i < productos.Count - 1; i++)
            {
                for (int j = 0; j < productos.Count - i - 1; j++)
                {
                    if (string.Compare(productos[j].NombreProducto, productos[j + 1].NombreProducto) > 0)
                    {
                        var temp = productos[j];
                        productos[j] = productos[j + 1];
                        productos[j + 1] = temp;
                    }
                }
            }
            return productos;
        }

        public void LlenarBotonesOrdenados(UserCtrlCatalogo Contenedor, string nombreFiltro = "", string categoriaFiltro = "")

        {
            conexion.Open();
            string query = "SELECT * FROM Productos WHERE 1=1";
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(nombreFiltro))
            {
                query += " AND nombre_Producto LIKE @nombreProducto";
                parametros.Add(new SqlParameter("@nombreProducto", "%" + nombreFiltro + "%"));
            }

            if (!string.IsNullOrWhiteSpace(categoriaFiltro))
            {
                query += " AND categoria = @categoria";
                parametros.Add(new SqlParameter("@categoria", categoriaFiltro));

            }




            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddRange(parametros.ToArray());
            SqlDataReader reader = comando.ExecuteReader();

            List<BDproductos> listaProductos = new List<BDproductos>();

            while (reader.Read())
            {
                BDproductos prod = new BDproductos
                {
                    Id_producto = Convert.ToInt32(reader["Id_producto"]),
                NombreProducto = reader["nombre_producto"].ToString(),
                Precio = Convert.ToDecimal(reader["precio_producto"]),
                Cantidad = Convert.ToInt32(reader["cantidad_producto"]),
                Descripcion = reader["descripcion_producto"].ToString(),
                Fecha = Convert.ToDateTime(reader["fecha_creacion"]),
                    Imagen = reader["foto_producto"] != DBNull.Value
        ? (byte[])reader["foto_producto"]
        : null
                };
                listaProductos.Add(prod);
            }

            reader.Close();
            conexion.Close();

            // Ordenar por nombre usando burbuja
            listaProductos = OrdenarPorNombreBurbuja(listaProductos);

            // Mostrar en el contenedor
            Contenedor.panelResultados.Controls.Clear();
            int x = 10, y = 10, spacing = 10;

            foreach (var prod in listaProductos)
            {
                Botones btn = new Botones
                {
                    Id = prod.Id_producto,
                    NameProducto = prod.NombreProducto,
                    Precio = "$" + prod.Precio.ToString("N2"),
                    CantidadProducto = prod.Cantidad,
                    Descripcion = prod.Descripcion,
                    FechaCreacion = prod.Fecha,
                    ImgProducto = prod.Imagen != null
    ? Image.FromStream(new MemoryStream(prod.Imagen))
    : null,
                    Size = new Size(350, 150),
                    Location = new Point(x, y)
                };

                Contenedor.panelResultados.Controls.Add(btn);

                x += btn.Width + spacing;
                if (x + btn.Width > Contenedor.panelResultados.Width)
                {
                    x = 10;
                    y += btn.Height + spacing;
                }
            }
        }




    }
}
