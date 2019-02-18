<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManInsertarFuente.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManInsertarFuente"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<div class="form-row">
    <div class="form-group col-md-12">
      <h2>Registro de Fuente</h2>    
    </div>    
</div>
<div class="form-row">
    <div class="form-row">
        <div class="form-group col-md-12">
            <label>Crear nueva Fuente</label>
        </div>        
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="TipoFuentes">Tipo Fuente</label>
            <asp:DropDownList runat="server" ID="TipoFuentes" class="form-control"> 
                <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
            </asp:DropDownList>
        </div>        
    </div>
    <div class="form-group col-md-6">
        <label for="NombreFuente">Nombre</label>
        <input type="text" class="form-control" id="NombreFuente" runat="server"/>
    </div>
    <div class="form-group col-md-6">
        <label for="Titulo">Titulo</label>
        <input type="text" class="form-control" id="Titulo" runat="server"/>
    </div>
    <div class="form-group col-md-6">
        <label for="Subtitulo">Subtitulo</label>
        <input type="text" class="form-control" id="Subtitulo" runat="server"/>
    </div>
    <div class="form-group col-md-12">
        <asp:Button type="submit" class="btn btn-primary" runat="server" ID="registrar" OnClick="RegistrarFuente" Text="Registrar"></asp:Button> 
        <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManInicioCatalogos.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
    </div>
    <div class="form-group col-md-6" runat="server">
      <control:mensaje runat="server" id="controlMensajes" />
    </div>
</div>

</asp:Content>
