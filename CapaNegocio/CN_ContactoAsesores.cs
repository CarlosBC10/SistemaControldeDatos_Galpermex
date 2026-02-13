using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ContactoAsesores
    {
        private CD_ContactoAsesor objCapaDatos = new CD_ContactoAsesor();

        public List<ContactoAsesores> Listar()
        {
            return objCapaDatos.Listar_ContactoAsesor();
        }


        public int RegistrarSolicitudAsesor(ContactoAsesores obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDatos.RegistrarSolicitudAsesor(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool MsgLeido(int id)
        {
            return objCapaDatos.MsgLeido(id);
        }

        public bool EliminarMSG(int id)
        {
            return objCapaDatos.BorrarMensaje(id);
        }


    }
}
