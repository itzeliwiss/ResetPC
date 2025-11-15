using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_SO
    {
        private CD_SO objcd_SO = new CD_SO();
        public List<SO> Listar()
        {
            return objcd_SO.Listar();
        }

        public int Registrar(SO obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NombreSO == "")
            {
                Mensaje += "Es necesario el nombre del sistema operativo \n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_SO.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(SO obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NombreSO == "")
            {
                Mensaje += "Es necesario el nombre del sistema operativo \n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_SO.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(SO obj, out string Mensaje)
        {
            return objcd_SO.Eliminar(obj, out Mensaje);
        }
    }
}
