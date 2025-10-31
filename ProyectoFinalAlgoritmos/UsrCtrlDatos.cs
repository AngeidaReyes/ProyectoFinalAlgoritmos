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
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio del producto debe ser un número válido mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo < 0)
            {
                MessageBox.Show("El costo debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Productos producto = new Productos();
            producto.Id = this.idProducto;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = decimal.Parse(txtPrecio.Text);
            producto.Costo = decimal.Parse(txtCosto.Text);            
            producto.Fecha = DateTime.Now;
            producto.Foto = ConvertirImagenABytes(picFoto.Image);

            DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            var repo = new Repositories.RepositorioProductos();

            if(this.idProducto == 0)
            {
                repo.AgregarProducto(producto);
            }
            else { 
                repo.ActualizarProducto(producto);
            }

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

    }
}
