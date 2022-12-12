﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace administracion_web
{
    public partial class registroClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte!");
                Response.Redirect("ErrorLogin.aspx", false);
            }else
            {
                ClienteNegocio negocio = new ClienteNegocio();
                dgvClientes.DataSource = negocio.listarSP();
                dgvClientes.DataBind();
            }

        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCliente = dgvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarCliente.aspx?IdCliente="+ idCliente, false);
        }
    }
}