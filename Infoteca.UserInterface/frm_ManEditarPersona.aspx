<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManEditarPersona.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManEditarPersona"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<div class="form-row">
    <div class="form-group col-md-12">
      <h2>Registro de Persona</h2>    
    </div>    
</div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputState">Tipo Identificación</label>
            <select id="TipoIdentificacion" class="form-control" runat="server">
                <option selected>Elegir...</option>
                <option>Cédula</option>
                <option>Pasaporte</option>
                <option>Desconocido</option>
            </select>
        </div> 
        <div class="form-group col-md-6">
            <label for="Identificación">Identificación</label>
            <input type="text" class="form-control" id="Identificacion" runat="server"/>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Nombre">Nombre</label>
            <input type="text" class="form-control" id="inputNombre" runat="server"/>
        </div>
        <div class="form-group col-md-6">
            <label for="Apellidos">Apellidos</label>
            <input type="text" class="form-control" id="Apellidos" runat="server"/>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Alias">Alias</label>
            <input type="text" class="form-control" id="Alias" runat="server" placeholder="Alias"/>
        </div> 
        <div class="form-group col-md-12">
          <asp:Button ID="btn_registrar" type="submit" class="btn btn-success" runat="server" OnClick="ActualizarPersona" Text="Actualizar" EnableViewState="True"/> 
            <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManBuscarPersona.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
        </div>
        <div class="form-group col-md-6" runat="server">
          <control:mensaje runat="server" id="controlMensajes" />
        </div>
    </div>
</asp:Content>
