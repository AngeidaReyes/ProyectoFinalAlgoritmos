using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Models
{
    public class Transacciones
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } 
        public string Comentario { get; set; }
        public int UsuarioId { get; set; }

    }
}
