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

    public partial class Botones : UserControl
    {
        private int id = 0;
        private string descripcion = "Descripcion del producto";
        private int cantidad;
        private DateTime fecha_creacion;

        public Botones()
        {
            InitializeComponent();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Image ImgProducto
        {
            get { return ImgpictureBox1.Image; }
            set { ImgpictureBox1.Image = value; }
        }

        public string NameProducto
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string Precio
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }

        public int CantidadProducto
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fecha_creacion; }
            set {  fecha_creacion = value; }
        }

    }
}
