using ProyectoFinalAlgoritmos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAlgoritmos
{
    public partial class frmLogin : Form
    {
        //Cadena de conexión a la base de datos SQL Server
        SqlConnection conexion = new SqlConnection("Data Source=100.122.79.72,1433;Initial Catalog=InventarioBD;User ID=Aniana;Password=12345;");

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
    int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        public frmLogin()
        {
            InitializeComponent();
           
            TitleBar.MouseDown += new MouseEventHandler(TitleBar_MouseDown);
            this.MouseDown += new MouseEventHandler(frmLogin_MouseDown);

            this.AcceptButton = btnLogin;
            txtPassword.UseSystemPasswordChar = true;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MoverFormulario()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoverFormulario();
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoverFormulario();
            }
        }

        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {

            btnLogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 20, 20));
        }

        private void frmLogin_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        }

        public void logear(string usuario, string contrasena)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT nombre, tipo_usuario FROM Usuarios WHERE usuario=@usuario AND contrasena=@contrasena", conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // Guardar datos del usuario en la sesión
                    SesionUsuario.Nombre = dt.Rows[0]["nombre"].ToString();
                    SesionUsuario.TipoUsuario = dt.Rows[0]["tipo_usuario"].ToString();
                    SesionUsuario.Usuario = usuario;

                    this.Hide();

                    new Form1().Show();

                    MessageBox.Show($"Bienvenido {SesionUsuario.Nombre} ({SesionUsuario.TipoUsuario})");
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logear(txtUsuario.Text, txtPassword.Text);
        }
    }
}
