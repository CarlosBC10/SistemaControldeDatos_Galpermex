using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina_Inicio.Permisos
{
    public class NoLoginAllowedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                // Si el usuario ya ha iniciado sesión, redirige a una página de error o a donde prefieras.
                filterContext.Result = new RedirectResult("~/Login/Bievenida");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}