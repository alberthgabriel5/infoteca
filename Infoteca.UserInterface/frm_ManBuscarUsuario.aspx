<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManBuscarUsuario.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManBuscarUsuario"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">       
     
    <div class="form-row">
    <div class="form-group col-md-12">
      <h2>Usuarios del Sistema</h2>    
    </div>    
  </div>
    <div class="form-group col-md-6" runat="server">
        <control:mensaje runat="server" id="controlMensajes" />
    </div>
   <div class="form-row">
        <br />
        <div class="table-wrapper-scroll-y">
            <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns = "False" 
                onrowdatabound = "gvPerson_RowDataBound"  
                onpageindexchanging = "gvPerson_PageIndexChanging"  
                onsorting = "gvPerson_Sorting"
                onrowdeleting = "gvPerson_RowDeleting"   
                CssClass = "table table-hover table-striped"
                BorderWidth="0"> 
                <Columns> 
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" ItemStyle-HorizontalAlign="Center"/> 
                    <asp:TemplateField HeaderText="Usuario" SortExpression="Username"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Username") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rol" SortExpression="Rol "> 
                        <ItemTemplate> 
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Rol") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Borrar" ShowDeleteButton="True" DeleteText="Borrar <i aria-hidden='true' class='glyphicon glyphicon-trash'></i>" ButtonType="Link" />
                </Columns> 
                <FooterStyle ForeColor="Black" BorderWidth="0"/> 
                <PagerStyle ForeColor="Black" HorizontalAlign="Center" Font-Size="X-Large" BorderWidth="0"/> 
                <SelectedRowStyle Font-Bold="True" ForeColor="Black" BorderWidth="0"/> 
                <HeaderStyle Font-Bold="True" ForeColor="Black" BorderWidth="0"/>
                <RowStyle BorderWidth="0"/>
            </asp:GridView> 
        </div>
   </div>
    
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Borrar Usuario</h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal runat="server" ID="borrarMensaje"></asp:Literal></p>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" class="btn btn-primary" EnableViewState="True" Text="Si" OnClick="BorrarUsuario"/>
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>
      
        </div>
    </div>
 
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
        function closeModal() {
            $('#myModal').modal('hide');
        }
    </script>
</asp:Content>
