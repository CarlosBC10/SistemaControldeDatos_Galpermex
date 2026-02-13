using CapaEntidad;
using CapaNegocio;
using Pagina_Inicio.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina_Inicio.Controllers
{
    [PermisosRolesAttribute("Administrador", "Asesor")]
    public class Admin_AsesorController : Controller
    {
        // GET: Admin_Asesor
        public ActionResult ListaClientes()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarClientes()
        {
            List<Clientes> oLista = new List<Clientes>();
            oLista = new CN_Clientes().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarCliente(Clientes objeto)
        {
            object resultado;
            string Mensaje = string.Empty;

            if (objeto.ClienteID == 0)
            {
                resultado = new CN_Clientes().RegistrarCliente(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_Clientes().EditarCliente(objeto, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InhabilitarCliente(int id)
        {
            object resultado;
            try
            {
                resultado = new CN_Clientes().InhabilitarCliente(id);
                return Json(resultado); // Devuelve el resultado como JsonResult
            }
            catch (Exception ex)
            {
                // Maneja la excepción adecuadamente, por ejemplo, registrándola o devolviendo un mensaje de error.
                return Json(new { error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult HabilitarCliente(int id)
        {
            object resultado;
            try
            {
                resultado = new CN_Clientes().HabilitarCliente(id);
                return Json(resultado); // Devuelve el resultado como JsonResult
            }
            catch (Exception ex)
            {
                // Maneja la excepción adecuadamente, por ejemplo, registrándola o devolviendo un mensaje de error.
                return Json(new { error = ex.Message });
            }
        }

        public ActionResult SolicitudAsesor()
        {
            return View();
        }

        public ActionResult ListaArchivosSubidos(int ClienteID)
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarContactoAsesor()
        {
            List<ContactoAsesores> oLista = new List<ContactoAsesores>();
            oLista = new CN_ContactoAsesores().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MsgLeido(int id)
        {
            try
            {
                bool resultado = new CN_ContactoAsesores().MsgLeido(id);
                return Json(resultado);
            }
            catch (Exception ex)
            {
                return Json(false); // Retorna false si ocurre algún error
            }
        }

        [HttpPost]
        public JsonResult EliminarMSG(int id)
        {
            try
            {
                bool resultado = new CN_ContactoAsesores().EliminarMSG(id);
                return Json(resultado);
            }
            catch (Exception ex)
            {
                return Json(false); // Retorna false si ocurre algún error
            }
        }

    }
}