<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroMarcas.aspx.cs" Inherits="administracion_web.registroMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvMarcas" Style="width: 100%;" runat="server" DataKeyNames="Id" AutogenerateColumns="false"
        Onclass="table" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Marca" DataField="NombreMarca" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
            
        </Columns>
    </asp:GridView>
    <a type="submit" class="btn btn-primary" href="agregarMarca.aspx">--Agregar Marca--</a>


</asp:Content>
