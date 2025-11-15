using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Proveedor oProveedor { get; set; }
        public string Tipo_Documento { get; set; }
        public decimal MontoTotal { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaRegistro { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVATotal { get; set; }
        public List<Detalle_Compra> oDetalleCompra { get; set; }
    }
}
