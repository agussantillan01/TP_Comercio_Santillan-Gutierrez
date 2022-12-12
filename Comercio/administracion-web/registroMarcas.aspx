<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroMarcas.aspx.cs" Inherits="administracion_web.registroMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:GridView ID="dgvMarcas" Style="width: 50%;" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-success table-striped"
        Onclass="table" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Marca" DataField="NombreMarca" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✏️" />

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
    <a type="submit" class="btn btn-primary" href="agregarMarca.aspx">--Agregar Marca--</a>
    <% }
        }%>

    
</asp:Content>
