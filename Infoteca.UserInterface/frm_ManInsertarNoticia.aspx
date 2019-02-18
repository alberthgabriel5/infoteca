<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManInsertarNoticia.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManInsertarNoticia"  MasterPageFile="~/MasterPage.Master"%>

<%@ Register tagprefix="control" Tagname="mensaje" src="~/controles/MostrarMensajes.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>
        .mycheckbox input[type="checkbox"] 
        { 
            margin-right: 7px; 
        }
    </style>

  <div class="container">

    <ul class="nav nav-tabs">
    <li class="active"><a href="#home">Registro</a></li>
    <li><a href="#menu1">Fuente</a></li>
    <li><a href="#menu2">Personas</a></li>
    <li><a href="#menu3">Vehiculos</a></li>
    <li><a href="#menu4">Personas Juridicas</a></li>
    <li><a href="#menu5">Propiedades</a></li>
    </ul>
    <form method="post">
      <div class="tab-content">
        <div id="home" class="tab-pane fade in active">
          <h3>Registro</h3>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="TipoDelitos">Tipo Delito</label>
                    <asp:DropDownList runat="server" ID="TipoDelitos" class="form-control"> 
                        <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                    </asp:DropDownList>
                </div>        
            </div> 
            <div class="form-row">
                <div class="form-group col-md-4"> 
                    <label for="fecha">Fecha de la noticia/evento</label>
                    <div class='input-group date' id='date-time-picker'>                
                        <input type='text' class="form-control" ID="fecha" runat="server"/>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
             </div>
            <div class="form-row">
                    <div class="form-group col-md-6">
                    <label for="descripcion">Descripción:</label>
                    <textarea class="form-control" rows="5" ID="descripcion" runat="server"></textarea>
                </div> 
            </div>
            <div class="form-row">
            <div class="form-group col-md-6">
                <label for="inpusubDelitotCity">Sub Delito</label>
                <input type="text" class="form-control" ID="subDelito" runat="server"/>
            </div>        
            <div class="form-group col-md-6">
                <label for="palabrasClave">Palabras Clave</label>
                <input type="text" class="form-control" ID="palabrasClave" runat="server"/>
            </div>
            </div>
            <div class="form-row">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <div class="form-group col-md-12">
                <label for="AjaxFileUpload1">Imagenes:</label>
                    <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" onuploadcomplete="AjaxFileUpload1_UploadComplete" ThrobberID="myThrobber"  MaximumNumberOfFiles="50" AllowedFileTypes="jpg,jpeg,gif,png" />
                </div> 
            </div>
            <div class="form-group col-md-12">
            <asp:Button type="submit" class="btn btn-primary" runat="server" ID="registrar" OnClick="Registrar_Noticia" Text="Registrar"></asp:Button> 
            </div>
        </div>        
        <div id="menu1" class="tab-pane fade">
          <h3>Fuente</h3>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="form-group">
                        <div class="col-md-10">
                            <label class="radio-inline">
                                <input name="optionsRadios" type="radio" checked="true" ID="opcionRadioSeleccionar" runat="server"/>
                                Seleccionar existente
                            </label>
                            <label class="radio-inline">
                                <input name="optionsRadios" type="radio" ID="opcionRadioCrear" runat="server"/>
                                Crear nueva
                            </label>
                        </div>
                    </div>
                </div>        
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <fieldset id="myfields">
                    <label for="inputState">Seleccionar Fuente</label>
                    <asp:DropDownList runat="server" ID="Fuentes" class="form-control"> 
                        <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                    </asp:DropDownList>
                    </fieldset>
                </div>        
            </div>
                <div id="creardiv" style="display: none">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label>Crear nueva Fuente</label>
                        </div>        
                    </div>
                   <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="TipoFuentes">Tipo Fuente</label>
                            <asp:DropDownList runat="server" ID="TipoFuentes" class="form-control"> 
                                <asp:ListItem Text="Por favor seleccione una opción" Value="-1" />
                            </asp:DropDownList>
                        </div>        
                    </div>
                    <div class="form-group col-md-6">
                        <label for="NombreFuente">Nombre</label>
                        <input type="text" class="form-control" id="NombreFuente" runat="server"/>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="Titulo">Titulo</label>
                        <input type="text" class="form-control" id="Titulo" runat="server"/>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="Subtitulo">Subtitulo</label>
                        <input type="text" class="form-control" id="Subtitulo" runat="server"/>
                    </div>
                </div>
        </div>
        <div id="menu2" class="tab-pane fade">
          <h3>Personas</h3>
            <div class="form-row">
                <div class="form-group col-md-3 text-center">
                    <label for="PersonasMLB">Lista de Personas</label><br/>
                    <div class="form-row">
                        <div class="form-group col-md-10">
                            <div class="form-group has-feedback">
                                <asp:TextBox runat="server" class="form-control" ID="FiltrarPersonas" placeholder="Filtrar resultados"></asp:TextBox>
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            </div>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button runat="server" ID="btnfiltrarPersonas" OnClick="FiltrarPersonas_TextChanged" CssClass="btn btn-default" Text="Filtrar"/>
                        </div>
                    </div> 
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="300" Height="300" ID="PersonasMLB" />
                </div>   
                <div class="form-group col-md-2 text-center">
                    <br/><br/><br/><br/>
                    <asp:Button runat="server" ID="AgregarPersonas" Text="Agregar" CssClass="btn btn-primary" OnClick="AgregarPersonas_OnClick"/>
                    <br/><br/>
                    <asp:Button runat="server" ID="QuitarPersonas" Text="Quitar" CssClass="btn btn-primary" OnClick="QuitarPersonas_OnClick"/>
                </div>   
                <div class="form-group col-md-3 text-center">
                    <br/><br/><br/>
                    <label for="PersonasMLB">Personas Seleccionadas</label><br/>
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="300" Height="300" ID="PersonasSeleccionadasMLB"/>
                
                </div>   
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <asp:CheckBox id="checkCrearPersona" CssClass="mycheckbox" onclick="CrearPersona()" runat="server"  title="Crear Persona" Checked="False" Text="Crear Nueva Persona"/>
                </div>
            </div>
            <div id="crearPersonaDiv" style="display: none">
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="inputState">Tipo Identificación</label>
                        <select id="inputState" class="form-control">
                            <option selected>Elegir...</option>
                            <option>Cédula</option>
                            <option>Pasaporte</option>
                            <option>Desconocido</option>
                        </select>
                    </div> 
                    <div class="form-group col-md-6">
                        <label for="Identificación">Identificación</label>
                        <input type="text" class="form-control" id="Identificacion" runat="server"/>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Nombre">Nombre</label>
                        <input type="text" class="form-control" id="NombrePersona" runat="server"/>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="Apellidos">Apellidos</label>
                        <input type="text" class="form-control" id="Apellidos" runat="server"/>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Alias">Alias</label>
                        <input type="text" class="form-control" id="Alias" runat="server"/>
                    </div>
                    <div class="form-group col-md-6">
                        <br/>
                        <asp:Button class="btn btn-primary" runat="server" ID="Button1" OnClick="Registrar_Persona" Text="Agregar"></asp:Button> 
                    </div>
                </div>
            </div>
        </div>
        <div id="menu3" class="tab-pane fade">
          <h3>Vehiculos</h3>
               <div class="form-row">
                <div class="form-group col-md-3 text-center">
                    <label for="PersonasMLB">Lista de Vehiculos</label><br/>
                    <div class="form-row">
                        <div class="form-group col-md-10">
                            <div class="form-group has-feedback">
                                <asp:TextBox runat="server" class="form-control" ID="FiltrarVehiculos" placeholder="Filtrar resultados"></asp:TextBox>
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            </div>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button runat="server" ID="Button11" OnClick="FiltrarVehiculos_TextChanged" CssClass="btn btn-default" Text="Filtrar"/>
                        </div>
                    </div> 
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="300" Height="300" ID="ListBoxVehiculos" />
                </div>   
                <div class="form-group col-md-2 text-center">
                    <br/><br/><br/><br/>
                    <asp:Button runat="server" ID="Button2" Text="Agregar" CssClass="btn btn-primary" OnClick="AgregarVehiculos_OnClick"/>
                    <br/><br/>
                    <asp:Button runat="server" ID="Button3" Text="Quitar" CssClass="btn btn-primary" OnClick="QuitarVehiculos_OnClick"/>
                </div>   
                <div class="form-group col-md-3 text-center">
                    <br/><br/><br/>
                    <label for="PersonasMLB">Vehiculos Seleccionados</label><br/>
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="300" Height="300" ID="ListBoxVehiculoSeleccionados"/>
                
                </div>   
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <asp:CheckBox runat="server" id="CheckBoxCrearVehiculo" CssClass="mycheckbox"  onclick="CrearVehiculo()"  title="Crear Vehiculo" Checked="False" Text="Crear Nuevo Vehiculo"/>
                </div>
            </div>
            <div id="crearVehiculoDiv" style="display: none">
                
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Placa">Placa</label>
                        <input type="text" class="form-control" id="Placa" runat="server"/>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="Marca">Marca</label>
                        <input type="text" class="form-control" id="Marca" runat="server"/>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Modelo">Modelo</label>
                        <input type="text" class="form-control" id="Modelo" runat="server"/>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="inputColorZip">Color</label>
                        <input type="text" class="form-control" id="Color" runat="server"/>
                    </div>
                </div>
                <div class="form-row">

                    <div class="form-group col-md-6">
                        <label for="Tipo">Tipo</label>
                        <input type="text" class="form-control" id="Tipo" runat="server" />
                    </div>  
                </div>

                <div class="form-row">
                    <div class="form-group col-md-12">
                        <br/>
                        <asp:Button class="btn btn-primary" runat="server" ID="Button4" OnClick="Registrar_Vehiculo" Text="Agregar"></asp:Button> 
                    </div>
                </div>
            </div>
        </div>
        <div id="menu4" class="tab-pane fade">
          <h3>Personas Juridicas</h3>
            <div class="form-row">
                <div class="form-group col-md-3 text-center">
                    <label for="PersonasMLB">Lista de Personas Juridicas</label><br/>
                    <div class="form-row">
                        <div class="form-group col-md-10">
                            <div class="form-group has-feedback">
                                <asp:TextBox runat="server" class="form-control" ID="FiltarPersonasJuridicas" placeholder="Filtrar resultados"></asp:TextBox>
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            </div>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button runat="server" ID="Button12" OnClick="FiltrarPersonasJuridicas_TextChanged" CssClass="btn btn-default" Text="Filtrar"/>
                        </div>
                    </div> 
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="200" Height="300" ID="ListBoxPersonaJuridicas" />
                </div>   
                <div class="form-group col-md-2 text-center">
                    <br/><br/><br/><br/>
                    <asp:Button runat="server" ID="Button5" Text="Agregar" CssClass="btn btn-primary" OnClick="AgregarPersonaJuridicas_OnClick"/>
                    <br/><br/>
                    <asp:Button runat="server" ID="Button6" Text="Quitar" CssClass="btn btn-primary" OnClick="QuitarPersonaJuridicas_OnClick"/>
                </div>   
                <div class="form-group col-md-3 text-center">
                    <br/><br/><br/>
                    <label for="PersonasMLB">Personas Juridicas Seleccionadas</label><br/>
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="200" Height="300" ID="ListBoxPersonaJuridicaSeleccionados"/>
                
                </div>   
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <asp:CheckBox runat="server" id="CheckBoxPersonaJuridica" CssClass="mycheckbox" onclick="CrearPersonaJuridica()"  title="Crear Persona Juridica" Checked="False" Text="Crear Nueva Persona Juridica"/>
                </div>
            </div>
            <div id="crearPersonaJuridicaDiv" style="display: none">
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Identificacion">Identificación</label>
                        <input type="text" class="form-control" id="IdentificacionJU" runat="server"/>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="NombreJU">Nombre</label>
                        <input type="text" class="form-control" id="NombreJU" runat="server"/>
                    </div>  
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Fantasia">Nombre Fantasia</label>
                        <input type="text" class="form-control" id="Fantasia" runat="server"/>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <br/>
                        <asp:Button class="btn btn-primary" runat="server" ID="Button7" OnClick="Registrar_PersonaJuridica" Text="Agregar"></asp:Button> 
                    </div>
                </div>
            </div>
        </div>
        <div id="menu5" class="tab-pane fade">
          <h3>Propiedades</h3>
            <div class="form-row">
                <div class="form-group col-md-3 text-center">
                    <label for="PersonasMLB">Lista de Propiedades</label><br/>
                    <div class="form-row">
                        <div class="form-group col-md-10">
                            <div class="form-group has-feedback">
                                <asp:TextBox runat="server" class="form-control" ID="FiltrarPropiedades" placeholder="Filtrar resultados"></asp:TextBox>
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            </div>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button runat="server" ID="Button13" OnClick="FiltrarPropiedades_TextChanged" CssClass="btn btn-default" Text="Filtrar"/>
                        </div>
                    </div> 
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="300" Height="300" ID="ListBoxPropiedades" />
                </div>   
                <div class="form-group col-md-2 text-center">
                    <br/><br/><br/><br/>
                    <asp:Button runat="server" ID="Button8" Text="Agregar" CssClass="btn btn-primary" OnClick="AgregarPropiedades_OnClick"/>
                    <br/><br/>
                    <asp:Button runat="server" ID="Button9" Text="Quitar" CssClass="btn btn-primary" OnClick="QuitarPropiedades_OnClick"/>
                </div>   
                <div class="form-group col-md-3 text-center">
                    <br/><br/><br/>
                    <label for="PersonasMLB">Propiedad Seleccionadas</label><br/>
                    <asp:ListBox runat="server" SelectionMode="Multiple" Width="300" Height="300" ID="ListBoxPropiedadeSeleccionados"/>
                
                </div>   
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <asp:CheckBox runat="server" id="CheckBoxPropiedad" CssClass="mycheckbox" onclick="CrearPropiedad()"  title="Crear Propiedad" Checked="False" Text="Crear Nueva Propiedad"/>
                </div>
            </div>
            <div id="crearPropiedadDiv" style="display: none">
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="TipoPropiedad">Tipo Propiedad</label>
                        <select id="TipoPropiedad" class="form-control" runat="server">
                            <option selected>Otro</option>
                            <option>Casa de habitación</option>
                            <option>Apartamento</option>
                            <option>Finca</option>
                            <option>Lote</option>
                            <option>Espacio comercial</option>
                        </select>
                    </div> 
                    <div class="form-group col-md-6">
                        <label for="Ubicacion">Ubicación</label>
                        <input type="text" class="form-control" ID="Ubicacion" runat="server"/>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <br/>
                        <asp:Button class="btn btn-primary" runat="server" ID="Button10" OnClick="Registrar_Propiedad" Text="Agregar"></asp:Button> 
                    </div>
                </div>
            </div>
        </div>      
        <div class="form-group col-md-6" runat="server">
            <control:mensaje runat="server" id="controlMensajes" />
        </div>
        </div>
    <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
        
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title" style="color: red" runat="server" ID="ModalTitulo"></h4>
                    </div>
                    <div class="modal-body">
                        <p><asp:Literal runat="server" ID="ModalMensaje"></asp:Literal></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
          
            </div>
        </div>
        <asp:HiddenField ID="hidTAB" runat="server" Value="#Home" />
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

    <script type="text/javascript">
        $(function () {
            $('#date-time-picker').datetimepicker({ format: 'DD/MM/YYYY', locale: 'es' });         
        });
    </script>

    <script type="text/javascript">
        $("#ContentPlaceHolder1_opcionRadioSeleccionar").click(function() {
            $("#myfields").prop("disabled", false);
            $("#creardiv").css("display","none");;
        });
        $("#ContentPlaceHolder1_opcionRadioCrear").click(function() {
            $("#myfields").prop("disabled", true);
            $("#creardiv").css("display","block");;
        });
        
    </script>

    <script type="text/javascript">
     
        //run AjaxFileUpload_change_text() function after page load
        //that example uses  jquery
        $(document).ready(function () {
            AjaxFileUpload_change_text();
     
        });
     
        function AjaxFileUpload_change_text() {
            //Here you can write whatever you want = "..."
            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFile = "Seleccione los Archivos";
            Sys.Extended.UI.Resources.AjaxFileUpload_DropFiles = "Arrastrar archivos aquí";
            Sys.Extended.UI.Resources.AjaxFileUpload_Pending = "Pendiente";
            Sys.Extended.UI.Resources.AjaxFileUpload_Remove = "Borrar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Upload = "Cargar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded = "Cargado";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadedPercentage = "Cargados {0} %";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploading = "Cargando";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileInQueue = "{0} Archivo(s) en cola.";
            Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded = "Todos los archivos se han cargado.";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileList = "Lista de archivos cargados:";
            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload = "Por Favor selecciones archivo(s) para cargar.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancelling = "Cancelando...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadError = "Un Error ha ocurido durante la carga.";
            Sys.Extended.UI.Resources.AjaxFileUpload_CancellingUpload = "Cancelando carga...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingInputFile = "Cargando archivo: {0}.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancel = "Cancelar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Canceled = "cancelado";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadCanceled = "Carga de Archivo cancelada";
            Sys.Extended.UI.Resources.AjaxFileUpload_DefaultError = "Carga de Archivo error";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingHtml5File = "Cargando archivo: {0}con tamaño {1} bytes.";
            Sys.Extended.UI.Resources.AjaxFileUpload_error = "error";
        }
     
    </script>

    <script>
        function CrearPersona() {
            var checkBox = document.getElementById("ContentPlaceHolder1_checkCrearPersona");
            var text = document.getElementById("crearPersonaDiv");
            if (checkBox.checked == true){
                text.style.display = "block";
            } else {
                text.style.display = "none";
            }
        }
    </script>

    <script>
        function CrearVehiculo() {
            var checkBox = document.getElementById("ContentPlaceHolder1_CheckBoxCrearVehiculo");
            var text = document.getElementById("crearVehiculoDiv");
            if (checkBox.checked == true){
                text.style.display = "block";
            } else {
                text.style.display = "none";
            }
        }
    </script>

    <script>
        function CrearPersonaJuridica() {
            var checkBox = document.getElementById("ContentPlaceHolder1_CheckBoxPersonaJuridica");
            var text = document.getElementById("crearPersonaJuridicaDiv");
            if (checkBox.checked == true){
                text.style.display = "block";
            } else {
                text.style.display = "none";
            }
        }
    </script>

    <script>
        function CrearPropiedad() {
            var checkBox = document.getElementById("ContentPlaceHolder1_CheckBoxPropiedad");
            var text = document.getElementById("crearPropiedadDiv");
            if (checkBox.checked == true){
                text.style.display = "block";
            } else {
                text.style.display = "none";
            }
        }
    </script>
    
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
        function closeModal() {
            $('#myModal').modal('hide');
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            var tab = document.getElementById('<%= hidTAB.ClientID%>').value;
            $('.nav-tabs a[href="' + tab + '"]').tab('show');
        });
    </script>

</asp:Content>
