<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManInsertarPropiedad.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManInsertarPropiedad"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<div class="form-row">
    <div class="form-group col-md-12">
      <h2>Registro de Propiedad</h2>    
    </div>    
</div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="TipoPropiedad">Tipo Propiedad</label>
            <select id="TipoPropiedad" class="form-control" runat="server">
                <option selected>Otro</option>
                <option>Casa de habitación</option>
                <option>Apartamento</option>
                <option>Finca</option>
                <option>Lote</option>
                <option>Espacio comercial</option>
            </select>
        </div> 
        <div class="form-group col-md-6">
            <label for="Ubicacion">Ubicación</label>
            <input type="text" class="form-control" ID="Ubicacion" runat="server"/>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-12">
          <asp:Button ID="btn_registrar" type="submit" class="btn btn-success" runat="server" OnClick="RegistrarPropiedad" Text="Registrar" EnableViewState="True"/> 
            <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManInicioCatalogos.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
        </div>
        <div class="form-group col-md-6" runat="server">
          <control:mensaje runat="server" id="controlMensajes" />
        </div>
    </div>
</asp:Content>
