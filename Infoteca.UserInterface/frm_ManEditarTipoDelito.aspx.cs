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
    public partial class frm_ManEditarTipoFuente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    var mensajeError = new MensajeError();

                    var tipoDelito = TipoDelitoBL.BuscarTipoDelito(int.Parse(Request["id"]), ref mensajeError);

                    Session.Add("tipoDelito", tipoDelito);

                    inputNombre.Value = tipoDelito.LstrNombre;
                }
            }
        }

        protected void EditarTipoDelito(object sender, EventArgs e)
        {
            var tipoDelito = (TipoDelitoUT)Session["tipoDelito"];

            tipoDelito.LstrNombre = inputNombre.Value;

            var mensajeError = new MensajeError();

            var tipoDelitoActualizado = TipoDelitoBL.EditarTipoDelito(tipoDelito, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al editar el Tipo Delito");

                controlMensajes.MostrarMensaje(true, "Error al Editar el Tipo Delito");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"TipoDelito Editado: {tipoDelitoActualizado.ToString()}");

                controlMensajes.MostrarMensaje(false, $"Se ha Editado el tipo de delito {tipoDelitoActualizado.LstrNombre}");
            }
        }
    }
}