<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManInsertarPersonaJuridica.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManInsertarPersonaJuridica"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<div class="form-row">
    <div class="form-group col-md-12">
      <h2>Registro de PersonaJuridica</h2>    
    </div>    
</div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Identificacion">Identificación</label>
            <input type="text" class="form-control" id="IdentificacionJU" runat="server"/>
        </div>
        <div class="form-group col-md-6">
            <label for="NombreJU">Nombre</label>
            <input type="text" class="form-control" id="NombreJU" runat="server"/>
        </div>  
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Fantasia">Nombre Fantasia</label>
            <input type="text" class="form-control" id="Fantasia" runat="server"/>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-12">
          <asp:Button ID="btn_registrar" type="submit" class="btn btn-success" runat="server" OnClick="RegistrarPersonaJuridica" Text="Registrar" EnableViewState="True"/> 
            <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManInicioCatalogos.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
        </div>
        <div class="form-group col-md-6" runat="server">
          <control:mensaje runat="server" id="controlMensajes" />
        </div>
    </div>
</asp:Content>
