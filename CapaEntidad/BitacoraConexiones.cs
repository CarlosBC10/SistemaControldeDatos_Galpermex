using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class BitacoraConexion
    {
        public int BitacoraID { get; set; }
        public DateTime FechaConexion { get; set; }
        public DateTime? FechaDesconexion { get; set; }
        public Empleados Empleado { get; set; }
        public Clientes Cliente { get; set; }
    }


}
