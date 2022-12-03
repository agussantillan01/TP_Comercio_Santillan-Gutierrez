<%@ Page Title="" Language="C#" MasterPageFile="~/masterLogin.Master" AutoEventWireup="true" CodeBehind="ErrorLogin.aspx.cs" Inherits="administracion_web.ErrorLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
        <h1>Hubo un problema!</h1>
        <asp:Label Text="" ID="lblErrorLogin" Style="color: red;" runat="server" />
    </div>
    <div style="text-align:center;">
        <asp:Image ImageUrl="https://cdn-icons-png.flaticon.com/512/4319/4319124.png" runat="server" />
    </div>

</asp:Content>
