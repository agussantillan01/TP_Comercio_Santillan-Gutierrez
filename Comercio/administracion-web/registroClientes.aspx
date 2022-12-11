<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroClientes.aspx.cs" Inherits="administracion_web.registroClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:GridView ID="dgvClientes" Style="width: 60%; text-align: center;" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" cssClass="table table-ligth table-striped"
            OnClass="table" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Nacimiento" DataField="FechaNacimiento" />
                <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✏️" />
            </Columns>
        </asp:GridView>
         
    <a type="submit" class="btn btn-primary" href="agregarCliente.aspx">--Agregar Cliente--</a>
</asp:Content>
