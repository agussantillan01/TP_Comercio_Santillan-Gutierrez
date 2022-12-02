<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="compras.aspx.cs" Inherits="administracion_web.compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <br />
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
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" OnDataBound="ddlCategoria_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label Text="Marca(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlMarca" AutoPostBack="true" OnDataBound="ddlMarca_DataBound" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" CssClass="form-select" runat="server"></asp:DropDownList>
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
            <br />
            <table>

                <tr>
                    <td style="padding-right: 150px;"><b>Producto</b> </td>
                    <td style="padding-right: 140px;"><b>Cantidad</b> </td>
                    <td style="padding-right: 100px;"><b>Precio</b> </td>
                </tr>
            </table>
            <table>
                <asp:Repeater runat="server" ID="tabla_productos">
                    <ItemTemplate>

                        <tr>
                            <td style="padding-right: 200px;"><%#Eval("Producto.Nombre")%> </td>
                            <td style="padding-right: 200px;"><%#Eval("Cantidad") %></td>
                            <td style="padding-right: 80px;"><%#Eval("Precio") %></td>
                            <td>
                                <asp:Button Text="-" ID="btnEliminarProductoLista" OnClick="btnEliminarProductoLista_Click" CssClass="btn btn-danger" AutoPostBack="true" CommandArgument='<%#Eval ("Id")%>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text="" ID="lblSubtotal" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <br />
            <asp:Label Text="" ID="lblPrecioTotal" runat="server" />
            <asp:Label Text="" ID="txtCantidadIngresado" runat="server" />
            <hr />
        </div>


        <div>
            <asp:Button Style="float: right;" Text="Aceptar" CssClass="btn btn-success" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />

        </div>
        <br />
    </div>
    <asp:Label Text="" ID="cantidadListado" runat="server" />
</asp:Content>
