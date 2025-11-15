using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Orden_Servicio
    {
        public int IdOrdenServicio { get; set; }
        public Equipo oEquipo { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public decimal Descuento_Total { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaRegistro { get; set; }
    }
}
