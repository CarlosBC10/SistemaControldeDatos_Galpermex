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
    public class CD_BitacoraConexiones
    {
        public int R_InicioSesionCliente(Clientes obj)
        {
            int bitacoraID = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
            {

                using (SqlCommand cmd = new SqlCommand("sp_RegistrarInicioSesion_Clientes", oconexion))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", obj.ClienteID);
                    cmd.Parameters.Add("@BitacoraID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    bitacoraID = Convert.ToInt32(cmd.Parameters["@BitacoraID"].Value);
                }
            }
            return bitacoraID;
        }

        public int R_InicioSesionEmpleado(Empleados obj)
        {
            int bitacoraID = 0;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarInicioSesion_Empleados", oconexion);
                    cmd.Parameters.AddWithValue("@EmpleadoID", obj.EmpleadoID);
                    cmd.Parameters.Add("@BitacoraID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    bitacoraID = Convert.ToInt32(cmd.Parameters["@BitacoraID"].Value);
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return bitacoraID;
        }

        public void RegistrarCierreSesion(int bitacoraID)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarCierreSesion", oconexion))
                {
                    cmd.Parameters.AddWithValue("@BitacoraID", bitacoraID);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<BitacoraConexion> Listar_Conexiones()
        {
            List<BitacoraConexion> Listar = new List<BitacoraConexion>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT * FROM BitacoraConexiones";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            BitacoraConexion bitacora = new BitacoraConexion()
                            {
                                BitacoraID = Convert.ToInt32(dr["BitacoraID"]),
                                FechaConexion = Convert.ToDateTime(dr["FechaConexion"]),
                                Empleado = new Empleados()
                                {
                                    EmpleadoID = Convert.IsDBNull(dr["EmpleadoID"]) ? 0 : Convert.ToInt32(dr["EmpleadoID"])
                                },
                                Cliente = new Clientes()
                                {
                                    ClienteID = Convert.IsDBNull(dr["ClienteID"]) ? 0 : Convert.ToInt32(dr["ClienteID"])
                                }
                            };

                            // Verificar si la columna "FechaDesconexion" no es DBNull.Value antes de convertir
                            if (dr["FechaDesconexion"] != DBNull.Value)
                            {
                                bitacora.FechaDesconexion = Convert.ToDateTime(dr["FechaDesconexion"]);
                            }

                            Listar.Add(bitacora);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Listar = new List<BitacoraConexion>();
                Console.WriteLine("Error al listar conexiones: " + ex.Message);
            }

            return Listar;
        }


    }
}
