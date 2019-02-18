<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManBuscarTipoDelito.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManBuscarTipoDelito"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">       
     
    <div class="form-row">
    <div class="form-group col-md-12">
      <h2>Tipos de Delito</h2>    
    </div>    
  </div>
    <div class="form-group col-md-6" runat="server">
        <control:mensaje runat="server" id="controlMensajes" />
    </div>
   <div class="form-row">
        <br />
        <div class="table-wrapper-scroll-y">
            <asp:Table class="table table-bordered table-striped info" runat="server" id="tablaTiposDelito">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>#</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>  
                <asp:TableHeaderCell>Fecha Creación</asp:TableHeaderCell>   
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            </asp:Table>
        </div>
   </div>
    
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Borrar Tipo Delito</h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal runat="server" ID="borrarMensaje"></asp:Literal></p>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" class="btn btn-primary" OnClick="BorrarTipoDelito" EnableViewState="True" Text="Si"/>
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>
      
        </div>
    </div>
    <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManInicioCatalogos.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
        function closeModal() {
            $('#myModal').modal('hide');
        }
    </script>
</asp:Content>
