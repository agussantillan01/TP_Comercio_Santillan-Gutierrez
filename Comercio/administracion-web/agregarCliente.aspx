<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="agregarCliente.aspx.cs" Inherits="administracion_web.agregarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Id" for="txtIdCliente" class="form-label" runat="server" />
                <br />
                <asp:TextBox ID="txtIdCliente" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre(*)" for="txtNombre" class="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Apellido(*)" for="txtApellido" class="form-label" runat="server" />
                <asp:TextBox ID="txtApellido" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Email" for="txtEmail" class="form-label" runat="server" />
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Fecha de Nacimiento(*)" for="txtFechaNacimiento" class="form-label" runat="server" />
                <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" class="form-control" runat="server" />
            </div>
            <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click1" class="btn btn-success" runat="server" />
        </div>
        <div class="col-4"></div>
        <div class="col-4"></div>
    </div>
</asp:Content>
