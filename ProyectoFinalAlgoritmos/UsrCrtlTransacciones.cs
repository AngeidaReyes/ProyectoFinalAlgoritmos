using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalAlgoritmos.Models;
using ProyectoFinalAlgoritmos.Repositories;

namespace ProyectoFinalAlgoritmos
{
    public partial class UsrCrtlTransacciones : UserControl
    {
        public UsrCrtlTransacciones()
        {
            InitializeComponent();
            dgvTransacciones.ReadOnly = true;
            dgvPrima.ReadOnly = true;
            
            LeerTransacciones();           
            LeerTransaccionesMP();

            usrCtrlDatosTransacciones1.Hide();
            usrCtrlTransaccionesMP1.Hide();

            usrCtrlDatosTransacciones1.TransaccionRegistrada += (s, e) => LeerTransacciones();
            usrCtrlTransaccionesMP1.TransaccionRegistradaMP += (s, e) => LeerTransaccionesMP();

        }

        public void LeerTransacciones()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Usuario");

            var repo = new RepositorioTransacciones();
            var transacciones = repo.ObtenerTransacciones();

            foreach (var transaccion in transacciones)
            {
                var row = dt.NewRow();
                row["ID"] = transaccion.Id;
                row["Producto"] = transaccion.ProductoId;
                row["Tipo"] = transaccion.Tipo;
                row["Cantidad"] = transaccion.Cantidad;
                row["Fecha"] = transaccion.Fecha;
                row["Usuario"] = transaccion.UsuarioId;

                dt.Rows.Add(row);
            }

            this.dgvTransacciones.DataSource = dt;

        }
        public void LeerTransaccionesMP()
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("MateriaPrima");
            data.Columns.Add("Tipo");
            data.Columns.Add("Cantidad");
            data.Columns.Add("Fecha");
            data.Columns.Add("Usuario");

            var repoMP = new RepositorioTransaccionesMP(); 
            var transaccionesMP = repoMP.ObtenerTransacciones();

            foreach (var transaccion in transaccionesMP)
            {
                var row = data.NewRow();
                row["ID"] = transaccion.Id;
                row["MateriaPrima"] = transaccion.MateriaPrimaId;
                row["Tipo"] = transaccion.Tipo;
                row["Cantidad"] = transaccion.Cantidad;
                row["Fecha"] = transaccion.Fecha;
                row["Usuario"] = transaccion.UsuarioId;
                data.Rows.Add(row);
            }

            this.dgvPrima.DataSource = data;


        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            usrCtrlDatosTransacciones1.LimpiarCampos();
            usrCtrlDatosTransacciones1.Show();
            usrCtrlDatosTransacciones1.BringToFront();          

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioTransacciones();
            var dt = repo.ObtenerReporteTransacciones();

            using (var wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "ReporteTransacciones");
                ws.Columns().AdjustToContents();

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos de Excel (*.xlsx)|*.xlsx",
                    Title = "Guardar reporte de transacciones",
                    FileName = "ReporteTransacciones.xlsx"
                };

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Reporte guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnRegPrima_Click(object sender, EventArgs e)
        {
            usrCtrlTransaccionesMP1.LimpiarCampos();
            usrCtrlTransaccionesMP1.Show();
            usrCtrlTransaccionesMP1.BringToFront();
        }

        private void btnRepPrima_Click(object sender, EventArgs e)
        {
            var repoMP = new RepositorioTransaccionesMP();
            var dt = repoMP.ObtenerReporteTransacciones();

            using (var wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "RepMateriaPrima");
                ws.Columns().AdjustToContents();

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos de Excel (*.xlsx)|*.xlsx",
                    Title = "Guardar reporte de transacciones",
                    FileName = "ReporteTransacciones_MateriaPrima.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Reporte guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tabTransacciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabTransacciones.SelectedTab == tabPgPrima)
            {
                LeerTransaccionesMP();
            }
        }
    }
}
