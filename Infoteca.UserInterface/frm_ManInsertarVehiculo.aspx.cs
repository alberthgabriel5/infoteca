using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarVehiculo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarVehiculo(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{Placa.Value}{Modelo.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese una placa o un Modelo!");
                return;
            }

            var vehiculo = new VehiculoUT
            {
                LstrPlaca = Placa.Value,
                LstrMarca = Marca.Value,
                LstrModelo = Modelo.Value,
                LstrColor = Color.Value,
                LstrEstilo = Tipo.Value,
                LbytActivo = 1
            };

            var mensajeError = new MensajeError();

            var vehiculoCreado = VehiculoBL.InsertarVehiculo(vehiculo, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al crear la Vehiculo");

                controlMensajes.MostrarMensaje(true, "Error al crear la Vehiculo");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"Vehiculo Creado: {vehiculoCreado}");

                controlMensajes.MostrarMensaje(false, $"Se ha creado la vehiculo: {vehiculoCreado.LstrPlaca}");
            }

            Placa.Value = string.Empty;
            Marca.Value = string.Empty;
            Modelo.Value = string.Empty;
            Color.Value = string.Empty;
            Tipo.Value = string.Empty;
        }
    }
}