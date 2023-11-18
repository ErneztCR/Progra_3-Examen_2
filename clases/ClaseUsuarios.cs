using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TallerDeReparaciones.clases
{
    public class ClaseUsuarios
    {
        // Variables
        public static int UsuarioID { get; set; }
        public static string Nombre { get; set; }
        public static string CorreoElectronico { get; set; }
        public static string Telefono { get; set; }

        // Constructor
        public ClaseUsuarios(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            UsuarioID = usuarioID;
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
        }

        public ClaseUsuarios() { }

        public static int Agregar(string nombre, string correo, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Borrar(int UsuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Modificar(int UsuarioID, string nombre, string correo, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Consultar(int UsuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}
