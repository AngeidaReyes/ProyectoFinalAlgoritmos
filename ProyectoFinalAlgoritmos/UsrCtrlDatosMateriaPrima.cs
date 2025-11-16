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
    public partial class UsrCtrlDatosMateriaPrima : UserControl
    {
        public event EventHandler MateriaPrimaGuardado;
        public UsrCtrlDatosMateriaPrima()
        {
            InitializeComponent();
            txtId.ReadOnly = true;
        }
        private int idMateriaPrima = 0;

        public void EditarMateriaPrima(MateriaPrima materiaprima)
        {
            lblTitulo.Text = "Editar Materia prima";
            LimpiarCampos();

            if (materiaprima != null)
            {
                txtId.Text = materiaprima.Id.ToString();
                txtNombre.Text = materiaprima.Nombre;
                cmbBoxUnidad.Text = materiaprima.Unidad;
                txtPrecio.Text = materiaprima.Precio.ToString();
                nudMinimo.Text = materiaprima.Minimo.ToString();
                dtTimeFecha.Text = materiaprima.Fecha.ToString();

                this.idMateriaPrima = materiaprima.Id;

            }

            var repo = new RepositorioTransaccionesMP();
            materiaprima.Cantidad = repo.ObtenerCantidadActual(materiaprima.Id);
            nudCantidad.Value = materiaprima.Cantidad;
        }
        public void LimpiarCampos()
        {
            idMateriaPrima = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            cmbBoxUnidad.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Text = "";
            nudMinimo.Text = "";
            dtTimeFecha.Text = "";



        }

        private void UsrCtrlDatosMateriaPrima_Load(object sender, EventArgs e)
        {

            cmbBoxUnidad.Items.Clear();
            cmbBoxUnidad.Items.AddRange(new string[]
            {
        "Kilogramos (kg)",
        "Litros (L)",
        "Metros (m)",
        "Unidades (u)",
        "Gramos (g)"
            });

            cmbBoxUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxUnidad.SelectedIndex = 0; // Selección por defecto
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del materia prima es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbBoxUnidad.Text))
            {
                MessageBox.Show("La unidad de medida del materia prima es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio del materia prima debe ser un número válido mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(nudCantidad.Text, out decimal cantidad) || cantidad < 0)
            {
                MessageBox.Show("La cantidad del materia prima debe ser un número entero válido mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(nudMinimo.Text, out decimal minimo) || minimo < 0)
            {
                MessageBox.Show("El minimo de la materia prima debe ser un número entero válido mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(dtTimeFecha.Text, out DateTime fecha))
            {
                MessageBox.Show("La fecha de la materia prima debe ser un número entero válido mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            MateriaPrima materiaprima = new MateriaPrima();
            materiaprima.Id = this.idMateriaPrima;
            materiaprima.Nombre = txtNombre.Text;
            materiaprima.Unidad = cmbBoxUnidad.Text;
            materiaprima.Precio = decimal.Parse(txtPrecio.Text);
            materiaprima.Cantidad = nudCantidad.Value;
            materiaprima.Minimo = nudMinimo.Value;
            materiaprima.Fecha = fecha;


            DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            var repo = new Repositories.RepositorioMateriaPrima();

            if (this.idMateriaPrima == 0)
            {
                repo.AgregarMateriaPrima(materiaprima);
            }
            else
            {
                repo.ActualizarMateriaPrima(materiaprima);
            }

            MateriaPrimaGuardado?.Invoke(this, EventArgs.Empty);



            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
