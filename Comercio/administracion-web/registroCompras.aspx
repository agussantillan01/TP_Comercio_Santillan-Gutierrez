<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroCompras.aspx.cs" Inherits="administracion_web.registroCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Desde Registro de compras</h1>
    
    <asp:GridView runat="server">
        <Columns>
            <asp:BoundField HeaderText="Productos" DataField="" />
            <asp:BoundField HeaderText="Precio" DataField="" />
            <asp:BoundField HeaderText="Stock" DataField="" />
            <asp:BoundField HeaderText="Ganancia" DataField="" />
            <asp:BoundField HeaderText="Proveedor" DataField="" />
        </Columns>
    </asp:GridView>
</asp:Content>
