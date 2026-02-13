using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Roles
    {
        public CD_Roles objCapaDatos = new CD_Roles();

        public List<Roles> Listar()
        {
            return objCapaDatos.Listar_Roles();
        }
    }
}
