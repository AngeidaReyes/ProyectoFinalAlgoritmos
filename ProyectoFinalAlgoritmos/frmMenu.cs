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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            userControl11.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            userControl11.BringToFront();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCatalogo.Height;
            SidePanel.Top = btnCatalogo.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnProducto.Height;
            SidePanel.Top = btnProducto.Top;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUser.Height;
            SidePanel.Top = btnUser.Top;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnInformacion.Height;
            SidePanel.Top = btnInformacion.Top;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
