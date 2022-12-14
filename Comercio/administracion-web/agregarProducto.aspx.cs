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
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
          txtId.Enabled = false;
          confirmaEliminacion = false;
           try
           {
                if (!IsPostBack)
                { 
                   //Completo el desplegable de Categoria
                   CategoriaNegocio negocioTipo = new CategoriaNegocio();
                   List<Tipo> listaTipo = negocioTipo.listarSP();
                   ddlTipo.DataSource = listaTipo;
                   ddlTipo.DataValueField = "IdTipo";
                   ddlTipo.DataTextField = "NombreTipo";
                   ddlTipo.DataBind();

                   //Completo el desplegable de marcas
                   MarcaNegocio negocioMarca = new MarcaNegocio();
                   List<Marca> listaMarca = negocioMarca.listarSP();
                   ddlMarca.DataSource = listaMarca;
                   ddlMarca.DataValueField = "Id";
                   ddlMarca.DataTextField = "NombreMarca";
                   ddlMarca.DataBind();
                }


                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto seleccionado = (negocio.listar(id))[0];
                    
                    

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtStock.Text = seleccionado.stock.ToString();
                    txtStockMinimo.Text = seleccionado.stockMinimo.ToString();
                    txtPorcentaje.Text = seleccionado.Porcentaje.ToString();

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlTipo.SelectedValue = seleccionado.Tipo.IdTipo.ToString();


                }

           }

           catch (Exception )
           {

                Session.Add("Error", "Campos incorrectos");
                Response.Redirect("Error.aspx", false);
            }

            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Producto nuevo = new Producto();
                ProductoNegocio negocio = new ProductoNegocio();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.stock = int.Parse(txtStock.Text);
                nuevo.stockMinimo = int.Parse(txtStockMinimo.Text);
                nuevo.Precio = 0;
                nuevo.Porcentaje = int.Parse(txtPorcentaje.Text);

                nuevo.Tipo = new Tipo();
                nuevo.Tipo.IdTipo = Int64.Parse(ddlTipo.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = Int64.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = Int64.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                    Response.Redirect("registroProductoss.aspx");

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
            }
            catch (Exception)
            {

                Session.Add("Error", "Campos incorrectos");
                Response.Redirect("Error.aspx", false);
            }
            
               
            

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmarEliminacion.Checked)
                { 
                ProductoNegocio negocio = new ProductoNegocio();
                    List<Producto> lista = negocio.listar();
                    
                    foreach (var item in lista)
                    {
                        if (item.Id == Int64.Parse(txtId.Text))
                        {
                            if (item.stock == 0)
                            {
                                negocio.eliminarConSP(Int64.Parse(txtId.Text));
                                Response.Redirect("registroProductos.aspx");

                                break;
                            }else
                            {
                                Session.Add("Error", "No se ha podido eliminar el procuto ya que aún cuenta con stock");
                                Response.Redirect("Error.aspx", false);
                                
                                break;
                            }
                            
                        }

                    }
                
                }
            }
            catch (Exception)
            {

                //Session.Add("Error", "No se ha podido actualizar los prodcuto");
                //Response.Redirect("Error.aspx", false);
            }
        }

        public bool seEncontroProducto (string nombreProducto)
        {
            ProductoNegocio negocioproducto = new ProductoNegocio();
            List<Producto> listaProdcuto = negocioproducto.listar();
            foreach (Producto p in listaProdcuto)
            {
                if (p.Nombre.ToUpper() == nombreProducto)
                {
                    return true;
                }
            }
            return false;
        }
    }
}