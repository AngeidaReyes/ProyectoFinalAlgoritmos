using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAlgoritmos.Models
{
    public class Receta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int MateriaPrimaId { get; set; }
        public string NombreMateria { get; set; }
        public decimal CantidadRequerida { get; set; }
        public decimal PrecioUnitarioMateria { get; set; }

        public decimal CostoParcial => CantidadRequerida * PrecioUnitarioMateria;

    }
}
