using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
    public class BitacoraArchivos
    {
        //public class BitacoraArchivo
        //{
        //    public int BitacoraArchivoID { get; set; }
        //    public DateTime FechaAccion { get; set; }
        //    public string Accion { get; set; }
        //    public int UsuarioID { get; set; }
        //    public int ArchivoID { get; set; }

        //    public virtual Empleados Empleado { get; set; }
        //    public virtual Clientes Cliente { get; set; }
        //    public virtual Roles TipoUsuario { get; set; }
        //    public virtual ArchivoPDF ArchivoPDF { get; set; }
        //}

        public class BitacoraArchivo {
            public int BitacoraArchivoID { get; set; }
            public DateTime FechaAccion { get; set; }
            public int AccionID { get; set; }
            public int UsuarioID { get; set; }
            public int TipoUsuarioID { get; set; }
            public int ArchivoID { get; set; }

            public Empleados Empleado { get; set; }
            public Clientes Cliente { get; set; }
            public Roles TipoUsuario { get; set; }
            public ArchivoPDF Archivo { get; set; }
            public Acciones Accion { get; set; }
        }


    }
}
