<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroUsuarios.aspx.cs" Inherits="administracion_web.registroUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <%if ((dominio.Usuario)Session["Usuario"] == null)
        {
            Session.Add("Error", "Recuerde loguearte!");
            Response.Redirect("ErrorLogin.aspx", false);
        }
        else if (cantidadUsuario.Count() != 0)
        {%>
    <asp:GridView ID="dgvUsuario" Style="width: 50%;" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
        Onclass="table" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="TipoUsuario" DataField="TipoUsuario" />
            <asp:CommandField HeaderText="Admin" ShowSelectButton="true" SelectText="Hacer Admin" />

        </Columns>
    </asp:GridView>

    <br />
    <% }
        else
        {%>
    <div class="row">
        <div>
            <h2 style="text-align: center; color: grey; font-family: Arial;">No hay usuarios registrados...</h2>

        </div>
        <div>
            <img src="../img/ningunUsuarioRegistrado.png" style="width: 30px; text-align: center;" alt="no se encontraron usuarios registrados" />
        </div>
    </div>
    <%}%>
</asp:Content>
