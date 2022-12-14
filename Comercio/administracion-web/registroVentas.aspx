<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroVentas.aspx.cs" Inherits="administracion_web.registroVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if ((dominio.Usuario)Session["Usuario"] == null)
        {
            Session.Add("Error", "Recuerde loguearte!");
            Response.Redirect("ErrorLogin.aspx", false);
        }
        else
        { %>
    <h2 style="font-family:Arial;">Registro de ventas</h2>

    <asp:GridView ID="dgvVentasTotal" runat="server" Style="width: 100%;" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
        OnClass="table">
        <columns>
            <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
            <asp:BoundField HeaderText="Email" DataField="Cliente.Email" />
            <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
        </columns>
    </asp:GridView>

    <%}%>
</asp:Content>
