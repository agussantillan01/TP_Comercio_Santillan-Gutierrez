using negocio;
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
            if (Session["usuario"] == null)
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
    }
}