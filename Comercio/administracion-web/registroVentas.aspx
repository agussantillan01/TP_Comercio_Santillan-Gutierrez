<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroVentas.aspx.cs" Inherits="administracion_web.registroVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro de ventas</h2>

    
    
               <asp:GridView ID="dgvVentasTotal" runat="server" Style="width: 100%;" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
   OnClass="table" >
    <Columns>
            <asp:BoundField HeaderText="Cliente" DataField="Cliente"/>
                <asp:BoundField HeaderText="Email" DataField="Email"/>
            <asp:BoundField HeaderText="Producto" DataField="Producto"/>
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
        </Columns>
    </asp:GridView>
</asp:Content>
