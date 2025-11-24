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
    public partial class UserCtrlCatalogo : UserControl
    {
        public UserCtrlCatalogo()
        {
            InitializeComponent();
            
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Botones)
                    ctrl.Visible = false;
            }

            BDproductos obj = new BDproductos();
            obj.LlenarBotones(this, txtBuscar.Text);

            panelResultados.Visible = true;

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            panelResultados.Controls.Clear();
            panelResultados.Visible = false;
            txtBuscar.Text = "";

            List<Control> controlesAEliminar = new List<Control>();
            
                foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Botones)
                    controlesAEliminar.Add(ctrl);
            }
            foreach (Control ctrl in controlesAEliminar)
            {
                this.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            BDproductos obj = new BDproductos();
            obj.LlenarBotones(this);
        }
        private void UserCtrlCatalogo_Load(object sender, EventArgs e)
        {
            panelResultados.Visible = false;
            BDproductos obj = new BDproductos();
            obj.LlenarBotones(this);

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            panelResultados.Visible = true;
            BDproductos bd = new BDproductos();
            bd.LlenarBotonesOrdenados(this, txtBuscar.Text);
        }
    }
}
