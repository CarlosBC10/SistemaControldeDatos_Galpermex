using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class BitacoraContactoAsesor {
            public int BitContactAsesorID { get; set; }
            public bool Respondido { get; set; }
            public DateTime FechaRespuesta { get; set; }
            public int EmpleadoID { get; set; }
            public int ContactoID { get; set; }
            public int RolID { get; set; }

            public Empleados Empleado { get; set; }
            public ContactoAsesores Contacto { get; set; }
            public Roles Rol { get; set; }
    }
}
