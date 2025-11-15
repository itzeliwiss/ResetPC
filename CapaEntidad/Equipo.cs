using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public Cliente oCliente { get; set; }
        public string Tipo { get; set; }
        public Marca oMarca { get; set; }
        public string Modelo { get; set; }
        public string Almacenamiento { get; set; }
        public string TipoDisco { get; set; }
        public string Ram { get; set; }
        public string Procesador { get; set; }
        public string NumeroSerie { get; set; }
        public string Descripcion { get; set; }
        public SO oOS { get; set; }
        public string FechaRegistro { get; set; }
    }
}
