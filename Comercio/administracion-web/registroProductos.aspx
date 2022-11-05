<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroProductos.aspx.cs" Inherits="administracion_web.paginaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />


    <asp:GridView ID="dgvProductos" runat="server" Style="width: 100%;" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:BoundField HeaderText="Stock Min." DataField="StockMinimo" />
            <asp:BoundField HeaderText="$" DataField="Precio" />

        </Columns>
    </asp:GridView>




    <%--        <asp:GridView runat="server">
        <Columns>
            <asp:BoundField HeaderText="Productos" DataField="" />
            <asp:BoundField HeaderText="Precio" DataField="" />
            <asp:BoundField HeaderText="Stock" DataField="" />
            <asp:BoundField HeaderText="Ganancia" DataField="" />
            <asp:BoundField HeaderText="Proveedor" DataField="" />
        </Columns>
    </asp:GridView>--%>
    <div style="display:inline;">
        <div style="text-align: left;">
            <a type="submit" class="btn btn-primary" href="agregarMarcaCategoria.aspx">--Agregar Marca/Categorias--</a>
            <a type="submit" class="btn btn-primary" href="agregarProducto.aspx">--Agregar Producto--</a>
        </div>
        <div style="text-align: right;">
            <a type="submit" class="btn btn-primary" href="#">Comprar</a>
            <a type="submit" class="btn btn-primary" href="#">Vender</a>
        </div>
    </div>

</asp:Content>
