<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registroUsuarios.aspx.cs" Inherits="administracion_web.registroUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
    <asp:GridView ID="dgvUsuario" Style="width: 50%;" runat="server" DataKeyNames="Id" AutogenerateColumns="false"
        Onclass="table" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged">
        <Columns>
                 <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="TipoUsuario" DataField="TipoUsuario" />
          <%--  <asp:CheckBox AutoPosback="true" Text="Confirmar eliminacion" ID="CheckBox1" runat="server" />
                    --%>

                <asp:CommandField HeaderText="Admin" ShowSelectButton="true" SelectText="Hacer Admin" />

        </Columns>
    </asp:GridView>

    <br />
         


</asp:Content>
