using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;
using System.Web.Security;

namespace Pagina_Inicio.Permisos
{
    public class PermisosRolesAttribute : ActionFilterAttribute
    {
        private List<string> roles;

        public PermisosRolesAttribute(params string[] roles)
        {
            this.roles = roles.ToList();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                var usuario = HttpContext.Current.Session["Usuario"];

                if (usuario is Empleados _Empleado && !roles.Contains(_Empleado.Rol.NombreRol) ||
                    usuario is Clientes _cliente && !roles.Contains(_cliente.Rol.NombreRol))
                {
                    // Cerrar sesión
                    FormsAuthentication.SignOut();
                    HttpContext.Current.Session.Clear();
                    HttpContext.Current.Session.Abandon();
                    filterContext.Result = new RedirectResult("~/Login/SinPermiso");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }

            base.OnActionExecuted(filterContext);
        }
    }


    //public class PermisosRolAttribute : ActionFilterAttribute
    //{
    //    private string Rol;

    //    public PermisosRolAttribute(string _Rol) {

    //        Rol = _Rol;

    //    }

    //    public override void OnActionExecuted(ActionExecutedContext filterContext)
    //    {


    //        if (HttpContext.Current.Session["Usuario"] != null) { 

    //            var usuario = HttpContext.Current.Session["Usuario"];

    //            if (usuario is Empleados _Empleaado && _Empleaado.Rol.NombreRol != Rol || usuario is Clientes _clientes && _clientes.Rol.NombreRol != Rol)
    //            {

    //                // Cerrar sesión
    //                FormsAuthentication.SignOut();
    //                HttpContext.Current.Session.Clear();
    //                HttpContext.Current.Session.Abandon();
    //                filterContext.Result = new RedirectResult("~/Login/SinPermiso");

    //            }
    //        } else {

    //                filterContext.Result = new RedirectResult("~/Home/Index");

    //        }

    //        base.OnActionExecuted(filterContext);
    //    }

    //}
}