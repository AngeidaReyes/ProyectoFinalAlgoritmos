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
    public partial class UsrCrtlUsuarios : UserControl
    {
        public UsrCrtlUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.ReadOnly = true;
            LeerUsuarios();
            Permisos();

            usrCrtlDatosUsuario1.Hide();
            usrCrtlDatosUsuario1.Dock = DockStyle.Fill;
            usrCrtlDatosUsuario1.UsuarioGuardado += (s, e) => LeerUsuarios();
        }
        private void LeerUsuarios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Contraseña");
            dt.Columns.Add("Tipo de Usuario");

            var repo = new Repositories.RepositorioUsuarios();
            var usuarios = repo.ObtenerUsuarios();
            foreach (var user in usuarios)
            {
                var row = dt.NewRow();
                row["ID"] = user.Id;
                row["Nombre"] = user.Nombre;
                row["Usuario"] = user.Usuario;
                row["Contraseña"] = user.Contrasena;
                row["Tipo de Usuario"] = user.TipoUsuario;

                dt.Rows.Add(row);
            }
            this.dgvUsuarios.DataSource = dt;
        }

        public void Permisos()
        {
            if (Models.SesionUsuario.TipoUsuario == "Administrador")
            {
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
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
            usrCrtlDatosUsuario1.LimpiarCampos();
            usrCrtlDatosUsuario1.lblTitulo.Text = "Crear Nuevo Usuario";

            usrCrtlDatosUsuario1.Show();
            usrCrtlDatosUsuario1.BringToFront();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar.");
                return;
            }

            var valor = dgvUsuarios.SelectedRows[0].Cells["ID"].Value?.ToString(); // usa el nombre de columna
            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("El usuario seleccionado no es válido.");
                return;
            }

            int id = int.Parse(valor);
            var repo = new Repositories.RepositorioUsuarios();
            var user = repo.ObtenerUsuario(id);

            if (user == null)
            {
                MessageBox.Show("No se encontró el usuario seleccionado.");
                return;
            }

            usrCrtlDatosUsuario1.EditarUsuario(user);
            usrCrtlDatosUsuario1.Dock = DockStyle.Fill;
            usrCrtlDatosUsuario1.Show();
            usrCrtlDatosUsuario1.BringToFront();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var valor = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
            if (valor == null || valor.Length == 0)
            {
                return;
            }

            int id = int.Parse(valor);

            DialogResult dialogResult = MessageBox.Show("Esta seguro de que desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var repo = new RepositorioUsuarios();
            repo.EliminarUsuario(id);

            LeerUsuarios();
        }

        private void dgvUsuarios_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Contraseña" && e.Value != null)
            {
                string texto = e.Value.ToString();
                e.Value = new string('●', texto.Length);
            }

            if (e.ColumnIndex == 4 && e.Value != null) // Suponiendo que la columna 4 es "Tipo de Usuario"
            {
                string tipoUsuario = e.Value.ToString();
                if (tipoUsuario == "Admin")
                {
                    e.CellStyle.BackColor = Color.LightCoral; 
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (tipoUsuario == "User")
                {
                    e.CellStyle.BackColor = Color.LightBlue; 
                    e.CellStyle.ForeColor = Color.Black;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGray; 
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
}
