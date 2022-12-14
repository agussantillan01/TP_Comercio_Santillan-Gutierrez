<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroProveedores.aspx.cs" Inherits="administracion_web.registroProveedores" %>

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
    <asp:GridView ID="dgvProveedores" Style="width: 60%; text-align: center;" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
        OnClass="table" OnSelectedIndexChanged="dgvProveedores_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Domicilio" DataField="Domicilio" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Cuil" DataField="Cuil" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
        </Columns>
    </asp:GridView>
    <%if (((dominio.Usuario)Session["Usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
        { %>
    <a type="submit" class="btn btn-primary" href="agregarProveedores.aspx">--Agregar Proveedor--</a>


    <%} %>



    <%} %>
</asp:Content>
