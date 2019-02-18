<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManBuscarPersona.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManBuscarPersona"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">       
     
    <div class="form-row">
    <div class="form-group col-md-12">
      <h2>Personas Registradas</h2>    
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
                onrowediting = "gvPerson_RowEditing"      
                onrowdeleting = "gvPerson_RowDeleting"        
                onsorting = "gvPerson_Sorting"
                CssClass = "table table-hover table-striped"
                BorderWidth="0"> 
                <Columns> 
                    <asp:BoundField DataField="LintID" HeaderText="Id" ReadOnly="True" SortExpression="LintID" ItemStyle-HorizontalAlign="Center"/>        
                    <asp:TemplateField HeaderText="Tipo Identificación" SortExpression="LstrTipoIdentificacion"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("LstrTipoIdentificacion") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Identificación" SortExpression="LstrCedula"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("LstrCedula") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Nombre" SortExpression="LstrNombre"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("LstrNombre") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Apellido" SortExpression="LstrApelido"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("LstrApelido") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Alias" SortExpression="LstrAlias"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("LstrAlias") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="Editar <i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" ButtonType="Link"/>
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
                    <h4 class="modal-title">Borrar Persona</h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal runat="server" ID="borrarMensaje"></asp:Literal></p>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" class="btn btn-primary" OnClick="BorrarPersona" EnableViewState="True" Text="Si"/>
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
