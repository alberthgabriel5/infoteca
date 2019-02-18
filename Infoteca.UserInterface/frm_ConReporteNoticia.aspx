<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ConReporteNoticia.aspx.cs" Inherits="Infoteca.UserInterface.frm_ConReporteNoticia"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <div class="container-fluid"> 
        <h3>Reporte Noticia</h3>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:TextBox runat="server" ID="NumeroNoticia" CssClass="form-control" placeholder="Id de noticia"></asp:TextBox>
            </div> 
            <div class="form-group col-md-6">
                <asp:Button runat="server" ID="buscar" Text="Buscar" OnClick="BuscarNoticia" CssClass="btn btn-primary" />
                <asp:LinkButton  class="btn btn-primary" id="BtnGenerarPDF" runat="server" Visible="False" OnClick="GenerarPDF_OnClick">Exportar a PDF <i aria-hidden="true" class="glyphicon glyphicon-export"></i></asp:LinkButton>
            </div>  
        </div> 
        <div id="DivNoticia" runat="server" Visible="False">
            <h3 runat="server" ID="TituloNoticia"></h3>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="TipoDelito">Tipo Delito</label>
                <asp:Label runat="server" ID="TipoDelito" class="form-control"/> 
            </div> 
            <div class="form-group col-md-6"> 
                <label for="fecha">Fecha de la noticia/evento</label>
                <asp:Label runat="server" ID="Fecha" class="form-control"/> 
            </div>
         </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="descripcion">Descripción:</label>
                <asp:Label class="form-control" rows="5" ID="Descripcion" runat="server"></asp:Label>
            </div> 
            <div class="form-group col-md-6">
                <label for="subDelito">Sub Delito</label>
                <asp:Label  class="form-control" ID="SubDelito" runat="server"/>
            </div>  
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="palabrasClave">Palabras Clave</label>
                <asp:Label class="form-control" ID="PalabrasClave" runat="server"/>
            </div>
            <div class="form-group col-md-6">
                <label for="Fuente">Fuente</label>
                <asp:Label class="form-control" ID="Fuente" runat="server"/>
            </div>  
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="Titulo">Titulo</label>
                <asp:Label class="form-control" ID="Titulo" runat="server"/>
            </div>  
            <div class="form-group col-md-6">
                <label for="Subtitulo">Subtitulo</label>
                <asp:Label class="form-control" ID="Subtitulo" runat="server"/>
            </div>  
        </div>
        <div class="form-row" runat="server" ID="Div1">
            <div class="form-group col-md-12">
              <h4>Personas</h4>
                <asp:Table runat="server" ID="TablaPersonas" class="table table-bordered table-striped">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell scope="Column">Identificación</asp:TableHeaderCell>
                        <asp:TableHeaderCell scope="Column">Nombre</asp:TableHeaderCell>
                        <asp:TableHeaderCell scope="Column">Apellidos</asp:TableHeaderCell>
                        <asp:TableHeaderCell scope="Column">Alias</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>  
        </div>
        <div class="form-row" runat="server" ID="Div2" Visible="False">
            <div class="form-group col-md-12">
                <h4>Vehiculos</h4>
                <asp:Table runat="server" ID="TablaVehiculos" class="table table-bordered table-striped">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell scope="Column">Placa</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Marca</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Modelo</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Tipo</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Color</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Otras Caracteristicas</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            </div>  
        </div>
        <div class="form-row" runat="server" ID="Div3" Visible="False">
            <div class="form-group col-md-12">
                <h4>Personas Juridicas</h4>
                <asp:Table runat="server" ID="TablasJuridicas" class="table table-bordered table-striped">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell scope="Column">Tipo Idenficacion</asp:TableHeaderCell>
                        <asp:TableHeaderCell scope="Column">Identificación</asp:TableHeaderCell>
                        <asp:TableHeaderCell scope="Column">Nombre</asp:TableHeaderCell>
                        <asp:TableHeaderCell scope="Column">Nombre Fantasia</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>  
        </div>
        <div class="form-row" runat="server" ID="Div4" Visible="False">
            <div class="form-group col-md-12">
                <h4>Propiedades</h4>
                <asp:Table runat="server" ID="TablaPropiedades" class="table table-bordered table-striped">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell scope="Column">Tipo Propiedad</asp:TableHeaderCell>
                        <asp:TableHeaderCell scope="Column">Ubicación</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>  
        </div>
        <div class="form-row" runat="server" ID="Div5" Visible="False">
            <div class="form-group col-md-12">
                <h4>Imagenes Registradas:</h4>  
                <asp:Table runat="server" ID="TablaImagenes" BorderWidth="0"></asp:Table>
            </div>  
        </div>
    </div>
        <div class="form-group col-md-6" runat="server">
            <control:mensaje runat="server" id="ControlMensajes" />
        </div>
    </div>
</asp:Content>
