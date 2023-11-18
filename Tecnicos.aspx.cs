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
    public partial class Tecnicos : System.Web.UI.Page
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

        protected void LlenarCodigo()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select TecnicoID from Tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownList1.DataSource = dt;

                            DropDownList1.DataValueField = dt.Columns["TecnicoID"].ToString();
                            DropDownList1.DataBind();
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = ClaseTecnicos.Agregar(TextBoxtechname.Text, TextBoxespecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico agregado correctamente");
                TextBoxtechname.Text = string.Empty;
                TextBoxespecialidad.Text = string.Empty;
                LlenarGrid();
                LlenarCodigo();
            }
            else
            {
                alertas("Error al agregar al Tecnico");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = ClaseTecnicos.Borrar(Convert.ToInt32(DropDownList1.SelectedValue));

            if (resultado > 0)
            {
                alertas("Tecnico eliminado correctamente");
                LlenarGrid();
                LlenarCodigo();
            }
            else
            {
                alertas("Error al eliminar el tecnico");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = ClaseTecnicos.Modificar(Convert.ToInt32(DropDownList1.SelectedValue), TextBoxtechname.Text, TextBoxespecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico modificado correctamente");
                TextBoxtechname.Text = string.Empty;
                TextBoxespecialidad.Text = string.Empty;
                LlenarGrid();
                LlenarCodigo();
            }
            else
            {
                alertas("Error al modificar el Tecnico");
            }

        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int resultado = ClaseTecnicos.Consultar(Convert.ToInt32(DropDownList1.SelectedValue));

            if (resultado > 0)
            {
                alertas("Tecnico encontrado");
                TextBoxtechname.Text = ClaseTecnicos.Nombre;
                TextBoxespecialidad.Text = ClaseTecnicos.Especialidad;
            }
            else
            {
                alertas("Tecnico no encontrado");
            }

        }
    }
}
