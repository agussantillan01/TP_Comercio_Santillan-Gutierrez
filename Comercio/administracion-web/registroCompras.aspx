<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroCompras.aspx.cs" Inherits="administracion_web.registroCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Desde Registro de compras</h1>

    <asp:GridView runat="server" Style="width: 100%;" ID="dgvComprasTotales" DataKeyNames="Id" OnClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvComprasTotales_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor"/>
            <asp:BoundField HeaderText="Producto" DataField="Producto"/>
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
        </Columns>
    </asp:GridView>
</asp:Content>
