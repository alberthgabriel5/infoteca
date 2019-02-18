<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ConBusquedaPorCriterio.aspx.cs" Inherits="Infoteca.UserInterface.frm_ConBusquedaPorCriterio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.css" rel="stylesheet"/>
    <link href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.css" rel="stylesheet"/>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.2/moment.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>

    <div class="container">
    <h2>Busqueda por Criterios</h2>
    <hr />
    <div class="form-row">
        <div class="form-group col-md-2">   
            <label for="calendar-1">Criterios (Separados por comas):</label>           
        </div>
        <div class="form-group col-md-8">   
            <asp:TextBox type="text" class="form-control" runat="server" ID="Criterios"/>          
        </div> 
        <div class="form-group col-md-2">  
            <asp:Button type="button" class="btn btn-primary" Text="Buscar" runat="server" OnClick="BuscarPorCriterio"></asp:Button>
        </div>        
    </div>
    <div class="form-row">
        <div class="form-group col-md-12">   
            <asp:Label runat="server" ID="coincidencias" class="label-success" Visible="False"></asp:Label>  
            <asp:Label runat="server" ID="Mensaje" class="alert-danger" Visible="False"></asp:Label> 
        </div>              
    </div>
    <div class="form-row">
        <br />
        <div class="table-wrapper-scroll-y">
            <div class="form-group col-md-12">              
                 <asp:GridView ID="gvNoticia" runat="server" AutoGenerateColumns = "False" 
                    onrowdatabound = "gvNoticia_RowDataBound"  
                    onpageindexchanging = "gvNoticia_PageIndexChanging"  
                    onrowediting = "gvNoticia_RowEditing" 
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
                        <asp:TemplateField HeaderText="Palabras Clave" SortExpression="LstrPalabraClave"> 
                            <ItemTemplate> 
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("LstrPalabraClave") %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                        <asp:CommandField HeaderText="Ver Detalle" ShowEditButton="True" EditText="Ver <i aria-hidden='true' class='glyphicon glyphicon-eye-open'></i>" ButtonType="Link"/>
                    </Columns> 
                    <FooterStyle ForeColor="Black" BorderWidth="0"/> 
                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" Font-Size="X-Large" BorderWidth="0"/> 
                    <SelectedRowStyle Font-Bold="True" ForeColor="Black" BorderWidth="0"/> 
                    <HeaderStyle Font-Bold="True" ForeColor="Black" BorderWidth="0"/>
                    <RowStyle BorderWidth="0"/>
                </asp:GridView> 
            </div> 
        </div>
    </div>
            
    <script type="text/javascript">
        $(function () {
            $('#date-time-picker-desde').datetimepicker({ format: 'DD/MM/YYYY' });
            $('#date-time-picker-hasta').datetimepicker({ format: 'DD/MM/YYYY' });
        });
    </script>

    </div>
</asp:Content>
