using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TallerDeReparaciones.clases
{
    public class ClaseEquipos
    {
        // Variables
        public static int EquipoID { get; set; }
        public static string TipoEquipo { get; set; }
        public static string Modelo { get; set; }
        public static string UsuarioID { get; set; }

        // Constructor
        public ClaseEquipos(int equipoID, string tipoequipo, string modelo, string usuarioid)
        {
            EquipoID = equipoID;
            TipoEquipo = tipoequipo;
            Modelo = modelo;
            UsuarioID = usuarioid;
        }

        public ClaseEquipos() { }

        public static int Agregar(string tipoequipo, string modelo, string usuarioid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarEquipo", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TipoEquipo", tipoequipo));
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Modelo", modelo));
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UsuarioID", usuarioid));

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

        public static int Borrar(int EquipoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarEquipo", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EquipoID", EquipoID));

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

        public static int Modificar(int EquipoID, string tipoequipo, string modelo, string usuarioid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", EquipoID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipoequipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioid));

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

        public static int Consultar(int EquipoID)
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
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", EquipoID));

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
