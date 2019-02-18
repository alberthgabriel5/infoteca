<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManInsertarTipoFuente.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManInsertarTipoFuente"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<div class="form-row">
    <div class="form-group col-md-12">
      <h2>Registro de Tipos de Fuente</h2>    
    </div>    
</div>
<div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputEmail4">Nombre</label>
      <input type="text" class="form-control" id="inputNombre" runat="server" placeholder="Nombre"/>
    </div>    
    <div class="form-group col-md-12">
      <asp:Button ID="btn_registrar" type="submit" class="btn btn-success" runat="server" OnClick="RegistrarTipoFuente" Text="Registrar" EnableViewState="True"/> 
        <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManInicioCatalogos.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
    </div>
    <div class="form-group col-md-6" runat="server">
      <control:mensaje runat="server" id="controlMensajes" />
    </div>
</div>

</asp:Content>
