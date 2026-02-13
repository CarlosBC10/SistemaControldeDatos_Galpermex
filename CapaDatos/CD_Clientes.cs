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
    public class CD_Clientes {

        public List<Clientes> Listar_Clientes()
        {
            List<Clientes> Listar = new List<Clientes>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT C.ClienteID, C.Nombre, C.Apellidos, C.RFC, C.Direccion, C.Telefono, C.Correo, C.Contraseña, C.RolID, C.esActivo, C.FechaRegistro, C.FechaInactividad, R.NombreRol " +
                                    "FROM Clientes C " +
                                    "INNER JOIN Roles R ON C.RolID = R.RolID";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Listar.Add(
                                new Clientes()
                                {
                                    ClienteID = Convert.ToInt32(dr["ClienteID"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    RFC = dr["RFC"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Contraseña = dr["Contraseña"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                    FechaInactividad = dr["FechaInactividad"] != DBNull.Value ? (DateTime?)dr["FechaInactividad"] : null,
                                    EsActivo = Convert.ToBoolean(dr["esActivo"]),
                                    // Crea una instancia de Roles y asigna sus propiedades
                                    Rol = new Roles()
                                    {
                                        RolID = Convert.ToInt32(dr["RolID"]),
                                        NombreRol = dr["NombreRol"].ToString()
                                    }
                                });
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al listar Clientes: " + ex.Message);
                Listar = new List<Clientes>();
            }

            return Listar;
        }

        public int RegistrarCliente(Clientes obj, out string Mensaje)
        {
            int IdAutogenerado = 0;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("RFC", obj.RFC);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdAutogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return IdAutogenerado;
        }

        public bool EditarCliente(Clientes obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCliente", oconexion);
                    cmd.Parameters.AddWithValue("ClienteID", obj.ClienteID);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("RFC", obj.RFC);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }

        public bool InhabilitarCliente(int id, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {
                string query = "UPDATE Cliente " +
                               "SET EsActivo = 0, " +
                               "FechaInactividad = GETDATE() " +
                               "WHERE ClienteID = @ClienteID";

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@ClienteID", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }

        public bool InhabilitarCliente(int id)
        {
            bool Resultado = false;

            try
            {
                string query = "UPDATE Clientes " +
                               "SET EsActivo = 0, " +
                               "FechaInactividad = GETDATE() " +
                               "WHERE ClienteID = @ClienteID";

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@ClienteID", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
            }
            return Resultado;
        }

        public bool HabilitarCliente(int id)
        {
            bool Resultado = false;

            try
            {
                string query = "UPDATE Clientes " +
                               "SET EsActivo = 1, " +
                               "FechaInactividad = null " +
                               "WHERE ClienteID = @ClienteID";

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@ClienteID", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
            }
            return Resultado;
        }

    }
}
