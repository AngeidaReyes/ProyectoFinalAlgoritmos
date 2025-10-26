using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Models
{
    public class Movimientos
    {
        public int IdMovimiento { get; set; }
        public int IdProducto { get; set; }
        public string TipoMovimiento { get; set; } // "ENTRADA" o "SALIDA"
        public int Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
