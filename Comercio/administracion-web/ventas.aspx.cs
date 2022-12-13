using dominio;
using negocio;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Xml.Linq;

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
            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte!");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
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
                catch (Exception)
                {

                    Session.Add("Error", "Error al completarse los datos");
                    Response.Redirect("Error.aspx", false);
                }
            }


        }


        protected void btnSumarProducto_Click(object sender, EventArgs e)
        {
            try
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
                        aux.Id = idProducto;
                        aux.Cliente = listaCliente.Find(x => x.Id == idCliente);
                        aux.Producto = listaProducto.Find(x => x.Id == idProducto);
                        aux.Cantidad = Int16.Parse(txtCantidad.Text);
                        aux.Precio = (aux.Cantidad * aux.Producto.Precio + (aux.Producto.Precio * aux.Producto.Porcentaje / 100));

                        carrito.total += aux.Precio;
                        listaEnCarrito.Add(aux);
                        carrito.listado = listaEnCarrito;


                    }
                    tabla_productosVenta.DataSource = listaEnCarrito;
                    tabla_productosVenta.DataBind();
                    lblPrecioTotal.Text = "Total: $" + carrito.total.ToString("00.00");
                    Session.Add("listaVentaEnCarro", listaEnCarrito);
                    Session.Add("TotalVenta", carrito);

                    ddlClientes.Enabled = false;

                }
            }
            catch (Exception)
            {

                Session.Add("Error", "Campos incorrectos. Revise los datos ingresados");
                Response.Redirect("Error.aspx", false);
            }



        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            //SaveFileDialog guardar = new SaveFileDialog();
            //guardar.FileName ="Boleta Nro " + NumVenta.ToString() + ".pdf";


            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=AlumnosActuales2020" + ".pdf");
            //HttpContext.Current.Response.Write(document);
            //Response.Flush();
            //Response.End();






            try
            {

                carrito = (listaTotalVenta)Session["TotalVenta"];
                VentaNegocio negocio = new VentaNegocio();
                foreach (Venta item in carrito.listado)
                {
                    negocio.agregarConSP(item);

                }


                Int64 idCliente = Int64.Parse(ddlClientes.SelectedItem.Value.ToString());
                string emailClienteVenta = "";
                foreach (Venta item in carrito.listado)
                {
                    if (item.Cliente.Id == idCliente)
                    {
                        emailClienteVenta = item.Cliente.Email.ToString();
                        break;
                    }
                }
                DateTime fechaVenta = DateTime.Now;


                if (emailClienteVenta != "")
                {
                    EmailServices emailServices = new EmailServices();
                    string msjAsunto = "realizaste una compra en Implante Dental- [ " + fechaVenta.ToString() + " ]";
                    string msjCuerpo = "";
                    foreach (Venta item in carrito.listado)
                    {
                        msjCuerpo += item.Producto.Nombre.ToString() + ".... $ " + item.Precio.ToString() + "<br>";
                    }
                    msjCuerpo += "<br>........................................<br> Total: $" + carrito.total.ToString();
                    emailServices.armarCorreoCompra(emailClienteVenta, msjAsunto, msjCuerpo);
                    emailServices.enviarEmail();
                }


                // FileStream fs = new FileStream(@"C:\Users\Probando.pdf", FileMode.Create);
                // Document doc = new Document(PageSize.A4);
                // PdfWriter pw = PdfWriter.GetInstance(doc, fs);

                // doc.Open();

                // iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // doc.Add(new Paragraph("Factura"));
                // doc.Add(Chunk.NEWLINE);



                //// doc.Add();

                // doc.Close();
                // pw.Close();



                Response.Redirect("registroProductos.aspx", false);
                carrito.listado.RemoveAll(i => i.Id != 0);
                carrito.total = 0;

            }
            catch (Exception)
            {

                Session.Add("Error", "Hubo un error al Realizar la venta");
                Response.Redirect("Error.aspx", false);
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                carrito = (listaTotalVenta)Session["TotalVenta"];
                Int64 idEliminarProducto = Int64.Parse(ddlProductos.SelectedItem.Value.ToString());
                List<Venta> listVenta = (List<Venta>)Session["listaVentaEnCarro"];
                Venta elim = listVenta.Find(x => x.Id == idEliminarProducto);
                listVenta.Remove(elim);

                carrito.total -= elim.Precio * elim.Cantidad;
                if (carrito.total < 0) carrito.total = 0;
                lblPrecioTotal.Text = "Total: " + carrito.total.ToString("00.00");
                Session.Add("listaVentaEnCarro", listVenta);
                Session.Add("TotalVenta", carrito);
                tabla_productosVenta.DataSource = null;
                tabla_productosVenta.DataSource = listVenta;
                tabla_productosVenta.DataBind();

                if (carrito.listado.Count() == 0) ddlClientes.Enabled = true;
            }
            catch (Exception)
            {

                Session.Add("Error", "asdadsa");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}