<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="agregarMarcaCategoria.aspx.cs" Inherits="administracion_web.AgregarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        
        <h1>Agrega una marca/Categoria!</h1>

        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Agregar" for="exampleInputEmail1" class="form-label" runat="server" />
                <asp:DropDownList CssClass="form-select" ID="ddlProductoMarca" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Id" for="exampleInputEmail1" class="form-label" runat="server" />
                <br />
                <asp:TextBox ID="txtIdMarca" class="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label Text="Marca o Categoria" for="exampleInputEmail1" class="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" />
            </div>
            <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" runat="server" />
            <div>
              <%if (noHayRegistro) {%>
                <asp:Label Text="" ID="lblAlertError" Style="color: red;" runat="server" />
                <%}%>
                
               
            </div>
        </div>

        <div class="col-4"></div>
           <asp:ScriptManager ID="ScriptManager2" runat="server"> </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

               <ContentTemplate>      


            <asp:Button AutoPosback=true Text="Modificar" id="BtnModificarMarca" OnClick="BtnModificarMarca_Click"  CssClass="btn btn-primary" runat="server" />
           <%  if(Modificacion) { %>
            <div>
              <asp:Label Text="Marca" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
               <div>
           <asp:TextBox ID="TxtNuevaMarca" class="form-control" runat="server" />
            </div>
            <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" />
            <div>
            </div>
             <% }  %>
           </ContentTemplate> 
            </asp:UpdatePanel>
     
          
        <div class="col-4"></div>




    </div>


</asp:Content>
