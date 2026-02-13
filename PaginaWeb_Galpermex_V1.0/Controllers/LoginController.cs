using CapaEntidad;
using CapaNegocio;
using Pagina_Inicio.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pagina_Inicio.Permisos;
using Microsoft.Ajax.Utilities;

namespace Pagina_Inicio.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        [NoLoginAllowed]
        public ActionResult Index()
        {
            return View();
        }
        [NoLoginAllowed]
        public ActionResult Login(string Correo, string Contraseña, string Rol)
        {
            int BitacoraID;
            CN_Login _da_Empleado = new CN_Login();
            CN_BitacoraConexiones bit_Conexiones = new CN_BitacoraConexiones();

            if (Rol != null)
            {
                if (Rol == "Cliente")
                {
                    
                    var cliente = _da_Empleado.ValidarCliente(Correo, Contraseña);
                    // Lógica específica para cliente
                    if (cliente != null)
                    {
                        BitacoraID = bit_Conexiones.R_InicioSesionCliente(cliente);
                        TempData["BitacoraID"] = BitacoraID; // Almacenar en TempData
                        FormsAuthentication.SetAuthCookie(cliente.Correo, false);
                        Session["Usuario"] = cliente;
                        return RedirectToAction("Bievenida", "Login");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Credenciales incorrectas para cliente. Por favor, intente nuevamente.";
                    }
                }
                else if (Rol == "Corporativo")
                {

                    // Validar como empleado, pero con un rol específico
                    var empleadoAsesor = _da_Empleado.ValidarEmpleado(Correo, Contraseña, "Asesor");
                    var empleadoAdmin = _da_Empleado.ValidarEmpleado(Correo, Contraseña, "Administrador");

                    // Lógica específica para asesor o administrador
                    if (empleadoAsesor != null)
                    {
                        BitacoraID = bit_Conexiones.R_InicioSesionEmpleado(empleadoAsesor);
                        TempData["BitacoraID"] = BitacoraID; // Almacenar en TempData
                        FormsAuthentication.SetAuthCookie(empleadoAsesor.Correo, false);
                        Session["Usuario"] = empleadoAsesor;
                        return RedirectToAction("Bievenida", "Login");
                    }
                    else if (empleadoAdmin != null)
                    {
                        BitacoraID = bit_Conexiones.R_InicioSesionEmpleado(empleadoAdmin);
                        TempData["BitacoraID"] = BitacoraID; // Almacenar en TempData
                        FormsAuthentication.SetAuthCookie(empleadoAdmin.Correo, false);
                        Session["Usuario"] = empleadoAdmin;
                        // Establecer información en la sesión para el administrador
                        return RedirectToAction("Bievenida", "Login");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Credenciales incorrectas para corporativo. Por favor, intente nuevamente.";
                    }
                }
            }

            // Lógica para manejar el caso en que no se valida el usuario
            return View();
        }

        public ActionResult SinPermiso()
        {

            return View();
        }
        [PermisosRolesAttribute("Administrador", "Asesor", "Cliente")]
        public ActionResult Bievenida()
        {
            // Obtén el usuario actual desde la sesión
            var usuario = HttpContext.Session["Usuario"];

            // Puedes agregar lógica adicional según tus necesidades, por ejemplo, validar si el usuario está en sesión
            if (usuario == null)
            {
                // Si no hay usuario en sesión, redirige a la página de inicio o realiza alguna otra acción
                return RedirectToAction("Index", "Home");
            }

            // Envía el modelo ala vista
            return View(usuario);
        }
        [PermisosRolesAttribute("Administrador", "Asesor", "Cliente")]
        public ActionResult CerrarSesion()
        {
            CN_BitacoraConexiones bit_Conexiones = new CN_BitacoraConexiones();
            
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;
            Session.Clear();
            Session.Abandon();

            // Recuperar de TempData
            int BitacoraID = TempData["BitacoraID"] != null ? (int)TempData["BitacoraID"] : 0;
            if (BitacoraID != 0)
            {
                bit_Conexiones.RegistrarCierreSesion(BitacoraID);
            }
            return RedirectToAction("Index", "Home");
        }


    }
}