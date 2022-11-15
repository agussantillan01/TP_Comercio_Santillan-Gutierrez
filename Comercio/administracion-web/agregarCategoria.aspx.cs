using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace administracion_web
{
    public partial class agregarCategoria : System.Web.UI.Page
    {
        public bool noHayRegistro = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtIdCategoria.Enabled = false;
                    ddlProductoCategoria.Items.Add("Categoria");
                }
                string idCategoria = Request.QueryString["IdCategoria"] != null ? Request.QueryString["IdCategoria"].ToString() : "";

                if (idCategoria != "" && !IsPostBack)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Tipo seleccionado = (negocio.listar(idCategoria))[0];

                    txtIdCategoria.Text = idCategoria;
                    txtNombre.Text = seleccionado.NombreTipo;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string Seleccionado = ddlProductoCategoria.SelectedItem.ToString();

            if (Seleccionado == "Categoria" && txtNombre.Text != "")
            {
                Response.Redirect("registroCategorias.aspx", false);
                CategoriaNegocio negocio = new CategoriaNegocio();
                Tipo tipo = new Tipo();
                tipo.NombreTipo = txtNombre.Text;
                if (Request.QueryString["IdCategoria"] != null)
                {
                    tipo.IdTipo = Int64.Parse(txtIdCategoria.Text);
                    negocio.modificarConSP(tipo);
                }
                else
                {

                negocio.agregar(tipo);
                }
            }
            else
            {
                noHayRegistro = true;
                lblAlertError.Text = "Recuerde llenar los campos!";
            }
        }
    }
}