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
    public partial class FrmRecetaProducto : Form
    {
        private int productoId;
        private RepositorioReceta repoReceta;
        private RepositorioMateriaPrima repoMateria;

        // Es para avisar que se guardó la receta
        public event EventHandler RecetaGuardada;

        public FrmRecetaProducto(int productoId)
        {
            InitializeComponent();
            this.productoId = productoId;
            repoReceta = new RepositorioReceta();
            repoMateria = new RepositorioMateriaPrima();
            CargarComboMaterias();
            ConfigurarGrid();
            RefrescarGrid();
        }

        private void CargarComboMaterias()
        {
            var repoMateria = new RepositorioMateriaPrima();
            var materias = repoMateria.ObtenerMateriaPrima();
            cmbMateria.DataSource = materias;
            cmbMateria.DisplayMember = "Nombre";
            cmbMateria.ValueMember = "Id";
        }

        private void ConfigurarGrid()
        {
            dgvReceta.Columns.Clear();
            dgvReceta.Columns.Add("Id", "ID");
            dgvReceta.Columns.Add("NombreMateria", "Materia Prima");
            dgvReceta.Columns.Add("Cantidad", "Cantidad");
            dgvReceta.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvReceta.Columns.Add("CostoParcial", "Costo Parcial");

            var colEliminar = new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            dgvReceta.Columns.Add(colEliminar);

           
            dgvReceta.CellContentClick += dgvReceta_CellContentClick;

           
            dgvReceta.AllowUserToAddRows = false;
            dgvReceta.ReadOnly = true;
            dgvReceta.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbMateria.SelectedItem is MateriaPrima materiaSeleccionada && nudCantidad.Value > 0)
            {
                var materiaId = materiaSeleccionada.Id;
                var cantidad = nudCantidad.Value;

                try
                {
                    repoReceta.AgregarMateriaAProducto(productoId, materiaId, cantidad);
                    RefrescarGrid();
                    RecalcularCostoTotal();
                    RecetaGuardada?.Invoke(this, EventArgs.Empty);

                    cmbMateria.SelectedIndex = 0;
                    nudCantidad.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una materia y una cantidad válida.");
            }

        }

        private void RefrescarGrid()
        {
            dgvReceta.Rows.Clear();
            var receta = repoReceta.ObtenerRecetaPorProducto(productoId);
            foreach (var item in receta)
            {
                dgvReceta.Rows.Add(
                    item.Id,
                    item.NombreMateria,
                    item.CantidadRequerida,
                    item.PrecioUnitarioMateria.ToString("C"),
                    item.CostoParcial.ToString("C")
                );
            }
        }

        private void RecalcularCostoTotal()
        {
            var repoProductos = new RepositorioProductos();
            decimal costo = repoProductos.CalcularCostoReal(productoId);
            lblCostoTotal.Text = $"Costo Total: {costo:C}";
        }

        private void dgvReceta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 && e.ColumnIndex == dgvReceta.Columns["Eliminar"].Index)
            {
                var celdaId = dgvReceta.Rows[e.RowIndex].Cells["Id"].Value;

                if (celdaId != null && int.TryParse(celdaId.ToString(), out int idReceta))
                {
                    repoReceta.EliminarMateriaDeProducto(idReceta);
                    RefrescarGrid();
                    RecalcularCostoTotal();
                    RecetaGuardada?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID de la receta para eliminar.");
                }
            }


        }
    }
}
