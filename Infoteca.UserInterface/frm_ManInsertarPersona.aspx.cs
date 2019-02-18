using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarPersona : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarPersona(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{inputNombre.Value}{Alias.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese un nombre o un alias!");
                return;
            }

            var persona = new PersonaUT
            {
                LstrTipoIdentificacion = TipoIdentificacion.Value,
                LstrCedula = Identificacion.Value,
                LstrNombre = inputNombre.Value,
                LstrApelido = Apellidos.Value,
                LstrAlias = Alias.Value,
                LbytActivo = 1
            };

            var mensajeError = new MensajeError();

            var personaCreado = PersonaBL.InsertarPersona(persona, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al crear la Persona");

                controlMensajes.MostrarMensaje(true, "Error al crear la Persona");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"Persona Creado: {personaCreado}");

                controlMensajes.MostrarMensaje(false, $"Se ha creado la persona: {personaCreado.LstrNombre}");
            }

            inputNombre.Value = string.Empty;
            TipoIdentificacion.Value = TipoIdentificacion.Items[0].Value;
            Identificacion.Value = string.Empty;
            Apellidos.Value = string.Empty;
            Alias.Value = string.Empty;
        }
    }
}