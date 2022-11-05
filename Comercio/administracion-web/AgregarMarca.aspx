<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Inherits="administracion_web.AgregarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1>Agrega una marca!</h1>

        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Id" for="exampleInputEmail1" class="form-label" runat="server" />
                <br />
                <asp:TextBox ID="txtIdMarca" class="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label Text="Marca" for="exampleInputEmail1" class="form-label" runat="server" />
                <asp:TextBox ID="txtNombreMarca" class="form-control" runat="server" />
            </div>
            <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" runat="server" />
            <div>
                <%if (noHayRegistro) {%>
                <asp:Label Text="" ID="lblAlertError" style="color:red;" runat="server" />
                <%} %>
            </div>
        </div>

        <div class="col-4"></div>
        <div class="col-4"></div>




    </div>


</asp:Content>
