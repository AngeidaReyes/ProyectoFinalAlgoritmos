using ProyectoFinalAlgoritmos.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAlgoritmos
{
    public partial class UsrCtrlDatos : UserControl
    {
        public event EventHandler RecetaActualizada;
        public event EventHandler ProductoGuardado;

        public UsrCtrlDatos()
        {
            InitializeComponent();
            txtId.ReadOnly = true;

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private int idProducto = 0;

        public void EditarProducto(Productos producto)
        {
            lblTitulo.Text = "Editar Producto";
            LimpiarCampos();

            if (producto != null)
            {
                txtId.Text = producto.Id.ToString();
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                txtPrecio.Text = producto.Precio.ToString();
                txtCosto.Text = producto.Costo.ToString();

                this.idProducto = producto.Id;

                if (producto.Foto != null && producto.Foto.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(producto.Foto))
                    {
                        picFoto.Image = Image.FromStream(ms);
                        picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }

                var repo = new RepositorioTransacciones();
                int cantidadActual = repo.ObtenerCantidadActual(producto.Id);
                nudCantidad.Value = cantidadActual;
            }
        }
        public void LimpiarCampos()
        {
            idProducto = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            picFoto.Image = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(nudCantidad.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("La cantidad del producto debe ser un número entero válido mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔹 Calcular costo automáticamente desde receta
            var repo = new RepositorioProductos();
            decimal costoReal = repo.CalcularCostoReal(idProducto);
            decimal precioVenta = costoReal * 1.5m;

            txtCosto.Text = costoReal.ToString("F2");
            txtPrecio.Text = precioVenta.ToString("F2");

            Productos producto = new Productos();
            producto.Id = this.idProducto;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Costo = costoReal;
            producto.Precio = precioVenta;
            producto.Fecha = DateTime.Now;
            producto.Foto = ConvertirImagenABytes(picFoto.Image);

            DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            if (this.idProducto == 0)
            {
                repo.AgregarProducto(producto);
            }
            else
            {
                repo.ActualizarProducto(producto);
            }

            // 🔹 Actualiza costo en BD
            repo.ActualizarCostoProducto(producto.Id, costoReal);

            ProductoGuardado?.Invoke(this, EventArgs.Empty);

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(ofd.FileName);
                picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public static byte[] ConvertirImagenABytes(Image imagen)
        {
            if (imagen == null)
                return null;

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = new Bitmap(imagen)) // Clonamos la imagen
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al convertir la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnReceta_Click(object sender, EventArgs e)
        {
            if (idProducto == 0)
            {
                MessageBox.Show("Guarde el producto primero.");
                return;
            }

            var frm = new FrmRecetaProducto(idProducto);

            // Escuchar cuando se guarda la receta
            frm.RecetaGuardada += (s, ev) =>
            {
                ActualizarCostoYPrecioDesdeReceta();
            };

            frm.ShowDialog();

            // También recalcular al cerrar, por si hubo cambios sin guardar explícitamente
            ActualizarCostoYPrecioDesdeReceta();

        }

        private void ActualizarCostoYPrecioDesdeReceta()
        {
            var repo = new RepositorioProductos();
            decimal costo = repo.CalcularCostoReal(idProducto);
            txtCosto.Text = costo.ToString("F2");
            repo.ActualizarCostoProducto(idProducto, costo);

            decimal precioVenta = costo * 1.5m;
            txtPrecio.Text = precioVenta.ToString("F2");
        }

        public void ActualizarCosto(decimal nuevoCosto)
        {
            txtCosto.Text = nuevoCosto.ToString("C"); // o lblCosto.Text si usas Label
        }
    }
}
