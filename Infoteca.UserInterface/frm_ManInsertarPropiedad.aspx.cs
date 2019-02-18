using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarPropiedad : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarPropiedad(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Ubicacion.Value))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese una Ubicación!");
                return;
            }

            var propiedad = new PropiedadUT
            {
                LstrTipoPropiedad = TipoPropiedad.Value,
                LstrLugar = Ubicacion.Value,
                LbytActivo = 1
            };

            var mensajeError = new MensajeError();

            var propiedadCreado = PropiedadBL.InsertarPropiedad(propiedad, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al crear la Propiedad");

                controlMensajes.MostrarMensaje(true, "Error al crear la Propiedad");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"Propiedad Creado: {propiedadCreado}");

                controlMensajes.MostrarMensaje(false, $"Se ha creado la propiedad: {propiedadCreado.LstrLugar}");
            }

            Ubicacion.Value = string.Empty;
            TipoPropiedad.Value = TipoPropiedad.Items[0].Value;
        }
    }
}