using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Componente
    {
        private CD_Componente objcd_Componente = new CD_Componente();

        public List<Componente> Listar()
        {
            return objcd_Componente.Listar();
        }

        public int Registrar(Componente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion del componente\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del componente\n";
            }

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del componente\n";
            }
            if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje += "Es necesario seleccionar una categoria\n";
            }
              
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Componente.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(Componente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion del componente\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del componente\n";
            }

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del componente\n";
            }
            if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje += "Es necesario seleccionar una categoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Componente.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Componente obj, out string Mensaje)
        {
            return objcd_Componente.Eliminar(obj, out Mensaje);
        }
    }
}
