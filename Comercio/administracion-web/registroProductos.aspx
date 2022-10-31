<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroProductos.aspx.cs" Inherits="administracion_web.paginaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />


    <asp:gridview Id="dgvProductos" runat="server" AutoGenerateColumns="false">
        <columns>
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:BoundField HeaderText="Stock Min." DataField="StockMinimo" />
            <asp:BoundField HeaderText="$" DataField="Precio" />

        </columns>
    </asp:gridview>
     
<%--        <asp:GridView runat="server">
        <Columns>
            <asp:BoundField HeaderText="Productos" DataField="" />
            <asp:BoundField HeaderText="Precio" DataField="" />
            <asp:BoundField HeaderText="Stock" DataField="" />
            <asp:BoundField HeaderText="Ganancia" DataField="" />
            <asp:BoundField HeaderText="Proveedor" DataField="" />
        </Columns>
    </asp:GridView>--%>
    <div style="text-align:center;">
        <a type="submit" class="btn btn-primary" href="#">Comprar</a>
        <a type="submit" class="btn btn-primary" href="#">Vender</a>
        <a type="submit" class="btn btn-primary" href="#">Modificar</a>

    </div>
</asp:Content>
