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
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            dgvProveedores.DataSource = negocio.listarSP();
            dgvProveedores.DataBind();
        }

        protected void dgvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}