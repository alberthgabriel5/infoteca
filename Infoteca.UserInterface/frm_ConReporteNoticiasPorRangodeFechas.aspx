<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ConReporteNoticiasPorRangodeFechas.aspx.cs" Inherits="Infoteca.UserInterface.frm_ConReporteNoticiasPorRangodeFechas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <div class="container">
    <h2>Reporte Noticias por Rango de Fechas</h2>
    <hr />
    <div class="form-row">
        <div class="form-group col-md-1">   
            <label for="calendar-1">Desde:</label>            
        </div>
        <div class="form-group col-md-3"> 
            <div class='input-group date' id='date-time-picker-desde'>                
                <input runat="server" ID="FechaDesde" type='text' class="form-control" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
        </div>
        <div class="form-group col-md-1">  
            <label for="calendar-2">Hasta:</label>
        </div>
        <div class="form-group col-md-3">  
            <div class='input-group date' id='date-time-picker-hasta'>                
                <input runat="server" ID="FechaHasta" type='text' class="form-control" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
        </div>
        <div class="form-group col-md-1">  
            <asp:Button type="button" class="btn btn-primary" Text="Buscar" runat="server" OnClick="BuscarPorFechas"></asp:Button>
        </div>   
        <div class="form-group col-md-2">
            <asp:LinkButton  class="btn btn-primary" id="BtnGenerarPDF" runat="server" Visible="False" OnClick="GenerarPDF_OnClick">Exportar a PDF <i aria-hidden="true" class="glyphicon glyphicon-export"></i></asp:LinkButton>
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
