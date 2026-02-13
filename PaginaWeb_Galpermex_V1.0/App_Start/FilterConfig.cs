using Pagina_Inicio.Permisos;
using System.Web;
using System.Web.Mvc;

namespace Pagina_Inicio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new PermisosRolAttribute("Cliente"));
            //filters.Add(new PermisosRolAttribute("Asesor"));
            //filters.Add(new PermisosRolAttribute("Administrador"));
        }
    }
}
