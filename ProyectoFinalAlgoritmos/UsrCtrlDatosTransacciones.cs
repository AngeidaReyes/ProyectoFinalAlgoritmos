using ProyectoFinalAlgoritmos.Models;
using ProyectoFinalAlgoritmos.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAlgoritmos
{
    public partial class UsrCtrlDatosTransacciones : UserControl
    {
        public event EventHandler TransaccionRegistrada;
        public UsrCtrlDatosTransacciones()
        {
            InitializeComponent();
            CargarProductos();
                        
            txtId.ReadOnly = true;
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
        }

        private void CargarProductos()
        {
            var repo = new RepositorioProductos();
            var productos = repo.ObtenerProductos();

            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            cmbProducto.SelectedIndex = -1;
        }

        public void LimpiarCampos()
        {
            cmbProducto.SelectedIndex = -1;
            nudCantidad.Value = 0;
            txtComentario.Clear();
            cmbTipoTransaccion.SelectedIndex = -1;
            lblCantidadActual.Text = "--";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1 || cmbTipoTransaccion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto y un tipo de transacción.");
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.");
                return;
            }

            var producto = cmbProducto.SelectedItem as Productos;
            if (producto == null)
            {
                MessageBox.Show("Producto inválido.");
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            string tipo = cmbTipoTransaccion.SelectedItem.ToString();

            
            if (tipo == "Salida" && cantidad > 0)
            {
                var repoTransacciones = new RepositorioTransacciones();
                int stockActual = repoTransacciones.ObtenerCantidadActual(producto.Id);

                if (cantidad > stockActual)
                {
                    MessageBox.Show($"Stock insuficiente. Solo hay {stockActual} unidades disponibles.");
                    return;
                }
                cantidad *= -1;
            }

            Models.Transacciones transaccion = new Models.Transacciones
            {
                ProductoId = producto.Id,
                Cantidad = cantidad,
                UsuarioId = SesionUsuario.IdUsuario,
                Comentario = txtComentario.Text,
                Tipo = tipo
            };

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea registrar esta transacción?", "Confirmar", MessageBoxButtons.YesNo);
            if (resultado != DialogResult.Yes)
            {
                return;
            }

            var repo = new RepositorioTransacciones();
            repo.RegistrarTransaccion(transaccion);
            MessageBox.Show("Transacción registrada exitosamente.");

            TransaccionRegistrada?.Invoke(this, EventArgs.Empty);

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var producto = cmbProducto.SelectedItem as Productos;

            if (producto != null)
            {
                var repo = new RepositorioTransacciones();
                int cantidadActual = repo.ObtenerCantidadActual(producto.Id);

                lblCantidadActual.Text = $"{cantidadActual}";
            }
            else
            {
                lblCantidadActual.Text = "--";
            }
        }
    }
}
