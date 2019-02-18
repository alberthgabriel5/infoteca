using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManEditarPersona : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idPersona = int.Parse(Request["idPersona"] ?? "0");

                CargarPersona(idPersona);
            }
        }

        protected void ActualizarPersona(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{inputNombre.Value}{Alias.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese un nombre o un alias!");
                return;
            }

            var persona = (PersonaUT)Session["Persona"];

            persona.LstrTipoIdentificacion = TipoIdentificacion.Value;
            persona.LstrCedula = Identificacion.Value;
            persona.LstrNombre = inputNombre.Value;
            persona.LstrApelido = Apellidos.Value;
            persona.LstrAlias = Alias.Value;
            persona.LbytActivo = 1;

            var mensajeError = new MensajeError();

            var personaActualizada = PersonaBL.EditarPersona(persona, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al actualizar la Persona");

                controlMensajes.MostrarMensaje(true, "Error al actualizar la Persona");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"Persona actualizada: {personaActualizada}");

                controlMensajes.MostrarMensaje(false, $"Se ha actualizado la persona: {personaActualizada.LstrNombre}");
            }
        }

        private void CargarPersona(int idPersona)
        {
            var mensajeError = new MensajeError();
            var persona = PersonaBL.BuscarPersona(idPersona, ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                Session.Add("Persona", persona);

                TipoIdentificacion.Value = persona.LstrTipoIdentificacion;
                Identificacion.Value = persona.LstrCedula;
                inputNombre.Value = persona.LstrNombre;
                Apellidos.Value = persona.LstrApelido;
                Alias.Value = persona.LstrAlias;
            }
            else
            {
                controlMensajes.MostrarMensaje(true, "Error al cargar la Persona");
            }
        }
    }
}