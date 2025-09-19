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
                Id_producto = Convert.ToInt32(reader[0]);
                NombreProducto = reader[1].ToString();
                Precio = Convert.ToDecimal(reader[2]);
                Cantidad = Convert.ToInt32(reader[3]);
                Descripcion = reader[4].ToString();
                Fecha = Convert.ToDateTime(reader[5]);
                Imagen = ((byte[])reader[6]);

                Botones btn = new Botones();
                btn.Id = Id_producto;
                btn.NameProducto = NombreProducto;
                btn.Precio = "$" + Precio.ToString("N2");
                btn.CantidadProducto = Cantidad;
                btn.Descripcion = Descripcion;
                btn.FechaCreacion = Fecha;
                MemoryStream ms = new MemoryStream(Imagen);
                btn.ImgProducto = Image.FromStream(ms);

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
    }
}
