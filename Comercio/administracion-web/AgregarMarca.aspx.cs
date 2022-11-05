using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace administracion_web
{
     

    public partial class AgregarMarca : System.Web.UI.Page
    {
       public bool noHayRegistro = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdMarca.Enabled = false;
            

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            

            
            if (txtNombreMarca.Text != "")
            {
                Response.Redirect("registroProductos.aspx", false);
                MarcaNegocio negocio = new MarcaNegocio();
                Marca marca = new Marca();
                marca.NombreMarca = txtNombreMarca.Text;
                negocio.agregar(marca);
            }
            else
            {
                noHayRegistro = true;
                lblAlertError.Text = "Recuerde llenar los campos!";
            }

        }
    }
}