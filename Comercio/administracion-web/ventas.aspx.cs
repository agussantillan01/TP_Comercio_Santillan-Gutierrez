using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace administracion_web
{
    public partial class ventas : System.Web.UI.Page
    {
        Int64 idCliente;
        Int64 idProducto;

        public listaTotalVenta carrito = new listaTotalVenta();
        public List<Venta> listaEnCarrito;

        ClienteNegocio negocioCliente = new ClienteNegocio();
        ProductoNegocio negocioProducto = new ProductoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPrecio.Enabled = false;
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                ProductoNegocio productoNegocio = new ProductoNegocio();
                if (!IsPostBack)
                {
                    List<Cliente> listaClientes = clienteNegocio.listarSP();
                    ddlClientes.DataSource = listaClientes;
                    ddlClientes.DataValueField = "Id";
                    ddlClientes.DataTextField = "Nombre";
                    ddlClientes.DataBind();

                    List<Producto> listProductos = productoNegocio.listar();
                    ddlProductos.DataSource = listProductos;
                    ddlProductos.DataValueField = "Id";
                    ddlProductos.DataTextField = "Nombre";
                    ddlProductos.DataBind();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        protected void btnSumarProducto_Click(object sender, EventArgs e)
        {

            bool noHayStockSuficiente = AlertaNoHayStock(); // si el cantidad ingresada supera el stock, aparece una alerta
            bool ProductoYaSeleccionado = false;
            idProducto = Int64.Parse(ddlProductos.SelectedItem.Value);
            idCliente = Int64.Parse(ddlClientes.SelectedItem.Value);


            listaEnCarrito = (List<Venta>)Session["listaVentaEnCarro"];
            carrito = (listaTotalVenta)Session["TotalVenta"];
            
            if (!noHayStockSuficiente && idProducto != 0 && idCliente != 0) // valido que se completen todos los campos
            {
                listaEnCarrito = (List<Venta>)Session["listaVentaEnCarro"];
                carrito = (listaTotalVenta)Session["TotalVenta"];
            
            
                if (listaEnCarrito == null)
                    listaEnCarrito = new List<Venta>();
            
                if (carrito == null)
                    carrito = new listaTotalVenta();
                else
                {
                    foreach (Venta item in carrito.listado)
                    {
                        if (item.Producto.Id == idProducto)
                            ProductoYaSeleccionado = true;
                    }
                }

                if (!ProductoYaSeleccionado)
                {
                    List<Cliente> listaCliente = negocioCliente.listar();
                    List<Producto> listaProducto = negocioProducto.listar();

                    Venta aux = new Venta();
                    aux.Cliente = listaCliente.Find(x => x.Id == idCliente);
                    aux.Producto = listaProducto.Find(x => x.Id == idProducto);
                    aux.Cantidad= Int16.Parse(txtCantidad.Text);
                    aux.Precio = aux.Cantidad * aux.Producto.Precio;

                    carrito.total += aux.Precio * aux.Cantidad;
                    listaEnCarrito.Add(aux);
                    carrito.listado = listaEnCarrito;
                    

                }
                tabla_productosVenta.DataSource = listaEnCarrito;
                tabla_productosVenta.DataBind();
                lblPrecioTotal.Text = "Total: $" + carrito.total.ToString("00.00");
                Session.Add("listaVentaEnCarro", listaEnCarrito);
                Session.Add("TotalVenta", carrito);

            }





            





        }




        public bool AlertaNoHayStock()
        {
            if (IsPostBack)
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                List<Producto> listProductos = productoNegocio.listar();


                int cantidad = int.Parse(txtCantidad.Text);
                idProducto = Int64.Parse(ddlProductos.SelectedItem.Value);
                Producto prod = listProductos.Find(x => x.Id == idProducto);
                if (cantidad > prod.stock)
                {
                    string msjError = "Error!, hay " + prod.stock + " productos en stock";
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                     "alert('" + msjError + "'); ", true);
                    txtCantidad.Text = "1";
                    prod = null;
                    return true;
                }



            }
            return false;

        }
        protected void ddlClientes_DataBound(object sender, EventArgs e)
        {
            ddlClientes.Items.Insert(0, "--Seleccione un cliente--");
        }

        protected void ddlProductos_DataBound(object sender, EventArgs e)
        {
            ddlProductos.Items.Insert(0, "--Seleccione una Marca--");
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCliente = Int64.Parse(ddlClientes.SelectedItem.Value);
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProducto = Int64.Parse(ddlProductos.SelectedItem.Value);

        }
    }
}