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

            try
            {
                if (!IsPostBack)
                {
                    txtIdMarca.Enabled = false;
                    ddlProductoMarca.Items.Add("Marca");
                }

                string idMarca = Request.QueryString["IdMarca"] != null ? Request.QueryString["IdMarca"].ToString() : "";

                if (idMarca != "" && !IsPostBack)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca seleccionado = (negocio.listar(idMarca))[0];

                    txtIdMarca.Text = idMarca;
                    txtNombre.Text = seleccionado.NombreMarca;

                }

            }
            catch (Exception ex)
            {

                throw;
            }
 

 
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            string Seleccionado = ddlProductoMarca.SelectedItem.ToString();
            if (Seleccionado== "Marca" && txtNombre.Text != "")
            {

                Response.Redirect("registroMarcas.aspx", false);
                MarcaNegocio negocio = new MarcaNegocio();
                Marca marca = new Marca();
                marca.NombreMarca = txtNombre.Text;
                if (Request.QueryString["IdMarca"] != null)
                {
                    marca.Id = Int64.Parse(txtIdMarca.Text);
                    negocio.modificarConSP(marca);
                }
                else
                {
                    negocio.agregar(marca);
                }

                Response.Redirect("registroCategorias.aspx", false);
                
            }
            else
            {
                noHayRegistro = true;
                lblAlertError.Text = "Recuerde llenar los campos!";
            }

        }
    }
}