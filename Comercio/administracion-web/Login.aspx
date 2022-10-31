<%@ Page Title="" Language="C#" MasterPageFile="~/masterLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="administracion_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1 style="text-align: center; color: grey;">Login</h1>
    <br />
    <br />
    <div class="text-center">
        <img style="width: 250px;" src="https://objetivoligar.com/wp-content/uploads/2017/03/blank-profile-picture-973460_1280.jpg" class="rounded" alt="...">
    </div>




    <div class="row">
        <div class="col-3"></div>
        <div class="col">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email</label>
                <asp:TextBox type="email" ID="txtEmail" class="form-control" aria-describedby="emailHelp" runat="server" />
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Password</label>
                <asp:TextBox type="password" id="txtPassword" class="form-control"  runat="server" />
                
            </div>
            <div class="mb-3 form-check">
                <input type="checkbox" class="form-check-input" id="exampleCheck1">
                <label class="form-check-label" for="exampleCheck1">Aceptar Términos y condiciones</label>
            </div>
            <a class="btn btn-primary" href="registroProductos.aspx" role="button">content</a>
            <%--<asp:Button Text="Ingresar" id="btnIngresar" onclick="btnIngresar_Click" CssClass="btn btn-primary" runat="server" />--%>
        </div>
                
        <div class="col-3"></div>
    </div>


</asp:Content>
