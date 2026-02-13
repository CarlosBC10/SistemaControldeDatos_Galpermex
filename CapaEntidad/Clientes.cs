using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Clientes {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaInactividad { get; set; }

        // Propiedad de navegación
        public Roles Rol { get; set; }
    }

}
