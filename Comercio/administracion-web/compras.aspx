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
                <asp:DropDownList ID="ddlProducto" CssClass="form-select" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Cantidad(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="1" ID="txtCantidad" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="0" ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3" style="text-align: right;">
                <asp:Button Text="+" ID="btnSumarProducto" OnClick="btnSumarProducto_Click" CssClass="btn btn-success" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-6">
            <h3>Lista de productos</h3>
            <table>
                <asp:Repeater runat="server" ID="repetidor">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("Producto.Nombre")%></td>
                            <td><%#Eval("Cantidad") %></td>
                            <td><%#Eval("Precio") %></td>
                            <td>
                                <asp:Label Text="" ID="lblSubtotal" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <asp:Label Text="" ID="lblPrecioTotal" runat="server" />
            <hr />
        </div>
        <div>
            <asp:Button Style="float: right;" Text="Aceptar" CssClass="btn btn-success" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />

        </div>
        <br />
    </div>
</asp:Content>
