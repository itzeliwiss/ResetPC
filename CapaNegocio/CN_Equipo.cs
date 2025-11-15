using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Equipo
    {
        private CD_Equipo objcd_Equipo = new CD_Equipo();

        public List<Equipo> Listar()
        {
            return objcd_Equipo.Listar();
        }

        public int Registrar(Equipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oCliente.IdCliente == 0)
            {
                Mensaje += "Es necesario seleccionar un cliente\n";
            }
            if (obj.Modelo == "")
            {
                Mensaje += "Es necesario el modelo del equipo\n";
            }

            if (obj.Almacenamiento == "")
            {
                Mensaje += "Es necesario saber el almacenamiento del equipo\n";
            }
            if (obj.Ram == "")
            {
                Mensaje += "Es necesario saber la memoria RAM del equipo\n";
            }
            if (obj.Procesador == "")
            {
                Mensaje += "Es necesario saber el procesador del equipo\n";
            }
            if (obj.NumeroSerie == "")
            {
                Mensaje += "Es necesario el número de serie del equipo\n";
            }
            if (obj.oOS.IdSO == 0)
            {
                Mensaje += "Es necesario el sistema operativo del equipo\n";
            }
            if (obj.TipoDisco == "")
            {
                Mensaje += "Es necesario el tipo de disco del equipo\n";
            }
            if (obj.oMarca == null || obj.oMarca.IdMarca == 0)
            {
                Mensaje += "Es necesario seleccionar una marca\n";
            }
            if (obj.Tipo == "")
            {
                Mensaje += "Es necesario el tipo de equipo\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Equipo.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Equipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oCliente.IdCliente == 0)
            {
                Mensaje += "Es necesario seleccionar un cliente\n";
            }
            if (obj.Modelo == "")
            {
                Mensaje += "Es necesario el modelo del equipo\n";
            }

            if (obj.Almacenamiento == "")
            {
                Mensaje += "Es necesario saber el almacenamiento del equipo\n";
            }
            if (obj.Ram == "")
            {
                Mensaje += "Es necesario saber la memoria RAM del equipo\n";
            }
            if (obj.Procesador == "")
            {
                Mensaje += "Es necesario saber el procesador del equipo\n";
            }
            if (obj.NumeroSerie == "")
            {
                Mensaje += "Es necesario el número de serie del equipo\n";
            }
            if (obj.oOS.IdSO == 0)
            {
                Mensaje += "Es necesario el sistema operativo del equipo\n";
            }
            if (obj.TipoDisco == "")
            {
                Mensaje += "Es necesario el tipo de disco del equipo\n";
            }
            if (obj.oMarca == null || obj.oMarca.IdMarca == 0)
            {
                Mensaje += "Es necesario seleccionar una marca\n";
            }
            if (obj.Tipo == "")
            {
                Mensaje += "Es necesario el tipo de equipo\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Equipo.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Equipo obj, out string Mensaje)
        {
            return objcd_Equipo.Eliminar(obj, out Mensaje);
        }
    }
}
