using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Empleados
    {
        public CD_Empleados objCapaDatos = new CD_Empleados();

        public List<Empleados> Listar()
        {
            return objCapaDatos.Listar_Empleados();
        }

        public int RegistrarEmpleado(Empleados obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(Mensaje))
            {
                obj.Contraseña = CN_Recursos.ConvertirSHA256(obj.Contraseña);

                return objCapaDatos.RegistrarEmpleado(obj, out Mensaje);
            } else
            {
                return 0;
            }
        }


        public bool EditarEmpleado(Empleados obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDatos.EditarEmpleado(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool InhabilitarEmpleado(int id)
        {
            return objCapaDatos.InhabilitarEmpleado(id);
        }

        public bool HabilitarEmpleado(int id)
        {
            return objCapaDatos.HabilitarEmpleado(id);
        }

    }
}
