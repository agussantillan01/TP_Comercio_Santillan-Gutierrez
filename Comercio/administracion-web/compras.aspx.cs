using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace administracion_web
{
    public partial class compras : System.Web.UI.Page
    {
        public Int64 idTipo;
        public Int64 idMarca;


        protected void Page_Load(object sender, EventArgs e)
        {
             CompraNegocio negocioCompra = new CompraNegocio();
            dgvCompras.DataSource = negocioCompra.listar();
            dgvCompras.DataBind();
            txtId.Enabled = false;
            ddlMarca.Enabled = true;
            ddlProducto.Enabled = true;
            ProveedorNegocio negocioProveedor = new ProveedorNegocio();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();

            if (!IsPostBack)
            {
                //Completo el desplegable de Productos
                List<Producto> listaProducto = negocioProducto.listar();
                Session["listaProducto"] = listaProducto;

                //Completo el desplegable de Proveedor
                List<Proveedor> listaProveedor = negocioProveedor.listarSP();
                ddlProveedor.DataSource = listaProveedor;
                ddlProveedor.DataValueField = "Id";
                ddlProveedor.DataTextField = "Nombre";
                ddlProveedor.DataBind();

                //Completo el desplegable de Categoria
                List<Tipo> listaCategoria = negocioCategoria.listar();
                ddlCategoria.DataSource = listaCategoria;
                ddlCategoria.DataValueField = "IdTipo";
                ddlCategoria.DataTextField = "NombreTipo";
                ddlCategoria.DataBind();

                List<Marca> listaMarca = negocioMarca.listar();
                ddlMarca.DataSource = listaMarca;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "NombreMarca";
                ddlMarca.DataBind();

                //FALTA CAMBIAR ESTO
           /*     txtId.Text = id;
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtStock.Text = seleccionado.stock.ToString();
                txtStockMinimo.Text = seleccionado.stockMinimo.ToString();
                txtPrecio.Text = seleccionado.Precio.ToString();

                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                ddlTipo.SelectedValue = seleccionado.Tipo.IdTipo.ToString();
           */

            }

        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMarca.Enabled = true;
            idTipo = Int64.Parse(ddlCategoria.SelectedItem.Value);
            ddlProducto.DataSource = ((List<Producto>)Session["listaProducto"]).FindAll(x => x.Tipo.IdTipo == idTipo);
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataBind();


        }


        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMarca = Int64.Parse(ddlMarca.SelectedItem.Value);
            idTipo = Int64.Parse(ddlCategoria.SelectedItem.Value);
            ddlProducto.DataSource = ((List<Producto>)Session["listaProducto"]).FindAll((x => x.Marca.Id == idMarca && x.Tipo.IdTipo == idTipo ));



            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataBind();
            ddlProducto.Enabled = true;
        }

   
        protected void btnSumarProducto_Click(object sender, EventArgs e)
        {
         // FIJARSE SI LE AGREGAMOS UN BOOL PARA VER SI EXISTE ?
         if (int.Parse(ddlProducto.SelectedItem.Value)== 0)
            {
              // VALIDAR
            }
                
            
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            /* FALTA CAMBIAR TODO  {
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

                  if (Request.QueryString["Id"] != null)
                  {
                      nuevo.Id = Int64.Parse(txtId.Text);
                      negocio.modificarConSP(nuevo);

                  }
                  else
                  {
                      bool fueEncontrado = seEncontroProducto(nuevo.Nombre.ToUpper());
                      if (fueEncontrado)
                      {
                          Console.WriteLine("El producto ya fue registrado");
                          lblError.Text = "El Producto " + nuevo.Nombre + " ya se ha registrado.";
                      }
                      else
                      {
                          negocio.agregarConSP(nuevo);
                          Response.Redirect("registroProductos.aspx", false);
                      }
                  }

            */
        }


    }
}