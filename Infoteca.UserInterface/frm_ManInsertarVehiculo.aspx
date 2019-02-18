<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManInsertarVehiculo.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManInsertarVehiculo"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<div class="form-row">
    <div class="form-group col-md-12">
      <h2>Registro de Vehiculo</h2>    
    </div>    
</div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Placa">Placa</label>
            <input type="text" class="form-control" id="Placa" runat="server"/>
        </div>
        <div class="form-group col-md-6">
            <label for="Marca">Marca</label>
            <input type="text" class="form-control" id="Marca" runat="server"/>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Modelo">Modelo</label>
            <input type="text" class="form-control" id="Modelo" runat="server"/>
        </div>
        <div class="form-group col-md-6">
            <label for="inputColorZip">Color</label>
            <input type="text" class="form-control" id="Color" runat="server"/>
        </div>
    </div>
    <div class="form-row">

        <div class="form-group col-md-6">
            <label for="Tipo">Tipo</label>
            <input type="text" class="form-control" id="Tipo" runat="server" />
        </div>  
    </div>
    <div class="form-row">
        <div class="form-group col-md-12">
          <asp:Button ID="btn_registrar" type="submit" class="btn btn-success" runat="server" OnClick="RegistrarVehiculo" Text="Registrar" EnableViewState="True"/> 
            <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManInicioCatalogos.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
        </div>
        <div class="form-group col-md-6" runat="server">
          <control:mensaje runat="server" id="controlMensajes" />
        </div>
    </div>
</asp:Content>
