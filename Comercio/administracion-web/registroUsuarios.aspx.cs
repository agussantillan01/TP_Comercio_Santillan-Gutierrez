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
        public List<Usuario> cantidadUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte!");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
                string emailParametro = (string)Session["emailParametro"];
                UsuarioNegocio negocio = new UsuarioNegocio();


                if (!IsPostBack)
                {
                    cantidadUsuario = negocio.listarSP(emailParametro);
                    if (cantidadUsuario.Count() != 0)
                    {
                        dgvUsuario.DataSource = negocio.listarSP(emailParametro);
                        dgvUsuario.DataBind();


                    }
                    else
                    {
                        dgvUsuario.DataSource = null;
                    }
                }
            }


        }
        protected void dgvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 id = (Int64.Parse(dgvUsuario.SelectedDataKey.Value.ToString()));
            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.HacerAdmin(id);

            dgvUsuario.DataSource = null;
            string emailParametro = (string)Session["emailParametro"];
            dgvUsuario.DataSource = negocio.listarSP(emailParametro);
            dgvUsuario.DataBind();
            Response.Redirect("registroUsuarios.aspx");

        }

    }
}