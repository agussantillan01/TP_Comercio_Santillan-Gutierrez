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
    public partial class agregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    txtIdCliente.Enabled = false;
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

       

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtFechaNacimiento.Text != "")
            {
                Response.Redirect("registroClientes.aspx", false);
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                negocio.agregarConSP(cliente);


            }


        }
    }
}