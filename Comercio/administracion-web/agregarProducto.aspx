<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="agregarProducto.aspx.cs" Inherits="administracion_web.agregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <%if (Request.QueryString["Id"] != null)
            {%>
        <h1>Modifica/Elimina</h1>
        <%}
            else
            {%>
        <h1>Agregue Producto</h1>
        <%}%>
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Id(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Tipo(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripcion" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Marca(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Stock(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtStock" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Stock minimo(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtStockMinimo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Porcentaje de ganancia(*)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtPorcentaje" CssClass="form-control" runat="server" />
            </div>

            <asp:Button Text="Aceptar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <asp:Button AutoPosback="true" Text="Eliminar" ID="BtnEliminar" OnClick="BtnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    <%  if (confirmaEliminacion)
                        { %>
                    <div>
                        <asp:CheckBox AutoPosback="true" Text="Confirmar eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>
                    <% }  %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="col-2"></div>

        <div class="col-4"></div>

        <asp:Label Text="" ID="lblError" Style="color: red;" runat="server" />
    </div>
</asp:Content>

