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
    public partial class frmFechasReporte : Form
    {
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        public frmFechasReporte(string nombreProducto)
        {
            InitializeComponent();
            lblNombre.Text = $"Seleccione rango de fechas para: {nombreProducto}";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FechaInicio = dtpInicio.Value.Date;
            FechaFin = dtpFin.Value.Date;

            if (FechaInicio > FechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
