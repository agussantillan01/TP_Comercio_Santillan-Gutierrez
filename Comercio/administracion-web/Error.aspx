﻿<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="administracion_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
        <h1>Hubo un probelma</h1>
        <asp:Label Text="" ID="lblError" runat="server" />
    </div>
    <div style="text-align:center;">
        <img src="../img/error.png" alt="Alternate Text" />
    </div>

</asp:Content>
