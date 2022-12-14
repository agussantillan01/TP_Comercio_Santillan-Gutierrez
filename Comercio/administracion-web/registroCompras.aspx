<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroCompras.aspx.cs" Inherits="administracion_web.registroCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if ((dominio.Usuario)Session["Usuario"] == null)
        {
            Session.Add("Error", "Recuerde loguearte!");
            Response.Redirect("ErrorLogin.aspx", false);
        }  else
            { %>
        <h2 style="font-family:Arial;">Registro de compras</h2>


    <asp:GridView ID="dgvComprasTotal" runat="server" Style="width: 100%;" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
        OnClass="table">
        <Columns>
            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre" />
            <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
        </Columns>
    </asp:GridView>
           <% }%>


</asp:Content>
