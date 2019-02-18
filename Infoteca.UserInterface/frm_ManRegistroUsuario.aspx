<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManRegistroUsuario.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManRegistroUsuario"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<div class="form-row">
    <div class="form-group col-md-12">
      <h2>Registro de Usuario</h2>    
    </div>    
</div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputState">Rol de Usuario</label>
            <select id="Rol" class="form-control" runat="server">
                <option selected>Elegir...</option>
                <option>Administrador</option>
                <option>Oficina Prensa</option>
                <option>Agente Policial</option>
            </select>
        </div> 
        <div class="form-group col-md-6">
            <label for="Usuario">Usuario</label>
            <input type="text" class="form-control" id="Usuario" runat="server"/>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Nombre">Nombre</label>
            <input type="text" class="form-control" id="Nombre" runat="server"/>
        </div>
        <div class="form-group col-md-6">
            <label for="Apellidos">Apellidos</label>
            <input type="text" class="form-control" id="Apellido" runat="server"/>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="Password">Password</label>
            <asp:TextBox runat="server" ID="Password" class="form-control" TextMode="Password" />     
        </div>
        <div class="form-group col-md-6">
            <label for="Apellidos">Confirmar Password</label>
            <asp:TextBox runat="server" ID="ConfirmPassword" class="form-control" TextMode="Password" />  
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-12">
          <asp:Button ID="btn_registrar" type="submit" class="btn btn-success" runat="server" OnClick="RegistrarUsuario" Text="Registrar" EnableViewState="True"/> 
        </div>
        <div class="form-group col-md-6" runat="server">
          <control:mensaje runat="server" id="controlMensajes" />
        </div>
    </div>
</asp:Content>
