using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Roles
    {
        public List<Roles> Listar_Roles()
        {
            List<Roles> Listar = new List<Roles>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT RolID, NombreRol FROM Roles";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Listar.Add(
                                new Roles()
                                {
                                    RolID = Convert.ToInt32(dr["RolID"]),
                                    NombreRol = dr["NombreRol"].ToString()
                                });
                        }
                    }
                }

            }
            catch
            {

                Listar = new List<Roles>();
            }

            return Listar;
        }
    }
}
