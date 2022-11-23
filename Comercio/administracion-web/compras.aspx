<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="compras.aspx.cs" Inherits="administracion_web.compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1 style="text-align: center;">Realice una compra! </h1>
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Numero de Compra(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="#" ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Proveedor(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlProveedor" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Categoria(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Marca(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlMarca" AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Producto(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlProducto"  CssClass="form-select" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Cantidad(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="$" ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3" style="text-align: right;">
                <asp:Button Text="+" ID="btnSumarProducto" OnClick="btnSumarProducto_Click" CssClass="btn btn-success" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-4"></div>
    </div>

    <asp:Button Style="float: right;" Text="Aceptar" CssClass="btn btn-success" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
    <br />
</asp:Content>
