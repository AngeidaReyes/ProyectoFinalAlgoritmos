using ProyectoFinalAlgoritmos.Models;
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
    public partial class UsrCtrlMateriaPrima : UserControl
    {
        public event Action<decimal> CostoTotalMateriaPrimaActualizado;
        public UsrCtrlMateriaPrima()
        {
            InitializeComponent();
            dgvMatePrima.ReadOnly = true;
            LeerMateriaPrima();
            Permisos();
            ActualizarTotalInventario();           

            usrCtrlDatosMateriaPrima1.Hide();
            usrCtrlDatosMateriaPrima1.MateriaPrimaGuardado += (s, e) => LeerMateriaPrima();
        }
        public void LeerMateriaPrima()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Unidad");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Minimo");
            dt.Columns.Add("Fecha");

            var repo = new RepositorioMateriaPrima();
            var materiaPrima = repo.ObtenerMateriaPrima();

            var repoTran = new RepositorioTransaccionesMP();            
       
            foreach (var materiaprima in materiaPrima)
            {
                materiaprima.Cantidad = repoTran.ObtenerCantidadActual(materiaprima.Id);
                var row = dt.NewRow();
                row["ID"] = materiaprima.Id;
                row["Nombre"] = materiaprima.Nombre;
                row["Unidad"] = materiaprima.Unidad;
                row["Precio"] = materiaprima.Precio.ToString("C");
                row["Cantidad"] = materiaprima.Cantidad;
                row["Minimo"] = materiaprima.Minimo;
                row["Fecha"] = materiaprima.Fecha.ToShortDateString();

                dt.Rows.Add(row);
            }

            this.dgvMatePrima.DataSource = dt;
            ActualizarTotalInventario();

            DispararCostoActualizado();

        }
        private void ActualizarTotalInventario()
        {
            var repo = new RepositorioMateriaPrima();
            var materiaPrima = repo.ObtenerMateriaPrima();

            var repoMP = new RepositorioTransaccionesMP();
            foreach (var materiaprima in materiaPrima)
            {
                materiaprima.Cantidad = repoMP.ObtenerCantidadActual(materiaprima.Id);
            }

            decimal totalInventario = materiaPrima.Sum(m => m.Precio * m.Cantidad);

            lblTotalInventario.Text = $"Valor total en inventario: {totalInventario:C}";
            lblTotalInventario.Font = new Font(lblTotalInventario.Font, FontStyle.Bold);
            lblTotalInventario.ForeColor = totalInventario > 0 ? Color.DarkGreen : Color.Gray;

            DispararCostoActualizado();
        }

        private void DispararCostoActualizado()
        {
            var repo = new RepositorioMateriaPrima();
            var materiaPrima = repo.ObtenerMateriaPrima();
            decimal costoTotal = materiaPrima.Sum(m => m.Precio * m.Cantidad);
            CostoTotalMateriaPrimaActualizado?.Invoke(costoTotal);
        }

        public void Permisos()
        {
            if (SesionUsuario.TipoUsuario == "Administrador")
            {
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (SesionUsuario.TipoUsuario == "Empleado")
            {
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            usrCtrlDatosMateriaPrima1.LimpiarCampos();
            usrCtrlDatosMateriaPrima1.lblTitulo.Text = "Crear Materia Prima";
            usrCtrlDatosMateriaPrima1.Show();
            usrCtrlDatosMateriaPrima1.BringToFront();
            ActualizarTotalInventario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMatePrima.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione uno para editar.");
                return;
            }

            var valor = dgvMatePrima.SelectedRows[0].Cells["ID"].Value?.ToString(); 
            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("El producto seleccionado no es válido.");
                return;
            }

            int id = int.Parse(valor);
            var repo = new RepositorioMateriaPrima();
            var materiaprima = repo.ObtenerMateriaPrima(id);

            if (materiaprima == null)
            {
                MessageBox.Show("No se encontró la materia prima seleccionada.");
                return;
            }

            usrCtrlDatosMateriaPrima1.EditarMateriaPrima(materiaprima);
            usrCtrlDatosMateriaPrima1.Show();
            usrCtrlDatosMateriaPrima1.BringToFront();
            ActualizarTotalInventario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var valor = dgvMatePrima.SelectedRows[0].Cells[0].Value.ToString();
            if (valor == null || valor.Length == 0)
            {
                
                return;
            }

            int id = int.Parse(valor);

            DialogResult dialogResult = MessageBox.Show("Esta seguro de que desea eliminar esta materia prima?", "Eliminar Materia prima", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var repo = new RepositorioMateriaPrima();
            repo.EliminarMateriaPrima(id);

            LeerMateriaPrima();
            ActualizarTotalInventario();

        }

        private void btnReporteValor_Click(object sender, EventArgs e)
        {

            var repo = new RepositorioMateriaPrima();
            var lista = repo.ObtenerMateriaPrima();

            if (!lista.Any())
            {
                MessageBox.Show("No hay materias primas registradas.", "Reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            var sb = new StringBuilder();

            sb.AppendLine("------REPORTE DE INVENTARIO------");
            sb.AppendLine(new string('=', 65));
            sb.AppendLine($"{"Materia".PadRight(25)} {"Cant.".PadRight(7)} {"Unidad".PadRight(12)} {"Valor"}");
            sb.AppendLine(new string('-', 65));

            decimal granTotal = 0;

            foreach (var m in lista)
            {
                decimal valor = m.Precio * m.Cantidad;
                granTotal += valor;
                sb.AppendLine($"{m.Nombre.PadRight(25)} {m.Cantidad,7:F2} {m.Unidad.PadRight(12)} {valor,12:C}");
            }

            sb.AppendLine(new string('=', 65));
            sb.AppendLine($"{"TOTAL GENERAL:".PadRight(53)} {granTotal,12:C}");

            string reporte = sb.ToString();

            // Esto es para que se guarde en archivo .txt
            try
            {
                string rutaArchivo = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Reporte_Inventario_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
                );

                File.WriteAllText(rutaArchivo, reporte, Encoding.UTF8);

                MessageBox.Show($"Reporte guardado exitosamente:\n{rutaArchivo}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                System.Diagnostics.Process.Start("notepad.exe", rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsrCtrlMateriaPrima_Load(object sender, EventArgs e)
        {

        }
    }
}
