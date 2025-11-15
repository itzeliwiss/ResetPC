using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Servicio
    {
        private CD_Servicio objcd_Servicio = new CD_Servicio();

        public List<Servicio> Listar()
        {
            return objcd_Servicio.Listar();
        }

        public int Registrar(Servicio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion del servicio\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del servicio\n";
            }

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del servicio\n";
            }
            

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Servicio.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(Servicio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion del servicio\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del servicio\n";
            }

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del servicio\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Servicio.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Servicio obj, out string Mensaje)
        {
            return objcd_Servicio.Eliminar(obj, out Mensaje);
        }
    }
}
