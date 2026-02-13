using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //    -- Tabla ArchivosPDF
    //CREATE TABLE ArchivosPDF(
    //    ArchivoID INT PRIMARY KEY,
    //    NombreArchivo VARCHAR(100) NOT NULL,
    //    RutaArchivo VARCHAR(255) NOT NULL,
    //    FechaSubida DATETIME,
    //    EmpleadoID INT,
    //    FOREIGN KEY(EmpleadoID) REFERENCES Empleados(EmpleadoID)
    //);

    //public class ArchivosPDF
    //{
    //    public class ArchivoPDF
    //    {
    //        public int ArchivoID { get; set; }
    //        public string NombreArchivo { get; set; }
    //        public string RutaArchivo { get; set; }
    //        public DateTime? FechaSubida { get; set; }
    //        public int? EmpleadoID { get; set; }
    //        public int? ClienteID { get; set; }

    //        public virtual Empleados Empleado { get; set; }
    //        public virtual Clientes Cliente { get; set; }
    //    }

    //}

    public class ArchivoPDF
    {
        public int ArchivoID { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public DateTime FechaSubida { get; set; }
        public int EmpleadoID { get; set; }
        public int ClienteID { get; set; }

        // Propiedades de navegación
        public virtual Empleados Empleado { get; set; }
        public virtual Clientes Cliente { get; set; }
    }

}
