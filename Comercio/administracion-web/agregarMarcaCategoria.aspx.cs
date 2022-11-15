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
        public bool Modificacion { get; set; }
        public bool noHayRegistro = false;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            Modificacion = false;
            if (!IsPostBack) { 
            txtIdMarca.Enabled = false;
            ddlProductoMarca.Items.Add("--Seleccione un Item--");
            ddlProductoMarca.Items.Add("Marca");
            ddlProductoMarca.Items.Add("Categoria");

                MarcaNegocio negocioMarca = new MarcaNegocio();
                List<Marca> listaMarca = negocioMarca.listar();
                ddlMarca.DataSource = listaMarca;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "NombreMarca";
                ddlMarca.DataBind();
            }

 
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            string Seleccionado = ddlProductoMarca.SelectedItem.ToString();
            if (Seleccionado== "Marca" && txtNombre.Text != "")
            {

                Response.Redirect("registroProductos.aspx", false);
                MarcaNegocio negocio = new MarcaNegocio();
                Marca marca = new Marca();
                marca.NombreMarca = txtNombre.Text;
                negocio.agregar(marca);
            }
            else if (Seleccionado == "Categoria" && txtNombre.Text != "")
            {
                Response.Redirect("registroProductos.aspx", false);
                CategoriaNegocio negocio = new CategoriaNegocio();
                Tipo tipo = new Tipo();
                tipo.NombreTipo = txtNombre.Text;
                negocio.agregar(tipo);
            }
            else
            {
                noHayRegistro = true;
                lblAlertError.Text = "Recuerde llenar los campos!";
            }

        }

        protected void BtnModificarMarca_Click(object sender, EventArgs e)
        {
            Modificacion = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
           

            MarcaNegocio negocio = new MarcaNegocio();
            Marca marca = new Marca();
            marca.NombreMarca = TxtNuevaMarca.Text;
            negocio.modificarConSP(marca, int.Parse(ddlMarca.SelectedValue));
   
            Response.Redirect("registroProductos.aspx", false);


        }
    }
}