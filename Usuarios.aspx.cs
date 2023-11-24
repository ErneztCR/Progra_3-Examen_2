using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TallerDeReparaciones.clases;

namespace TallerDeReparaciones
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarCodigo();
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
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

        protected void LlenarCodigo()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select UsuarioID from Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownList1.DataSource = dt;

                            DropDownList1.DataValueField = dt.Columns["UsuarioID"].ToString();
                            DropDownList1.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarGridConsultar()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios WHERE UsuarioID = '" + DropDownList1.SelectedValue + "'"))
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = ClaseUsuarios.Agregar(TextBoxusername.Text, TextBoxemail.Text, TextBoxphonenumber.Text);

            if (resultado > 0)
            {
                alertas("Usuario agregado correctamente");
                TextBoxusername.Text = string.Empty;
                TextBoxemail.Text = string.Empty;
                TextBoxphonenumber.Text = string.Empty;
                LlenarGrid();
                LlenarCodigo();
            }
            else
            {
                alertas("Error al agregar al usuario");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = ClaseUsuarios.Borrar(Convert.ToInt32(DropDownList1.SelectedValue));

            if (resultado > 0)
            {
                alertas("Usuario eliminado correctamente");
                LlenarGrid();
                LlenarCodigo();
            }
            else
            {
                alertas("Error al eliminar al usuario");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = ClaseUsuarios.Modificar(Convert.ToInt32(DropDownList1.SelectedValue), TextBoxusername.Text, TextBoxemail.Text, TextBoxphonenumber.Text);

            if (resultado > 0)
            {
                alertas("Usuario modificado correctamente");
                TextBoxusername.Text = string.Empty;
                TextBoxemail.Text = string.Empty;
                TextBoxphonenumber.Text = string.Empty;
                LlenarGrid();
                LlenarCodigo();
            }
            else
            {
                alertas("Error al modificar al usuario");
            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            LlenarGridConsultar();
        }
    }
}
