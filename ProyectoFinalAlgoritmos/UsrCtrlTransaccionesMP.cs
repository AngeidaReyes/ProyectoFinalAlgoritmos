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
    public partial class UsrCtrlTransaccionesMP : UserControl
    {
        public event EventHandler TransaccionRegistradaMP;
        public UsrCtrlTransaccionesMP()
        {
            InitializeComponent();
            CargarMateriaPrima();
            txtId.ReadOnly = true;

        }
        private void CargarMateriaPrima()
        {
            var repo = new RepositorioMateriaPrima();
            var productos = repo.ObtenerMateriaPrima();

            cmbPrima.DataSource = productos;
            cmbPrima.DisplayMember = "Nombre";
            cmbPrima.ValueMember = "Id";
            cmbPrima.SelectedIndex = -1;
        }

        public void LimpiarCampos()
        {
            cmbPrima.SelectedIndex = -1;
            nudCantidad.Value = 0;
            txtComentario.Clear();
            cmbTipoTransaccion.SelectedIndex = -1;
            lblCantidadActual.Text = "--";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbPrima.SelectedIndex == -1 || cmbTipoTransaccion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una materia prima y un tipo de transacción.");
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.");
                return;
            }

            var materia = cmbPrima.SelectedItem as MateriaPrima;
            if (materia == null)
            {
                MessageBox.Show("Materia prima inválida.");
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            string tipo = cmbTipoTransaccion.SelectedItem.ToString();


            if (tipo == "Salida" && cantidad > 0)
            {
                var repoTransacciones = new RepositorioTransaccionesMP();
                int stockActual = repoTransacciones.ObtenerCantidadActual(materia.Id);

                if (cantidad > stockActual)
                {
                    MessageBox.Show($"Stock insuficiente. Solo hay {stockActual} unidades disponibles.");
                    return;
                }
                cantidad *= -1;
            }

            Models.TransaccionesMP transaccion = new Models.TransaccionesMP
            {
                MateriaPrimaId = materia.Id,
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

            var repo = new RepositorioTransaccionesMP();
            repo.RegistrarTransaccionMP(transaccion);
            MessageBox.Show("Transacción registrada exitosamente.");

            TransaccionRegistradaMP?.Invoke(this, EventArgs.Empty);

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbPrima_SelectedIndexChanged(object sender, EventArgs e)
        {
            var materia = cmbPrima.SelectedItem as MateriaPrima;

            if (materia != null)
            {
                var repo = new RepositorioTransaccionesMP();
                int cantidadActual = repo.ObtenerCantidadActual(materia.Id);

                lblCantidadActual.Text = $"{cantidadActual}";
            }
            else
            {
                lblCantidadActual.Text = "--";
            }
        }
    }
}
