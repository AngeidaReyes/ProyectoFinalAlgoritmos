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
using ProyectoFinalAlgoritmos.Models;

namespace ProyectoFinalAlgoritmos
{
    public partial class UsrCtrlProductos : UserControl
    {
        public UsrCtrlProductos()
        {
            InitializeComponent();
            dgvProductos.ReadOnly = true;
            LeerProductos();
            Permisos();

            usrCtrlDatos1.Hide();
            usrCtrlDatos1.ProductoGuardado += (s, e) => LeerProductos();
        }

        private void LeerProductos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Costo");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Fecha");

            var repo = new RepositorioProductos();
            var productos = repo.ObtenerProductos();

            foreach (var producto in productos)
            {
                var row = dt.NewRow();
                row["ID"] = producto.Id;
                row["Nombre"] = producto.Nombre;
                row["Descripción"] = producto.Descripcion;
                row["Precio"] = producto.Precio.ToString("C");
                row["Costo"] = producto.Costo.ToString("C");
                row["Cantidad"] = producto.Cantidad;                
                row["Fecha"] = producto.Fecha;

                dt.Rows.Add(row);
            }

            this.dgvProductos.DataSource = dt;

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
            usrCtrlDatos1.LimpiarCampos();
            usrCtrlDatos1.lblTitulo.Text = "Crear Producto";
            usrCtrlDatos1.Show();
            usrCtrlDatos1.BringToFront();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar.");
                return;
            }

            var valor = dgvProductos.SelectedRows[0].Cells["ID"].Value?.ToString(); // usa el nombre de columna
            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("El producto seleccionado no es válido.");
                return;
            }

            int id = int.Parse(valor);
            var repo = new RepositorioProductos();
            var producto = repo.ObtenerProducto(id);

            if (producto == null)
            {
                MessageBox.Show("No se encontró el producto seleccionado.");
                return;
            }

            usrCtrlDatos1.EditarProducto(producto);
            usrCtrlDatos1.Show();
            usrCtrlDatos1.BringToFront();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var valor = dgvProductos.SelectedRows[0].Cells[0].Value.ToString();
            if (valor == null || valor.Length == 0)
            {
                //MessageBox.Show("Seleccione un producto para editar.");
                return;
            }

            int id = int.Parse(valor);

            DialogResult dialogResult = MessageBox.Show("Esta seguro de que desea eliminar este producto?", "Eliminar Producto", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) { 
                return;
            }

            var repo = new RepositorioProductos();
            repo.EliminarProducto(id);

            LeerProductos();
        }
    }
}
