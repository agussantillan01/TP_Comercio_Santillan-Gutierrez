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
                {
                    txtIdCliente.Enabled = false;

                }
                string idCliente = Request.QueryString["IdCliente"] != null ? Request.QueryString["IdCliente"].ToString() : "";
                if (idCliente != "" && !IsPostBack)
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente seleccionado = (negocio.listar(idCliente))[0];

                    txtIdCliente.Text = idCliente;
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtEmail.Text = seleccionado.Email;
                    txtFechaNacimiento.Text = "HOLAAAA";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

       

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtApellido.Text != "" || txtFechaNacimiento.Text != "")
            {
                
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                if(Request.QueryString["IdCliente"] != null)
                {
                    cliente.Id = Int64.Parse(txtIdCliente.Text);
                    negocio.modificarConSP(cliente);
                }
                else
                {
                    negocio.agregarConSP(cliente);
                }
                Response.Redirect("registroClientes.aspx", false);


            }


        }
    }
}