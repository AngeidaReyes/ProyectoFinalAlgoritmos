using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            userCtrlCatalogo1.Hide();

            LLenarProductos();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void LLenarProductos()
        {
            BDproductos obj = new BDproductos();
            obj.LlenarBotones(userCtrlCatalogo1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            userControl11.BringToFront();
            userCtrlCatalogo1.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCatalogo.Height;
            SidePanel.Top = btnCatalogo.Top;
            userCtrlCatalogo1.Show();
            userCtrlCatalogo1.BringToFront();
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



        //drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int waram, int IParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
