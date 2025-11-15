using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Compra
    {
        public int IdDetalleCompra { get; set; }
        public Compra oCompra { get; set; }
        public Componente oComponente { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioVenta { get; set; }
        public string FechaCompra { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Subtotal { get; set; }
        public  decimal TasaIVA { get; set; }
        public decimal IVACalculado { get; set; }

    }
}
