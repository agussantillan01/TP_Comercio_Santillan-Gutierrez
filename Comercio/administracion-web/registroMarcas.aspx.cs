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
    public partial class registroMarcas : System.Web.UI.Page
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
                MarcaNegocio negocio = new MarcaNegocio();
                dgvMarcas.DataSource = negocio.listarSP();
                dgvMarcas.DataBind();

            }

        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idMarca = dgvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarMarca.aspx?IdMarca=" + idMarca);


        }
    }
}