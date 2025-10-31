using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Models
{
    public class MateriaPrima
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Minimo { get; set; }
        public DateTime Fecha { get; set; }

        public decimal ValorTotal => Precio * Cantidad;
    }
}
