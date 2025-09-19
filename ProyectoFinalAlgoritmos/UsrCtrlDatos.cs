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
                txtCantidad.Text = producto.Cantidad.ToString();

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
            txtCantidad.Text = "";
            picFoto.Image = null; 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Id = this.idProducto;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = decimal.Parse(txtPrecio.Text);
            producto.Cantidad = int.Parse(txtCantidad.Text);
            producto.Fecha = DateTime.Now;

            if (picFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    producto.Foto = ms.ToArray();
                }
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
    }
}
