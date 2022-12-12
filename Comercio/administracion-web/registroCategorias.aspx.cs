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
    public partial class registroCategorias : System.Web.UI.Page
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
                CategoriaNegocio negocio = new CategoriaNegocio();
                dgvCategorias.DataSource = negocio.listarSP();
                dgvCategorias.DataBind();
            }

        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCategoria = dgvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarCategoria.aspx?IdCategoria=" + idCategoria);
        }
    }
}