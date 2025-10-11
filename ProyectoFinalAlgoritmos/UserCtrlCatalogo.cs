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

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Botones)
                    ctrl.Visible = true;
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
    }
}
