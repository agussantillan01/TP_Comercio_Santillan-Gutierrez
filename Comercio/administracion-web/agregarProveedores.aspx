<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="agregarProveedores.aspx.cs" Inherits="administracion_web.agregarProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Id" for="txtIdProveedores" class="form-label" runat="server" />
                <br />
                <asp:TextBox ID="txtIdProveedores" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre(*)" for="txtNombre" class="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Domicilio(*)" for="txtDomicilio" class="form-label" runat="server" />
                <asp:TextBox ID="txtDomicilio" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Email" for="txtEmail" class="form-label" runat="server" />
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="CUIL" for="txtCuil" class="form-label" runat="server" />
                <asp:TextBox ID="txtCuil" class="form-control" runat="server" />
            </div>
     
            <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click2" class="btn btn-success" runat="server" />
        </div>
        <div class="col-4"></div>
        <div class="col-4"></div>
    </div>
</asp:Content>
