<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ConReporteNoticiasPorTipo.aspx.cs" Inherits="Infoteca.UserInterface.frm_ConReporteNoticiasPorTipo" %>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <div class="container">
    <h2>Reporte noticias por tipo de entidad</h2>
    <hr />
    <div class="form-row">
        <div class="form-group col-md-4">
            <label for="FiltroBusqueda">Tipo Entidad</label>
            <asp:DropDownList runat="server" ID="FiltroBusqueda" class="form-control" OnSelectedIndexChanged="FiltroBusqueda_OnSelectedIndexChanged" AutoPostBack="True"> 
                <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                <asp:ListItem Text="Tipo Delito" Value="1" />
                <asp:ListItem Text="Fuente" Value="2" />
                <asp:ListItem Text="Persona" Value="3" />
                <asp:ListItem Text="Vehiculo" Value="4" />
                <asp:ListItem Text="Persona Juridica" Value="5" />
                <asp:ListItem Text="Propiedad" Value="6" />
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-4" runat="server" ID="DivTipoDelito" Visible="False">
            <label for="TipoDelitos">Tipo Delito</label>
            <asp:DropDownList runat="server" ID="TipoDelitos" class="form-control"> 
                <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-4" runat="server" ID="DivFuente" Visible="False">
            <fieldset id="myfields">
                <label for="Fuentes">Seleccionar Fuente</label>
                <asp:DropDownList runat="server" ID="Fuentes" class="form-control"> 
                    <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                </asp:DropDownList>
            </fieldset>
        </div>
        <div class="form-group col-md-4" runat="server" ID="DivPersona" Visible="False">
            <fieldset id="myfields">
                <label for="PersonasMLB">Seleccionar Persona</label>
                <asp:DropDownList runat="server" ID="PersonasMLB" class="form-control"> 
                    <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                </asp:DropDownList>
            </fieldset>
        </div> 
        <div class="form-group col-md-4" runat="server" ID="DivVehiculo" Visible="False">
            <fieldset id="myfields">
                <label for="VehiculoMLB">Seleccionar Vehiculo</label>
                <asp:DropDownList runat="server" ID="VehiculoMLB" class="form-control"> 
                    <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                </asp:DropDownList>
            </fieldset>
        </div> 
        <div class="form-group col-md-4" runat="server" ID="DivPersonaJuridica" Visible="False">
            <fieldset id="myfields">
                <label for="VehiculoMLB">Seleccionar Persona Juridica</label>
                <asp:DropDownList runat="server" ID="PersonaJuridicaMLB" class="form-control"> 
                    <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                </asp:DropDownList>
            </fieldset>
        </div> 
        <div class="form-group col-md-4" runat="server" ID="DivPropiedad" Visible="False">
            <fieldset id="myfields">
                <label for="VehiculoMLB">Seleccionar Propiedad</label>
                <asp:DropDownList runat="server" ID="PropiedadMLB" class="form-control"> 
                    <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                </asp:DropDownList>
            </fieldset>
        </div> 
        <div class="form-group col-md-1">  
            <asp:Button ID="BtnBuscar" type="button" class="btn btn-primary" Text="Buscar" runat="server" OnClick="BuscarPorTipo" Visible="False" style="margin-top: 25px;"></asp:Button>
        </div>   
        <div class="form-group col-md-2">
            <asp:LinkButton  class="btn btn-primary" id="BtnGenerarPDF" runat="server" Visible="False" OnClick="GenerarPDF_OnClick" style="margin-top: 25px;">Exportar a PDF <i aria-hidden="true" class="glyphicon glyphicon-export"></i></asp:LinkButton>
        </div>   
    </div>
    <div class="form-row">
        <div class="form-group col-md-12">   
            <asp:Label runat="server" ID="coincidencias" class="label-success" Visible="False"></asp:Label>  
            <asp:Label runat="server" ID="Mensaje" class="alert-danger" Visible="False"></asp:Label> 
        </div>              
    </div>
    <div class="form-group col-md-6" runat="server">
        <control:mensaje runat="server" id="controlMensajes" />
    </div>
    <div class="form-row">
        <br />
        <div class="table-wrapper-scroll-y">
            <div class="form-group col-md-11" id="renderPDF" runat="server">
                 <asp:GridView ID="gvNoticia" runat="server" AutoGenerateColumns = "False" 
                onrowdatabound = "gvNoticia_RowDataBound"  
                onpageindexchanging = "gvNoticia_PageIndexChanging"  
                onsorting = "gvNoticia_Sorting"
                CssClass = "table table-hover table-striped"
                BorderWidth="0"> 
                <Columns> 
                    <asp:BoundField DataField="LintID" HeaderText="Id" ReadOnly="True" SortExpression="LintId" ItemStyle-HorizontalAlign="Center"/>        
                   
                    <asp:TemplateField HeaderText="Descripción" SortExpression="LstrDescripcion"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("LstrDescripcion") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Fecha del Evento" SortExpression="LdtiFecha"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("LdtiFecha") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Tipo Delito" SortExpression="LintIdTipoDelito"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("LintIdTipoDelito") %>'></asp:Label> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Fuente" SortExpression="LintIdFuente"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("LintIdFuente") %>'></asp:Label> 
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
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/locale/es.js" ></script>

    <script type="text/javascript">
        $(function () {
            $('#date-time-picker-desde').datetimepicker({ format: 'DD/MM/YYYY', locale: 'es' });
            $('#date-time-picker-hasta').datetimepicker({ format: 'DD/MM/YYYY', locale: 'es' });
            });

    </script>
    </div>
</asp:Content>
