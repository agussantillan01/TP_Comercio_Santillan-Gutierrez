using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace administracion_web
{
    public partial class paginaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte!");
                Response.Redirect("ErrorLogin.aspx",false);
            }else
            {
                ProductoNegocio negocio = new ProductoNegocio();
                dgvProductos.DataSource = negocio.listar();
                dgvProductos.DataBind();
            }
  
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarProducto.aspx?Id=" + id);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ProductoNegocio Negocio = new ProductoNegocio();
            try
            {
                if(Buscador.Text == "")
                {
                    dgvProductos.DataSource = Negocio.listar();
                    dgvProductos.DataBind();

                }
                else
                {
                    dgvProductos.DataSource= Negocio.listarConFiltro(Buscador.Text.ToString());
                    dgvProductos.DataBind();
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
        private string armaConsultaFiltro()
        {
            string consulta = "";
            if (Buscador.Text != "")
            {
                consulta += "A.Nombre LIKE '%" + Buscador.Text.ToString() + "%'";

            }


            return consulta;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }
    }
}