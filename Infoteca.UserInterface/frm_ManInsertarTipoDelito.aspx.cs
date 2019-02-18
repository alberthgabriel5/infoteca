using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarTipoDelito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarTipoDelito(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputNombre.Value))
            {
                controlMensajes.MostrarMensaje(true, "Tipo de delito no valido!");
                return;
            }

            var tipoDelito = new TipoDelitoUT
            {
                FdtiFechaCreaccion = DateTime.Now,
                LstrNombre = inputNombre.Value,
                LbytActivo = 1
            };

            var mensajeError = new MensajeError();

            var tipoDelitoCreado = TipoDelitoBL.InsertarTipoDelito(tipoDelito, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al crear el Tipo Delito");

                controlMensajes.MostrarMensaje(true, "Error al crear el Tipo Delito");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"TipoDelito Creado: {tipoDelitoCreado.ToString()}");

                controlMensajes.MostrarMensaje(false, $"Se ha creado el tipo de delito {tipoDelitoCreado.LstrNombre}");
            }

            inputNombre.Value = string.Empty;
        }
    }
}