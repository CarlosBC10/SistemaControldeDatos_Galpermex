using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;
using Pagina_Inicio.Permisos;

namespace Pagina_Inicio.Controllers
{
    [NoLoginAllowed]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Servicios()
        {

            return View();
        }

        public ActionResult Clientes()
        {

            return View();
        }

        public ActionResult Sobre_Nosotros()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public JsonResult GuardarSolicitudAsesor(ContactoAsesores objeto)
        {
            object resultado;
            string Mensaje = string.Empty;

            resultado = new CN_ContactoAsesores().RegistrarSolicitudAsesor(objeto, out Mensaje);

            //return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
            // Verificar si se registraron los datos correctamente
            if (resultado != null && (int)resultado != 0)
            {
                // Notificar a la empresa por correo electrónico
                bool envioExitoso = CN_Recursos.EnviarCorreoAsesor("Nuevo mensaje de cliente potencial", "Se ha recibido un nuevo mensaje de un cliente potencial. Por favor, revise sus mensajes en el sistema web. Saludos.");
                if (envioExitoso)
                {
                    // Si se envió el correo correctamente, devolver el resultado
                    return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    // Si ocurrió un error al enviar el correo, devolver un mensaje de error
                    return Json(new { resultado = 0, Mensaje = "Error al enviar la notificación por correo electrónico" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                // Si no se pudieron registrar los datos, devolver un mensaje de error
                return Json(new { resultado = 0, Mensaje = "Error al registrar los datos del cliente" }, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult Login()
        {

            return View();
        }

        

    }
}