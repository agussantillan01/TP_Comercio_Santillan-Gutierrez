<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroUsuarios.aspx.cs" Inherits="administracion_web.registroUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <%if (cantidadUsuario.Count() != 0)
        { %>
    <asp:GridView ID="dgvUsuario" Style="width: 50%;" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" cssClass="table table-ligth table-striped"
        Onclass="table" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="TipoUsuario" DataField="TipoUsuario" />
            <asp:CommandField HeaderText="Admin" ShowSelectButton="true" SelectText="Hacer Admin" />

        </Columns>
    </asp:GridView>

    <br />
    <%}
        else
        {%>
    <div>
        <h2 style="text-align: center; color: grey; font-family:Arial;">No hay usuarios registrados...</h2>

        <img src="../img/ningunUsuarioRegistrado.png" style="width: 30px; text-align: center;" alt="no se encontraron usuarios registrados" />
    </div>


    <%} %>
</asp:Content>
