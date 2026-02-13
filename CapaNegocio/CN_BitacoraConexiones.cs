using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_BitacoraConexiones
    {
        public CD_BitacoraConexiones objCapaDatos = new CD_BitacoraConexiones();

        public int R_InicioSesionCliente(Clientes obj)
        {
            return objCapaDatos.R_InicioSesionCliente(obj);
        }

        public int R_InicioSesionEmpleado(Empleados obj)
        {
            return objCapaDatos.R_InicioSesionEmpleado(obj);
        }

        public void RegistrarCierreSesion(int BitacoraID)
        {
            objCapaDatos.RegistrarCierreSesion(BitacoraID);
        }
        //Lista las conexiones de algun Empleado 
        public List<BitacoraConexion> ListarConexiones_E(int ID)
        {
            return objCapaDatos.Listar_Conexiones().Where(item => item.Empleado != null && item.Empleado.EmpleadoID == ID).ToList();
        }

        //Lista las conexiones de algun Cliente
        public List<BitacoraConexion> ListarConexiones_C(int ID)
        {
            return objCapaDatos.Listar_Conexiones().Where(item => item.Cliente != null && item.Cliente.ClienteID == ID).ToList();
        }

        public List<BitacoraConexion> Listar(int ID)
        {
            return objCapaDatos.Listar_Conexiones()
                    .Where(item =>
                        (item.Cliente != null && item.Cliente.ClienteID == ID) ||
                        (item.Empleado != null && item.Empleado.EmpleadoID == ID))
                    .ToList();
        }
    }
}
