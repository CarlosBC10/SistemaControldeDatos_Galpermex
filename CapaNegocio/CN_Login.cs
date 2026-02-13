using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Login {

        public CD_Empleados objCapaDatos_E = new CD_Empleados();
        public CD_Clientes objCapaDatos_C = new CD_Clientes();

        public Empleados ValidarEmpleado(string Correo, string Contraseña, string Rol)
        {
            return objCapaDatos_E.Listar_Empleados().Where(item => item.Correo == Correo && item.Contraseña == Contraseña && item.Rol.NombreRol == Rol && item.EsActivo == true).FirstOrDefault();
        }

        public Clientes ValidarCliente(string Correo, string Contraseña)
        {
            return objCapaDatos_C.Listar_Clientes().Where(item => item.Correo == Correo && item.Contraseña == Contraseña && item.EsActivo == true).FirstOrDefault();
        }

    }
}
