using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarTipoFuente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarTipoFuente(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputNombre.Value))
            {
                controlMensajes.MostrarMensaje(true, "Tipo de fuente no valido!");
                return;
            }

            var tipoFuente = new TipoFuenteUT
            {
                FdtiFechaCreaccion = DateTime.Now,
                LstrNombre = inputNombre.Value
            };

            var mensajeError = new MensajeError();

            var tipoFuenteCreado = TipoFuenteBL.InsertarTipoFuente(tipoFuente, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al crear el Tipo Fuente");

                controlMensajes.MostrarMensaje(true, "Error al crear el Tipo Fuente");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"TipoFuente Creado: {tipoFuenteCreado}");

                controlMensajes.MostrarMensaje(false, $"Se ha creado el tipo de Fuente {tipoFuenteCreado.LstrNombre}");
            }

            inputNombre.Value = string.Empty;
        }
    }
}