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
        public Int64 idProductoSeleccionado;


        public List<Compra> ListaCompra;
        public listaTotalProductos carrito = new listaTotalProductos();


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
        private List<Proveedor> listadoProveedores()
        {
            List<Proveedor> lista;
            ProveedorNegocio negocio = new ProveedorNegocio();
            lista = negocio.listar();
            return lista;
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
            ddlProducto.DataSource = ((List<Producto>)Session["listaProducto"]).FindAll((x => x.Marca.Id == idMarca && x.Tipo.IdTipo == idTipo));
            ddlProducto.DataBind();
            ddlProducto.Enabled = true;
        }


        protected void btnSumarProducto_Click(object sender, EventArgs e)
        {

            ddlProveedor.Enabled = false;
            bool ProductoYaSeleccionado = false;
            Int64 IdProveedor = Int64.Parse(ddlProveedor.SelectedItem.Value);

            string nombreProductoSeleccionado = ddlProducto.SelectedItem.Value.ToString(); //nombre del Producto Seleccionado
            //Guardo en la lista completa de Productos
            List<Producto> listaProducto = listadoProductos();
            foreach (var item in listaProducto) // Recorro la lista completa de productos
            {
                if (item.Nombre.ToString() == nombreProductoSeleccionado) // si el nombre del producto = producto seleccionado
                {
                    idProductoSeleccionado = item.Id;
                    break;
                }
            }

            //******* LISTA DE COMPRA*****************
            ListaCompra = (List<Compra>)Session["listaEnCarro"];
            carrito = (listaTotalProductos)Session["total"];
            bool IngresoCantidadIncorrecta = convierteTextoAInt(txtCantidad.Text);
            bool IngresoPrecioIncorrecto = convierteTextoADecimal(txtPrecio.Text);
            if (!IngresoCantidadIncorrecta && !IngresoPrecioIncorrecto)
            {
                if (ListaCompra == null)
                    ListaCompra = new List<Compra>();


                if (carrito == null)
                {
                    carrito = new listaTotalProductos();
                }
                else
                {
                    foreach (Compra item in carrito.listado)
                    {
                        if (item.Producto.Id == idProductoSeleccionado)
                            ProductoYaSeleccionado = true;
                    }
                }


                if (idProductoSeleccionado != 0 && !ProductoYaSeleccionado)
                {
                    Compra aux = new Compra();
                    aux.Cantidad = Int16.Parse(txtCantidad.Text);
                    aux.Precio = decimal.Parse(txtPrecio.Text);
                    foreach (var item in listaProducto)
                    {
                        if (item.Id == idProductoSeleccionado)
                        {
                            aux.Producto = item;
                            aux.Id = idProductoSeleccionado;
                            break;
                        }
                    }

                    List<Proveedor> listaProveedores = listadoProveedores();

                    aux.Proveedor = listaProveedores.Find(x => x.Id == IdProveedor);

                    carrito.total += aux.Precio * aux.Cantidad;
                    ListaCompra.Add(aux);

                    carrito.listado = ListaCompra;

                }
                tabla_productos.DataSource = ListaCompra;
                tabla_productos.DataBind();
                lblPrecioTotal.Text = "Total: $" + carrito.total.ToString("00.00");
                Session.Add("listaEnCarro", ListaCompra);
                Session.Add("total", carrito);
            }

            
        }

        protected void btnEliminarProductoLista_Click(object sender, EventArgs e)
        {
            carrito =(listaTotalProductos)Session["total"];
            Int64 idEliminarProducto= Int64.Parse(((Button)sender).CommandArgument);
            List<Compra> listaCompra = (List<Compra>)Session["listaEnCarro"];
            Compra elim = listaCompra.Find(x => x.Id == idEliminarProducto);
            listaCompra.Remove(elim);

            carrito.total -= elim.Precio * elim.Cantidad;
            if (carrito.total < 0) carrito.total = 0;
            lblPrecioTotal.Text = "Total: " + carrito.total.ToString("00.00");
            Session.Add("listaEnCarro", listaCompra);
            Session.Add("total", carrito);
            tabla_productos.DataSource = null;
            tabla_productos.DataSource = listaCompra;
            tabla_productos.DataBind();

            if(carrito.listado.Count()==0) ddlProveedor.Enabled = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
                
                carrito = (listaTotalProductos)Session["total"];
                CompraNegocio negocio = new CompraNegocio();

                foreach (Compra item in carrito.listado)
                {
                    negocio.agregarConSP(item);
                }

                carrito.listado.RemoveAll(i => i.Id != 0);
                Response.Redirect("registroProductos.aspx");


        }



        //FUNCIONES
        private bool convierteTextoAInt(string numeroCantidad)
        {
            if (Int16.TryParse(numeroCantidad, out Int16 cantidad))
            {
                return false;
            }
            return true;
        }
        private bool convierteTextoADecimal(string numero)
        {
            if (Decimal.TryParse(numero, out Decimal Precio))
            {
                return false;
            }
            return true;
        }
        private List<Producto> listadoProductos()
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            List<Producto> lista = negocioProducto.listar();
            return lista;
        }
        protected void ddlCategoria_DataBound(object sender, EventArgs e)
        {
            ddlCategoria.Items.Insert(0, "--Seleccione una categoria--");
        }

        protected void ddlMarca_DataBound(object sender, EventArgs e)
        {
            ddlMarca.Items.Insert(0, "--Seleccione una Marca--");
        }


    }
}