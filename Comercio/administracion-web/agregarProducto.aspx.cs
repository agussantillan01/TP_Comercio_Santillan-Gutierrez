using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace administracion_web
{
    public partial class agregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Completo el desplegable de Categoria
                    CategoriaNegocio negocioTipo = new CategoriaNegocio();
                    List<Tipo> listaTipo = negocioTipo.listar();
                    ddlTipo.DataSource = listaTipo;
                    ddlTipo.DataValueField = "IdTipo";
                    ddlTipo.DataTextField = "NombreTipo";
                    ddlTipo.DataBind();

                    //Completo el desplegable de marcas
                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    List<Marca> listaMarca = negocioMarca.listar();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "NombreMarca";
                    ddlMarca.DataBind();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }

        //public string Nombre { get; set; }
        //public Tipo Tipo { get; set; }
        //public string Descripcion { get; set; }
        //public Marca Marca { get; set; }
        //public int stock { get; set; }
        //public int stockMinimo { get; set; }
        //public decimal Precio { get; set; }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto();
            ProductoNegocio negocio = new ProductoNegocio();
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.stock = int.Parse(txtStock.Text);
            nuevo.stockMinimo = int.Parse(txtStockMinimo.Text);
            nuevo.Precio = decimal.Parse(txtPrecio.Text);

            nuevo.Tipo = new Tipo();
            nuevo.Tipo.IdTipo = Int64.Parse(ddlTipo.SelectedValue);

            nuevo.Marca = new Marca();
            nuevo.Marca.Id = Int64.Parse(ddlMarca.SelectedValue);

            negocio.agregarConSP(nuevo);
            Response.Redirect("registroProductos.aspx", false);

        }
    }
}