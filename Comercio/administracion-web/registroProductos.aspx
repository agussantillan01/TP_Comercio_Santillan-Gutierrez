<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroProductos.aspx.cs" Inherits="administracion_web.paginaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div style="text-align: center;">
        <a type="submit" class="btn btn-light" href="registroClientes.aspx">Clientes Existentes</a>
        <a type="submit" class="btn btn-light" href="registroProveedores.aspx">Proveedores</a>
    </div>


    <hr />
    <div class="input-group input-group-sm mb-1">
        <div class="input-group-prepend">
            <asp:TextBox runat="server" ID="Buscador" class="form-control" />
        </div>
        <asp:Button CssClass="btn btn-primary" Text="Search" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
        <div style="padding-left:3px;">
            <asp:Button CssClass="btn btn-success" Text="🔙" Id="btnLimpiar" OnClick="btnLimpiar_Click" runat="server" />
            
        </div>
    </div>


    <asp:GridView ID="dgvProductos" runat="server" Style="width: 100%;" DataKeyNames="Id" AutoGenerateColumns="false"
        OnClass="table" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged">
        <columns>
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:BoundField HeaderText="Stock Min." DataField="StockMinimo" />
            <asp:BoundField HeaderText="Precio Compra" DataField="Precio" />
            <asp:BoundField HeaderText="Porcentaje de ganancia" DataField="Porcentaje" />
            <asp:CommandField HeaderText="Modifica/Elimina" ShowSelectButton="true" SelectText="Modificar/Eliminar" />

        </columns>

    </asp:GridView>
    <% if (((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
        {%>
    <div style="text-align: left;">
        <a type="submit" class="btn btn-primary" href="agregarProducto.aspx">--Agregar Producto--</a>
    </div>
    <% } %>
    <div style="text-align: right;">
        <a type="submit" class="btn btn-primary" href="compras.aspx">Comprar</a>
        <a type="submit" class="btn btn-primary" href="ventas.aspx">Vender</a>
    </div>


</asp:Content>
