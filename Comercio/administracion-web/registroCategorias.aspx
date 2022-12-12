<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroCategorias.aspx.cs" Inherits="administracion_web.registroCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:GridView ID="dgvCategorias" Style="width: 50%;" runat="server" DataKeyNames="IdTipo" AutoGenerateColumns="false" CssClass="table table-success table-striped"
        OnClass="table" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Categoria" DataField="NombreTipo" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
        </Columns>
    </asp:GridView>
    <br />
    <%if ((dominio.Usuario)Session["Usuario"] == null)
        {
            Session.Add("Error", "Recuerde loguearte!");
            Response.Redirect("ErrorLogin.aspx", false);
        }
        else
        {
            if (((dominio.Usuario)Session["Usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
            {%>
    <a type="submit" class="btn btn-primary" href="agregarCategoria.aspx">--Agregar Categoria--</a>
    <% }
        }%>


    <%--<% if (((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN) {%>
    <a type="submit" class="btn btn-primary" href="agregarCategoria.aspx">--Agregar Categoria--</a>
         <% } %>--%>
</asp:Content>
