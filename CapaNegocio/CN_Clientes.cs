using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        public CD_Clientes objCapaDatos = new CD_Clientes();
        public List<Clientes> Listar()
        {
            return objCapaDatos.Listar_Clientes();
        }

        public int RegistrarCliente(Clientes obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(Mensaje))
            {
                obj.Contraseña = CN_Recursos.ConvertirSHA256(obj.Contraseña);

                return objCapaDatos.RegistrarCliente(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }


        public bool EditarCliente(Clientes obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDatos.EditarCliente(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool InhabilitarCliente(int id)
        {
            return objCapaDatos.InhabilitarCliente(id);
        }

        public bool HabilitarCliente(int id)
        {
            return objCapaDatos.HabilitarCliente(id);
        }


    }
}
