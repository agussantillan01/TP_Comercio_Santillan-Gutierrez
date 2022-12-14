using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace administracion_web
{
    public partial class registroProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte!");
                Response.Redirect("ErrorLogin.aspx", false);
            }else
            {
                ProveedorNegocio negocio = new ProveedorNegocio();
                dgvProveedores.DataSource = negocio.listarSP();
                dgvProveedores.DataBind();
            }

        }

        protected void dgvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProveedor = dgvProveedores.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarProveedores.aspx?IdProveedor=" + idProveedor, false);
        }
    }
}