using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManEditarPropiedad : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idPropiedad = int.Parse(Request["idPropiedad"] ?? "0");

                CargarPropiedad(idPropiedad);
            }
        }

        protected void ActualizarPropiedad(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{Ubicacion.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese una Ubicación!");
                return;
            }

            var propiedad = (PropiedadUT)Session["Propiedad"];

            propiedad.LstrLugar = Ubicacion.Value;
            propiedad.LstrTipoPropiedad = TipoPropiedad.Value;
            propiedad.LbytActivo = 1;

            var mensajeError = new MensajeError();

            var propiedadActualizada = PropiedadBL.EditarPropiedad(propiedad, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al actualizar la Propiedad");

                controlMensajes.MostrarMensaje(true, "Error al actualizar la Propiedad");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"Propiedad actualizada: {propiedadActualizada}");

                controlMensajes.MostrarMensaje(false, $"Se ha actualizado la propiedad: {propiedadActualizada.LstrLugar}");
            }
        }

        private void CargarPropiedad(int idPropiedad)
        {
            var mensajeError = new MensajeError();
            var propiedad = PropiedadBL.BuscarPropiedad(idPropiedad, ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                Session.Add("Propiedad", propiedad);

                TipoPropiedad.Value = propiedad.LstrTipoPropiedad;
                Ubicacion.Value = propiedad.LstrLugar;
            }
            else
            {
                controlMensajes.MostrarMensaje(true, "Error al cargar la Propiedad");
            }
        }
    }
}