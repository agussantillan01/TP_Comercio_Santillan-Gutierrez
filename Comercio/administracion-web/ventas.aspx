<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="administracion_web.ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col">
            <br />
            <br />
            <div class="mb-3">
                <asp:Label Text="Cliente(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlClientes" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged" OnDataBound="ddlClientes_DataBound" CssClass="form-select" runat="server"></asp:DropDownList>
                <a style="text-decoration: none;" href="agregarCliente.aspx">En caso de no estar registrado, haga click aquí</a>
            </div>
            <div class="mb-3">
                <asp:Label Text="Producto(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlProductos" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged" OnDataBound="ddlProductos_DataBound" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Cantidad(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="1" ID="txtCantidad" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="0" ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>
            <asp:Button Text="+" CssClass="btn btn-success" ID="btnSumarProducto" AutoPostBack="false" OnClick="btnSumarProducto_Click" runat="server" />
            <asp:Label Text="" Style="color: red;" ID="lblError" runat="server" />
        </div>
        <div class="col-2"></div>

        <div class="col-6">
            <table>

                <tr>
                    <td style="padding-right: 150px;"><b>Producto</b> </td>
                    <td style="padding-right: 140px;"><b>Cantidad</b> </td>
                    <td style="padding-right: 100px;"><b>Precio</b> </td>
                </tr>
            </table>
            <table>
                <asp:Repeater runat="server" ID="tabla_productosVenta">
                    <ItemTemplate>

                        <tr>
                            <td style="padding-right: 200px;"><%#Eval("Producto.Nombre")%> </td>
                            <td style="padding-right: 200px;"><%#Eval("Cantidad") %></td>
                            <td style="padding-right: 80px;"><%#Eval("Precio") %></td>
                            <td>
                                <asp:Button Text="-" ID="btnEliminar" runat="server" />
                            </td>
                            <td>
                                <asp:Label Text="" ID="lblSubTotal" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <br />
            <asp:Label Text="" ID="lblPrecioTotal" runat="server" />
            <hr />
        </div>
        <div>
            <asp:Button Style="float: right;" Text="Aceptar" CssClass="btn btn-success" ID="btnAceptar" runat="server" />

        </div>
    </div>


</asp:Content>
