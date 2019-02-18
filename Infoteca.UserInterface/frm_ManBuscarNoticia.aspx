<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManBuscarNoticia.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManBuscarNoticia"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">       
     
    <div class="form-row">
    <div class="form-group col-md-12">
      <h2>Noticias</h2>    
    </div>    
  </div>
   <div class="form-row">
        <br />
        <div class="table-wrapper-scroll-y">
            <div class="form-row">
                <div class="form-group col-md-12">   
                    <asp:Label runat="server" ID="Coincidencias" class="label-success" Visible="False"></asp:Label>  
                    <asp:Label runat="server" ID="Mensaje" class="alert-danger" Visible="False"></asp:Label> 
                </div>              
            </div>
          <asp:GridView ID="gvNoticia" runat="server" AutoGenerateColumns = "False" 
                    onrowdatabound = "gvNoticia_RowDataBound"  
                    onpageindexchanging = "gvNoticia_PageIndexChanging"  
                    onrowediting = "gvNoticia_RowEditing" 
                    onrowdeleting = "gvNoticia_RowDeleting"
                    onsorting = "gvNoticia_Sorting"
                    CssClass = "table table-hover table-striped"
                    BorderWidth="0"> 
                    <Columns> 
                        <asp:BoundField DataField="LintId" HeaderText="Id" ReadOnly="True" SortExpression="LintId" ItemStyle-HorizontalAlign="Center"/>        
                        <asp:TemplateField HeaderText="Descripción" SortExpression="LstrDescripcion"> 
                            <ItemTemplate> 
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LstrDescripcion") %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Delito" SortExpression="LintIdTipoDelito"> 
                            <ItemTemplate> 
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("LintIdTipoDelito") %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Fuente" SortExpression="LintIdFuente"> 
                            <ItemTemplate> 
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("LintIdFuente") %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha" SortExpression="LdtiFecha"> 
                            <ItemTemplate> 
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("LdtiFecha") %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Personas" SortExpression="LobjPersonas"> 
                            <ItemTemplate> 
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("LobjPersonas") %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField>                                            
                        <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="Editar <i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" ButtonType="Link"/>
                        <asp:CommandField HeaderText="Borrar" ShowDeleteButton="True" DeleteText="Borrar <i aria-hidden='true' class='glyphicon glyphicon-trash'></i>" ButtonType="Link" />
                        <asp:TemplateField ShowHeader="False" Visible="true">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbEnviarCorreo" runat="server" CausesValidation="False" CommandName="EnviarCorreo" Text="Exportar a PDF <i aria-hidden='true' class='glyphicon glyphicon-export'></i>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns> 
                    <FooterStyle ForeColor="Black" BorderWidth="0"/> 
                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" Font-Size="X-Large" BorderWidth="0"/> 
                    <SelectedRowStyle Font-Bold="True" ForeColor="Black" BorderWidth="0"/> 
                    <HeaderStyle Font-Bold="True" ForeColor="Black" BorderWidth="0"/>
                    <RowStyle BorderWidth="0"/>
                </asp:GridView>
        
        </div>
       <div class="form-group col-md-6" runat="server">
            <control:mensaje runat="server" id="controlMensajes" />
        </div>
       <div class="modal fade" id="myModal" role="dialog">
           <div class="modal-dialog">
    
               <!-- Modal content-->
               <div class="modal-content">
                   <div class="modal-header">
                       <button type="button" class="close" data-dismiss="modal">&times;</button>
                       <h4 class="modal-title">Borrar Vehiculo</h4>
                   </div>
                   <div class="modal-body">
                       <p><asp:Literal runat="server" ID="borrarMensaje"></asp:Literal></p>
                   </div>
                   <div class="modal-footer">
                       <asp:Button runat="server" class="btn btn-primary" OnClick=BorrarNoticia EnableViewState="True" Text="Si"/>
                       <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                   </div>
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
