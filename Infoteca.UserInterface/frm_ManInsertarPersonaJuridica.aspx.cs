using System;
using System.Web.UI;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarPersonaJuridica : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarPersonaJuridica(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{IdentificacionJU.Value}{Fantasia.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese una Identificación o un nombre de Fantasia!");
                return;
            }

            var personaJuridica = new PersonaJuridicaUT
            {
                LstrCedulaJuridica = IdentificacionJU.Value,
                LstrNombreJuridico = NombreJU.Value,
                LstrNombrePublico = Fantasia.Value,
                LbytActivo = 1
            };

            var mensajeError = new MensajeError();

            var personaJuridicaCreado = PersonaJuridicaBL.InsertarPersonaJuridica(personaJuridica, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al crear la PersonaJuridica");

                controlMensajes.MostrarMensaje(true, "Error al crear la PersonaJuridica");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"PersonaJuridica Creado: {personaJuridicaCreado}");

                controlMensajes.MostrarMensaje(false, $"Se ha creado la personaJuridica: {personaJuridicaCreado.LstrNombrePublico}");
            }
            
            IdentificacionJU.Value = string.Empty;
            NombreJU.Value = string.Empty;
            Fantasia.Value = string.Empty;
        }
    }
}