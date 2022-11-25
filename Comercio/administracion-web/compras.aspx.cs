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
        public List<Compra> ListaEnCarrito;
        public decimal PrecioTotal =0;


        protected void Page_Load(object sender, EventArgs e)
        {

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
            ddlProducto.DataBind();
            ddlProducto.Enabled = true;
        }


        protected void btnSumarProducto_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            string nombreProductoSeleccionado = ddlProducto.SelectedItem.Value.ToString(); //nombre del Producto Seleccionado
            //Guardo en la lista completa de Productos
            ProductoNegocio negocioProducto = new ProductoNegocio();
            List<Producto> listaProducto = negocioProducto.listar();
            foreach (var item in listaProducto) // Recorro la lista completa de productos
            {
                if (item.Nombre.ToString() == nombreProductoSeleccionado) // si el nombre del producto = producto seleccionado
                {
                    compra.Producto = item; // Lleno el producto, en la compra realizada
                    break;
                }
            }


            string idProveedor = ddlProveedor.SelectedItem.Value.ToString(); // ID Del proveedor seleccionado
            //en la variable prove = proveedor con id igual a idProveedor seleccionado
            ProveedorNegocio negocioProveedor = new ProveedorNegocio();
            Proveedor prove = negocioProveedor.listar(idProveedor)[0];
            // Lleno el Proveedor, en la compra realizada
            compra.Proveedor = prove;
            // Lleno la cantidad, en la compra realizada
            compra.Cantidad = Int16.Parse(txtCantidad.Text);
            compra.Precio = decimal.Parse(txtPrecio.Text);

            if (ListaEnCarrito == null) // si no hay una compra en la lista
            {
                ListaEnCarrito = new List<Compra>();
                ListaEnCarrito.Add(compra); //agrego la compra que cargue anteriormente
                PrecioTotal = decimal.Parse(txtPrecio.Text) * Int16.Parse(txtCantidad.Text); // calculo el precio total 
            }

       



        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }


    }
}