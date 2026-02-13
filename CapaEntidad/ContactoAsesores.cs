using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //    -- Tabla ContactoAsesores
    //CREATE TABLE ContactoAsesores(
    //    ContactoID INT PRIMARY KEY,
    //    Nombre VARCHAR(50) NOT NULL,
    //    Apellidos VARCHAR(50) NOT NULL,
    //    AsuntoCorreo VARCHAR(100),
    //    NumeroTelefonico VARCHAR(15),
    //    Mensaje TEXT,
    //    FechaRegistro DATETIME,
    //);

    //public class ContactoAsesores
    //{
    //    public int ContactoID { get; set; }
    //    public string Nombre { get; set; }
    //    public string Apellidos { get; set; }
    //    public string Asunto { get; set; }
    //    public string NumeroTelefonico { get; set; }
    //    public string Mensaje { get; set; }
    //    public string Correo { get; set; }
    //    public string FechaRegistro { get; set; }
    //}

    public class ContactoAsesores {
        public int ContactoID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool status { get; set; }
        public Asunto_Contacto Asunto { get; set; }
    }

}
