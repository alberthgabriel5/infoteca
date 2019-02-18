using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManEditarVehiculo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idVehiculo = int.Parse(Request["idVehiculo"] ?? "0");

                CargarVehiculo(idVehiculo);
            }
        }

        protected void ActualizarVehiculo(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{Placa.Value}{Modelo.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese una placa o un Modelo!");
                return;
            }

            var vehiculo = (VehiculoUT)Session["Vehiculo"];

            vehiculo.LstrPlaca = Placa.Value;
            vehiculo.LstrMarca = Marca.Value;
            vehiculo.LstrModelo = Modelo.Value;
            vehiculo.LstrColor = Color.Value;
            vehiculo.LstrEstilo = Tipo.Value;
            vehiculo.LbytActivo = 1;

            var mensajeError = new MensajeError();

            var vehiculoActualizada = VehiculoBL.EditarVehiculo(vehiculo, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al actualizar la Vehiculo");

                controlMensajes.MostrarMensaje(true, "Error al actualizar la Vehiculo");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"Vehiculo actualizada: {vehiculoActualizada}");

                controlMensajes.MostrarMensaje(false, $"Se ha actualizado la vehiculo: {vehiculoActualizada.LstrPlaca}");
            }
        }

        private void CargarVehiculo(int idVehiculo)
        {
            var mensajeError = new MensajeError();
            var vehiculo = VehiculoBL.BuscarVehiculo(idVehiculo, ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                Session.Add("Vehiculo", vehiculo);

                Placa.Value = vehiculo.LstrPlaca;
                Marca.Value = vehiculo.LstrMarca;
                Modelo.Value = vehiculo.LstrModelo;
                Color.Value = vehiculo.LstrColor;
                Tipo.Value = vehiculo.LstrEstilo;
            }
            else
            {
                controlMensajes.MostrarMensaje(true, "Error al cargar la Vehiculo");
            }
        }
    }
}