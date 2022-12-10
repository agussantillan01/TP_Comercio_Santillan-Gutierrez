using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace administracion_web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Falta agregar algo mas
            if (!(Page is Default))
            { 
            if (!Seguridad.sesionActiva(Session["Usuario"]))
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Login.aspx", false);
            Session.Clear();
        }
    }
}