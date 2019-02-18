<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManInicioCatalogos.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManInicioCatalogos"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">       
     
<div class="form-row">
    <div class="form-group col-md-12">
        <h2>Catalogos</h2>    
    </div>    
</div>
    <div class="form-row">
	    <div class="form-group col-md-4">
		    <table class="table">
			    <thead class="bg-primary">
				    <tr>
					    <th>Tipos Delito</th>   
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td><a href="frm_ManInsertarTipoDelito.aspx">Agregar</a></td>       
				    </tr>
				    <tr>
					    <td><a href="frm_ManBuscarTipoDelito.aspx">Listado (Editar/Borrar)</a></td>        
				    </tr>				    
			    </tbody>
		    </table>      
	    </div>
	    <div class="form-group col-md-4">
		    <table class="table">
			    <thead class="bg-primary">
				    <tr>
					    <th>Tipo de Fuente</th>   
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td><a href="frm_ManInsertarTipoFuente.aspx">Agregar</a></td>       
				    </tr>
				    <tr>
					    <td><a href="frm_ManBuscarTipoFuente.aspx">Listado (Editar/Borrar)</a></td>        
				    </tr>				    
			    </tbody>
		    </table>
	    </div>	
        <div class="form-group col-md-4">
            <table class="table">
                <thead class="bg-primary">
                <tr>
                    <th>Fuentes</th>   
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td><a href="frm_ManInsertarFuente.aspx">Agregar</a></td>       
                </tr>
                <tr>
                    <td><a href="frm_ManBuscarFuente.aspx">Listado (Editar/Borrar)</a></td>        
                </tr>
                </tbody>
            </table>      
        </div>
    </div> 
    <div class="form-row">
        <div class="form-group col-md-4">
            <table class="table">
                <thead class="bg-primary">
                <tr>
                    <th>Personas</th>   
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td><a href="frm_ManInsertarPersona.aspx">Agregar</a></td>       
                </tr>
                <tr>
                    <td><a href="frm_ManBuscarPersona.aspx">Listado (Editar/Borrar)</a></td>        
                </tr>
                </tbody>
            </table>      
        </div>	
        <div class="form-group col-md-4">
            <table class="table">
                <thead class="bg-primary">
                <tr>
                    <th>Vehiculos</th>   
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td><a href="frm_ManInsertarVehiculo.aspx">Agregar</a></td>       
                </tr>
                <tr>
                    <td><a href="frm_ManBuscarVehiculo.aspx">Listado (Editar/Borrar)</a></td>        
                </tr>
                </tbody>
            </table>      
        </div>	
	    <div class="form-group col-md-4">
		    <table class="table">
			    <thead class="bg-primary">
				    <tr>
					    <th>Persona Juridicas</th>   
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td><a href="frm_ManInsertarPersonaJuridica.aspx">Agregar</a></td>       
				    </tr>
				    <tr>
					    <td><a href="frm_ManBuscarPersonaJuridica.aspx">Listado (Editar/Borrar)</a></td>        
				    </tr>				    
			    </tbody>
		    </table>      
	    </div>
    </div> 
    <div class="form-row">
        <div class="form-group col-md-4">
            <table class="table">
                <thead class="bg-primary">
                <tr>
                    <th>Propiedades</th>   
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td><a href="frm_ManInsertarPropiedad.aspx">Agregar</a></td>       
                </tr>
                <tr>
                    <td><a href="frm_ManBuscarPropiedad.aspx">Listado (Editar/Borrar)</a></td>        
                </tr>				    
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
