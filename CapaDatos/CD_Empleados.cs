using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Empleados
    {
        public List<Empleados> Listar_Empleados()
        {
            List<Empleados> Listar = new List<Empleados>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT E.EmpleadoID, E.Nombre, E.Apellidos, E.RFC, E.Direccion, E.Telefono, E.Correo, E.Contraseña, E.RolID, E.esActivo, E.FechaRegistro, E.FechaInactividad, R.NombreRol " +
                                    "FROM Empleados E " +
                                    "INNER JOIN Roles R ON E.RolID = R.RolID";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Listar.Add(
                                new Empleados()
                                {
                                    EmpleadoID = Convert.ToInt32(dr["EmpleadoID"]),
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
            catch
            {
                Listar = new List<Empleados>();
            }

            return Listar;
        }

        public int RegistrarEmpleado(Empleados obj, out string Mensaje)
        {
            int IdAutogenerado = 0;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarEmpleado", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("RFC", obj.RFC);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.AddWithValue("RolID", obj.Rol.RolID);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdAutogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch(Exception ex)
            {
                IdAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return IdAutogenerado;
        }


        public bool EditarEmpleado(Empleados obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarEmpleado", oconexion);
                    cmd.Parameters.AddWithValue("EmpleadoID", obj.EmpleadoID);
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

        public bool InhabilitarEmpleado(int id)
        {
            bool Resultado = false;

            try
            {
                string query = "UPDATE Empleados " +
                               "SET EsActivo = 0, " +
                               "FechaInactividad = GETDATE() " +
                               "WHERE EmpleadoID = @EmpleadoID";

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@EmpleadoID", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }catch(Exception ex)
            {
                Resultado = false;
            }
            return Resultado;
        }

        public bool HabilitarEmpleado(int id)
        {
            bool Resultado = false;

            try
            {
                string query = "UPDATE Empleados " +
                               "SET EsActivo = 1, " +
                               "FechaInactividad = null " +
                               "WHERE EmpleadoID = @EmpleadoID";

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@EmpleadoID", id);
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
