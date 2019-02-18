<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostrarMensajes.ascx.cs" Inherits="Infoteca.UserInterface.controles.MostrarMensajes" %>

<div class="alert alert-success alert-dismissible fade in" runat="server" ID="mensajeExito" Visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Exito!</strong> <asp:Literal runat="server" ID="labelExito"></asp:Literal>
</div>
<div class="alert alert-danger alert-dismissible fade in" runat="server"  ID="mensajeError" Visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Error!</strong> <asp:Literal runat="server" ID="labelError"></asp:Literal>
</div>