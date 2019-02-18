using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManEditarPersonaJuridica : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idPersonaJuridica = int.Parse(Request["idPersonaJuridica"] ?? "0");

                CargarPersonaJuridica(idPersonaJuridica);
            }
        }

        protected void ActualizarPersonaJuridica(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{IdentificacionJU.Value}{Fantasia.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese un nombre o un alias!");
                return;
            }

            var personaJuridica = (PersonaJuridicaUT)Session["PersonaJuridica"];

            personaJuridica.LstrCedulaJuridica = IdentificacionJU.Value;
            personaJuridica.LstrNombreJuridico = NombreJU.Value;
            personaJuridica.LstrNombrePublico = Fantasia.Value;
            personaJuridica.LbytActivo = 1;

            var mensajeError = new MensajeError();

            var personaJuridicaActualizada = PersonaJuridicaBL.EditarPersonaJuridica(personaJuridica, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al actualizar la Persona Juridica");

                controlMensajes.MostrarMensaje(true, "Error al actualizar la Persona Juridica");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"PersonaJuridica actualizada: {personaJuridicaActualizada}");

                controlMensajes.MostrarMensaje(false, $"Se ha actualizado la persona Juridica: {personaJuridicaActualizada.LstrNombrePublico}");
            }
        }

        private void CargarPersonaJuridica(int idPersonaJuridica)
        {
            var mensajeError = new MensajeError();
            var personaJuridica = PersonaJuridicaBL.BuscarPersonaJuridica(idPersonaJuridica, ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                Session.Add("PersonaJuridica", personaJuridica);
                
                IdentificacionJU.Value = personaJuridica.LstrCedulaJuridica;
                NombreJU.Value = personaJuridica.LstrNombreJuridico;
                Fantasia.Value = personaJuridica.LstrNombrePublico;
            }
            else
            {
                controlMensajes.MostrarMensaje(true, "Error al cargar la Persona Juridica");
            }
        }
    }
}