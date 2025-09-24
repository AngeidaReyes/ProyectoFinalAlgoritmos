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
    public partial class UsrCrtlDatosUsuario : UserControl
    {
        public event EventHandler UsuarioGuardado;
        public UsrCrtlDatosUsuario()
        {
            InitializeComponent();
            txtId.ReadOnly = true;
            LimpiarCampos();
            txtContrasena.UseSystemPasswordChar = true;
        }
        private int idUsuario = 0;
        public void EditarUsuario(Models.Usuarios user)
        {
            lblTitulo.Text = "Editar Usuario";
            LimpiarCampos();
            if (user != null)
            {
                txtId.Text = user.Id.ToString();
                txtNombre.Text = user.Nombre;
                txtUsuario.Text = user.Usuario;
                txtContrasena.Text = user.Contrasena;
                cmbTipoUsuario.SelectedItem = user.TipoUsuario;
                this.idUsuario = user.Id;
            }
        }
        public void LimpiarCampos()
        {
            idUsuario = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            cmbTipoUsuario.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Models.Usuarios user = new Models.Usuarios();
            user.Id = this.idUsuario;
            user.Nombre = txtNombre.Text;
            user.Usuario = txtUsuario.Text;
            user.Contrasena = txtContrasena.Text;
            user.TipoUsuario = cmbTipoUsuario.SelectedItem?.ToString();

            var repo = new Repositories.RepositorioUsuarios();
            if (this.idUsuario == 0)
            {
                repo.AgregarUsuario(user);
                MessageBox.Show("Usuario agregado exitosamente.");
            }
            else
            {
                repo.ActualizarUsuario(user);
                MessageBox.Show("Usuario actualizado exitosamente.");
            }

            UsuarioGuardado?.Invoke(this, EventArgs.Empty);
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
