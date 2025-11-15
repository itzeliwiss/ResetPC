using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Servicio
    {
        public int IdDetalleServicio { get; set; }
        public Orden_Servicio oOrdenServicio { get; set; }   
        public Servicio oServicio { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string FechaRegistro { get; set; }

    }
}
