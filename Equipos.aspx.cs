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
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarCodigo();
                LlenarCodigo2();
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
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
                using (SqlCommand cmd = new SqlCommand("select EquipoID from Equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownList1.DataSource = dt;

                            DropDownList1.DataValueField = dt.Columns["EquipoID"].ToString();
                            DropDownList1.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarCodigo2()
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
                            DropDownListuserid.DataSource = dt;

                            DropDownListuserid.DataValueField = dt.Columns["UsuarioID"].ToString();
                            DropDownListuserid.DataBind();
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = ClaseEquipos.Agregar(TextBoxtipoequipo.Text, TextBoxmodel.Text, DropDownListuserid.SelectedValue);

            if (resultado > 0)
            {
                alertas("Equipo agregado correctamente");
                TextBoxtipoequipo.Text = string.Empty;
                TextBoxmodel.Text = string.Empty;
                LlenarGrid();
                LlenarCodigo();
                LlenarCodigo2();
            }
            else
            {
                alertas("Error al agregar el equipo");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = ClaseEquipos.Borrar(Convert.ToInt32(DropDownList1.SelectedValue));

            if (resultado > 0)
            {
                alertas("Equipo eliminado correctamente");
                LlenarGrid();
                LlenarCodigo();
                LlenarCodigo2();
            }
            else
            {
                alertas("Error al eliminar el equipo");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = ClaseEquipos.Modificar(Convert.ToInt32(DropDownList1.SelectedValue), TextBoxtipoequipo.Text, TextBoxmodel.Text, DropDownListuserid.SelectedValue);

            if (resultado > 0)
            {
                alertas("equipo modificado correctamente");
                TextBoxtipoequipo.Text = string.Empty;
                TextBoxmodel.Text = string.Empty;
                LlenarGrid();
                LlenarCodigo();
                LlenarCodigo2();
            }
            else
            {
                alertas("Error al modificar el equipo");
            }

        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int resultado = ClaseEquipos.Consultar(Convert.ToInt32(DropDownList1.SelectedValue));

            if (resultado > 0)
            {
                alertas("Equipo encontrado");
                TextBoxtipoequipo.Text = ClaseEquipos.TipoEquipo;
                TextBoxmodel.Text = ClaseEquipos.Modelo;
                DropDownListuserid.Text = ClaseEquipos.UsuarioID;
            }
            else
            {
                alertas("Equipo no encontrado");
            }

        }
    }
}
