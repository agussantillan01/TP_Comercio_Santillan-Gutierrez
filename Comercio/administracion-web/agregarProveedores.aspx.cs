using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
                {
                    txtIdProveedores.Enabled = false;
                }
                string idProveedor = Request.QueryString["IdProveedor"] != null ? Request.QueryString["IdProveedor"].ToString() : "";
                if (idProveedor != "" && !IsPostBack)
                {
                    ProveedorNegocio negocio = new ProveedorNegocio();
                    Proveedor seleccionado = (negocio.listar(idProveedor))[0];

                    txtIdProveedores.Text = idProveedor;
                    txtNombre.Text = seleccionado.Nombre;
                    txtEmail.Text = seleccionado.Email;
                    txtCuil.Text = seleccionado.Cuil;
                    txtDomicilio.Text = seleccionado.Domicilio;
                    
                }
            }
            catch (Exception)
            {


                Session.Add("Error", "Campos incorrectos");
                Response.Redirect("Error.aspx", false);
            }
            

        }

       

        protected void btnAceptar_Click2(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && txtDomicilio.Text != "" && txtCuil.Text != "")
                {

                    ProveedorNegocio negocio = new ProveedorNegocio();
                    Proveedor proveedores = new Proveedor();
                    proveedores.Nombre = txtNombre.Text;
                    proveedores.Domicilio = txtDomicilio.Text;
                    proveedores.Email = txtEmail.Text;
                    proveedores.Cuil = txtCuil.Text;
                    if (Request.QueryString["IdProveedor"] != null)
                    {
                        proveedores.Id = Int64.Parse(txtIdProveedores.Text);
                        negocio.modificarConSP(proveedores);
                    }
                    else
                    {
                        negocio.agregarConSP(proveedores);
                    }

                    Response.Redirect("registroProveedores.aspx", false);



                }
            }
            catch (Exception)
            {

                Session.Add("Error", "Campos incorrectos");
                Response.Redirect("Error.aspx", false);
            }
           


        }
    }
}