using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace administracion_web
{
    public partial class registroUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            dgvUsuario.DataSource = negocio.listarSP();
            dgvUsuario.DataBind();
        }
        protected void dgvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 id = (Int64.Parse(dgvUsuario.SelectedDataKey.Value.ToString()));
            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.HacerAdmin(id);
            Response.Redirect("registroUsuarios.aspx");

        }

    }
}