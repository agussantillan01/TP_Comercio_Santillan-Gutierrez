﻿using dominio;
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
        Int64 idProveedor;


        public List<Compra> ListaEnCarrito;
        public carritoCompra carrito = new carritoCompra();


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
            ddlProducto.DataSource = ((List<Producto>)Session["listaProducto"]).FindAll((x => x.Marca.Id == idMarca && x.Tipo.IdTipo == idTipo ));
            ddlProducto.DataBind();
            ddlProducto.Enabled = true;
        }


        protected void btnSumarProducto_Click(object sender, EventArgs e)
        {
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
            ListaEnCarrito = (List<Compra>)Session["listaEnCarro"];
            carrito = (carritoCompra)Session["total"];
            if (ListaEnCarrito == null)
                ListaEnCarrito = new List<Compra>();

            if (carrito == null)
                carrito = new carritoCompra();
            //if (!IsPostBack)
           // {
                if (idProductoSeleccionado != 0)
                {
                    Compra aux = new Compra();
                    aux.Cantidad = Int16.Parse(txtCantidad.Text);
                    aux.Precio = decimal.Parse(txtPrecio.Text);
                    foreach (Producto item in listaProducto)
                    {
                        if (item.Id == idProductoSeleccionado)
                            aux.Producto = item;

                    }
                    List<Proveedor> listaProveedores = listadoProveedores();
                    foreach (Proveedor item in listaProveedores)
                    {
                        if (item.Id == idProveedor)
                            aux.Proveedor = item;
                    }
                    carrito.total += (decimal)aux.Precio * aux.Cantidad;
                    //lblPrecioTotal.Text = "$ Total: " + carrito.total.ToString();
                    ListaEnCarrito.Add(aux);

                    carrito.listado = ListaEnCarrito;

                }
                repetidor.DataSource = ListaEnCarrito;
                repetidor.DataBind();
            //}
            lblPrecioTotal.Text = "$ Total: "+ carrito.total.ToString();
            Session.Add("listaEnCarro", ListaEnCarrito);
            Session.Add("total", carrito);

        }

        private List<Producto> listadoProductos()
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            List<Producto> lista = negocioProducto.listar();
            return lista;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }


    }
}