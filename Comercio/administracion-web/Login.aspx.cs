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

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string email;
            string pass;
            email = txtEmail.Text;
            pass = txtPassword.Text;

            //llamado al SP_validacionUsuario 
            // si NO devuelve nulo 
            Response.Redirect("registroProductos.aspx?IdUsuario=" + 1, false); // mando IdUsuario obtnido en el SP
        }
    }
}