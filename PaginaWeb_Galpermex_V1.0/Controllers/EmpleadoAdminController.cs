using CapaEntidad;
using CapaNegocio;
using Pagina_Inicio.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Pagina_Inicio.Controllers
{
    [PermisosRolesAttribute("Administrador")]
    public class EmpleadoAdminController : Controller
    {
        // GET: EmpleadoAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Conexiones(int empleadoID)
        {
            // Obtener las conexiones para el empleadoID
            List<BitacoraConexion> conexiones = new CN_BitacoraConexiones().ListarConexiones_E(empleadoID);

            // Puedes pasar las conexiones al modelo de la vista si es necesario
            ViewBag.Conexiones = conexiones;

            return View();
        }

        //[PermisosRolesAttribute("Administrador")]
        public ActionResult Conexiones_Cliente(int ClienteID)
        {
            // Obtener las conexiones para el empleadoID
            List<BitacoraConexion> conexiones = new CN_BitacoraConexiones().ListarConexiones_C(ClienteID);

            // Puedes pasar las conexiones al modelo de la vista si es necesario
            ViewBag.Conexiones = conexiones;

            return View();
        }

        [HttpGet]
        public JsonResult ListarEmpleados()
        {
            List<Empleados> oLista = new List<Empleados>();
            oLista = new CN_Empleados().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult ListarConexiones(int id)
        //{
        //    List<BitacoraConexion> oLista = new List<BitacoraConexion>();
        //    oLista = new CN_BitacoraConexiones().Listar(id);

        //    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult GuardarEmpleado(Empleados objeto)
        {
            object resultado;
            string Mensaje = string.Empty;

            if (objeto.EmpleadoID == 0)
            {
                resultado = new CN_Empleados().RegistrarEmpleado(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_Empleados().EditarEmpleado(objeto, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InhabilitarEmpleado(int id)
        {
            object resultado;
            try
            {
                resultado = new CN_Empleados().InhabilitarEmpleado(id);
                return Json(resultado); // Devuelve el resultado como JsonResult
            }
            catch (Exception ex)
            {
                // Maneja la excepción adecuadamente, por ejemplo, registrándola o devolviendo un mensaje de error.
                return Json(new { error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult HabilitarEmpleado(int id)
        {
            object resultado;
            try
            {
                resultado = new CN_Empleados().HabilitarEmpleado(id);
                return Json(resultado); // Devuelve el resultado como JsonResult
            }
            catch (Exception ex)
            {
                // Maneja la excepción adecuadamente, por ejemplo, registrándola o devolviendo un mensaje de error.
                return Json(new { error = ex.Message });
            }
        }

    }
}