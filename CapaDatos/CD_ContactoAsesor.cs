using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_ContactoAsesor
    {
        public List<ContactoAsesores> Listar_ContactoAsesor()
        {
            string error;
            List<ContactoAsesores> Listar = new List<ContactoAsesores>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT C.ContactoID, C.Nombre, C.Apellidos, C.Correo, C.Telefono, C.Mensaje, C.FechaRegistro, C.status, C.AsuntoID, A.Asunto " +
                                   "FROM ContactoAsesores C " +
                                   "INNER JOIN Asunto_Contacto A ON C.AsuntoID = A.AsuntoID";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Listar.Add(
                                new ContactoAsesores()
                                {
                                    ContactoID = Convert.ToInt32(dr["ContactoID"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Mensaje = dr["Mensaje"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                    status = Convert.IsDBNull(dr["status"]) ? false : Convert.ToBoolean(dr["status"]),
                                    // Crea una instancia de Roles y asigna sus propiedades
                                    Asunto = new Asunto_Contacto()
                                    {
                                        AsuntoID = Convert.ToInt32(dr["AsuntoID"]),
                                        Asunto = dr["Asunto"].ToString()
                                    }
                                });
                        }
                    }
                }

            }
            catch (Exception ex)
            { 
                error = ex.Message;
                Listar = new List<ContactoAsesores>();
            }

            return Listar;
        }


        public int RegistrarSolicitudAsesor(ContactoAsesores obj, out string Mensaje)
        {
            int IdAutogenerado = 0;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarSolicitudAsesor", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("AsuntoID", obj.Asunto.AsuntoID);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Mensaje", obj.Mensaje);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("MensajeOut", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdAutogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["MensajeOut"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return IdAutogenerado;
        }

        public bool MsgLeido(int id)
        {
            bool Resultado = false;
            string error;
            try
            {
                string query = "UPDATE ContactoAsesores " +
                               "SET status = 1 " +
                               "WHERE ContactoID = @ContactoID";

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@ContactoID", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Resultado = false;
            }
            return Resultado;
        }

        public bool BorrarMensaje(int id)
        {
            bool Resultado = false;
            string error;
            try
            {
                string query = "DELETE FROM ContactoAsesores WHERE ContactoID = @ContactoID";

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@ContactoID", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Resultado = false;
            }
            return Resultado;
        }


    }
}
