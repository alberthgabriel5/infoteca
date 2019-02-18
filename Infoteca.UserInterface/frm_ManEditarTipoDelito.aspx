<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManEditarTipoDelito.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManEditarTipoFuente"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">       
     
    <div class="form-row">
    <div class="form-group col-md-12">
      <h2>Editar Tipo de Delito</h2>    
    </div>    
  </div>
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputEmail4">Nombre</label>
        <input type="text" class="form-control" id="inputNombre" runat="server" placeholder="Nombre">
    </div>    
  <div class="form-group col-md-12">
      <asp:Button ID="btn_editar" type="submit" class="btn btn-primary" runat="server" OnClick="EditarTipoDelito" Text="Editar" EnableViewState="True"/>
  </div>
  <div class="form-group col-md-6" runat="server">
      <control:mensaje runat="server" id="controlMensajes" />
  </div>

</asp:Content>
