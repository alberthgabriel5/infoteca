<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManVerNoticia.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManVerNoticia"  MasterPageFile="~/MasterPage.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 

  <div class="container">

    <ul class="nav nav-tabs">
    <li class="active"><a href="#home">Noticia</a></li>
    <li><a href="#menu11">Imagenes</a></li>
    <li><a href="#menu1">Fuente</a></li>
    <li><a href="#menu2">Personas</a></li>
    <li><a href="#menu3">Vehiculos</a></li>
    <li><a href="#menu4">Personas Juridicas</a></li>
    <li><a href="#menu5">Propiedades</a></li>
    </ul>
    <form action="demo.php" method="post">
      <div class="tab-content">
        <div id="home" class="tab-pane fade in active">          
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="TipoDelito">Tipo Delito</label>
                    <asp:Label runat="server" ID="TipoDelito" class="form-control"/> 
                </div>        
            </div> 
            <div class="form-row">
                <div class="form-group col-md-4"> 
                    <label for="fecha">Fecha de la noticia/evento</label>
                    <asp:Label runat="server" ID="Fecha" class="form-control"/> 
                </div>
             </div>
            <div class="form-row">
                    <div class="form-group col-md-6">
                    <label for="descripcion">Descripción:</label>
                    <asp:Label class="form-control" rows="5" ID="Descripcion" runat="server"></asp:Label>
                </div> 
            </div>
            <div class="form-row">
            <div class="form-group col-md-6">
                <label for="subDelito">Sub Delito</label>
                <asp:Label  class="form-control" ID="SubDelito" runat="server"/>
            </div>        
            <div class="form-group col-md-6">
                <label for="palabrasClave">Palabras Clave</label>
                <asp:Label class="form-control" ID="PalabrasClave" runat="server"/>
            </div>
            </div>
            <div class="form-group col-md-12">           
                <asp:LinkButton runat="server" ID="volver" PostBackUrl="frm_ManBuscarNoticia.aspx" Text="Volver" CssClass="btn btn-primary"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="LBExportar" CssClass="btn btn-primary">Exportar a PDF <i aria-hidden="true" class="glyphicon glyphicon-export"></i></asp:LinkButton>
            </div>
        </div>        
        <div id="menu1" class="tab-pane fade">         
            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="form-group">
                        <div class="col-md-10">
                            <label for="Fuente">Fuente</label>
                            <asp:Label class="form-control" ID="Fuente" runat="server"/>
                        </div>
                    </div>
                </div>   
                <div class="form-group col-md-12">
                    <div class="form-group">
                        <div class="col-md-10">
                            <label for="Titulo">Titulo</label>
                            <asp:Label class="form-control" ID="Titulo" runat="server"/>
                        </div>
                    </div>
                </div>  
                <div class="form-group col-md-12">
                    <div class="form-group">
                        <div class="col-md-10">
                            <label for="Subtitulo">Subtitulo</label>
                            <asp:Label class="form-control" ID="Subtitulo" runat="server"/>
                        </div>
                    </div>
                </div>  
            </div>
        </div>
          <div id="menu11" class="tab-pane fade">         
              <asp:Table runat="server" ID="TablaImagenes" BorderWidth="0">
                  
              </asp:Table>
          </div>
        <div id="menu2" class="tab-pane fade">
          <h3>Personas</h3>
            <asp:Table runat="server" ID="TablaPersonas" class="table table-bordered table-striped">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell scope="Column">Identificación</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Nombre</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Apellidos</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Alias</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div id="menu3" class="tab-pane fade">
          <h3>Vehiculos</h3>
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
        <div id="menu4" class="tab-pane fade">
          <h3>Personas Juridicas</h3>
            <asp:Table runat="server" ID="TablasJuridicas" class="table table-bordered table-striped">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell scope="Column">Tipo Idenficacion</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Identificación</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Nombre</asp:TableHeaderCell>
                    <asp:TableHeaderCell scope="Column">Nombre Fantasia</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div id="menu5" class="tab-pane fade">
          <h3>Propiedades</h3>
            <asp:Table runat="server" ID="TablaPropiedades" class="table table-bordered table-striped">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell scope="Column">Ubicación</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>    
        </div>
    </form>
    </div>

    <script>
        $(document).ready(function(){
            $(".nav-tabs a").click(function(){
                $(this).tab('show');
            });
            $('.nav-tabs a').on('shown.bs.tab', function(event){
                var x = $(event.target).text();         
                var y = $(event.relatedTarget).text();  
                $(".act span").text(x);
                $(".prev span").text(y);
            });
        });
    </script>

</asp:Content>
