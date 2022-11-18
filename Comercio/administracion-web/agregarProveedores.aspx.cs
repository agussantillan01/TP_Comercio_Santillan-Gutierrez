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
    public partial class agregarProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    txtIdProveedores.Enabled = false;
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

       

        protected void btnAceptar_Click2(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDomicilio.Text != "" && txtCuil .Text!= "")
            {
                Response.Redirect("registroProveedores.aspx", false);
                ProveedoresNegocio negocio = new ProveedoresNegocio();
                Proveedores proveedores = new Proveedores();
                proveedores.Nombre = txtNombre.Text;
                proveedores.Domicilio = txtDomicilio.Text;
                proveedores.Email = txtEmail.Text;
                proveedores.Cuil = txtCuil.Text;
                negocio.agregarConSP(proveedores);


            }


        }
    }
}