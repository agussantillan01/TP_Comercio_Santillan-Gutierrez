<%@ Page Title="" Language="C#" MasterPageFile="~/masterLogin.Master" AutoEventWireup="true" CodeBehind="creaCuenta.aspx.cs" Inherits="administracion_web.creaCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <h1>Agrega un Producto!</h1>
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Id(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Apellido(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Email(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Contraseña(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtConstraseña" TextMode="Password" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Fecha Nacimiento(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtFecha" runat="server" />
            </div>
        </div>

        <%--<asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" runat="server" />--%>


        <div class="col-4"></div>
    </div>

</asp:Content>
