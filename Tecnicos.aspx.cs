using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TallerDeReparaciones
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }
    }
}