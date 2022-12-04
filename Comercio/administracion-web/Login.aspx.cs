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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtEmail.Text, txtPassword.Text,false);
                if (usuarioNegocio.Loguear(usuario)) {
                    Session.Add("usuario", usuario);
                    Response.Redirect("registroProductos.aspx",false);
                }
                else
                {
                    Session.Add("Error", "Email o contraseña incorrecta");
                    Response.Redirect("ErrorLogin.aspx",false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("ErrorLogin.aspx", false);

            }
            
        }
    }
}