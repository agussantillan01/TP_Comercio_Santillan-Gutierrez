<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="agregarCategoria.aspx.cs" Inherits="administracion_web.agregarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <%if (Request.QueryString["IdCategoria"] != null)
            {%>
        <h1>Modificacion</h1>
        <%}
            else
            {%>
        <h1>Agregue una Categoria!</h1>
        <% }%>
        

        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Agregar" for="exampleInputEmail1" class="form-label" runat="server" />
                <asp:DropDownList CssClass="form-select" ID="ddlProductoCategoria" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Id" for="exampleInputEmail1" class="form-label" runat="server" />
                <br />
                <asp:TextBox ID="txtIdCategoria" class="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label Text="Marca o Categoria" for="exampleInputEmail1" class="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" />
            </div>
            <asp:Button Text="Aceptar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" runat="server" />
            <div>
                <%if (noHayRegistro)
                    {%>
                <asp:Label Text="" ID="lblAlertError" Style="color: red;" runat="server" />
                <%}%>
            </div>
        </div>

        <div class="col-4"></div>
        <div class="col-4"></div>




    </div>


</asp:Content>
