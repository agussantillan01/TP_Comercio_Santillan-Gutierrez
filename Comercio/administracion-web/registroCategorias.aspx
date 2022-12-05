<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroCategorias.aspx.cs" Inherits="administracion_web.registroCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:GridView ID="dgvCategorias" Style="width: 100%;"  runat="server" DataKeyNames="IdTipo" AutoGenerateColumns="false"
        OnClass="table" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="Categoria" DataField="NombreTipo" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
        </Columns>
    </asp:GridView>
               <% if (((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN) {%>
    <a type="submit" class="btn btn-primary" href="agregarCategoria.aspx">--Agregar Categoria--</a>
         <% } %>
</asp:Content>
