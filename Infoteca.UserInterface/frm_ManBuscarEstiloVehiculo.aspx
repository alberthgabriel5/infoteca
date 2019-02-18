<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ManBuscarEstiloVehiculo.aspx.cs" Inherits="Infoteca.UserInterface.frm_ManBuscarEstiloVehiculo"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">       
     
    <div class="form-row">
    <div class="form-group col-md-12">
      <h2>Estilos de Vehiculo</h2>    
    </div>    
  </div>
   <div class="form-row">
        <br />
        <div class="table-wrapper-scroll-y">
            <table class="table table-bordered table-striped">
            <thead>
                <tr>
                <th scope="col">#</th>
                <th scope="col">Nombre</th>            
                <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                <th scope="row">1</th>
                <td>Todo Terreno 4x4</td>             
                <td><button type="button" class="btn btn-info">Ver Detalle</button></td>
                </tr>               
            </tbody>
            </table>
        </div>
 <ul class="pagination">
  <li><a href="#">1</a></li>
  <li><a href="#">2</a></li>
  <li><a href="#">3</a></li>
  <li><a href="#">4</a></li>
  <li><a href="#">5</a></li>
</ul> 
</asp:Content>
