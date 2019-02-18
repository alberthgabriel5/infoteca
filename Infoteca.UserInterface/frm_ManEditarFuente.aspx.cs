using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManEditarFuente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idFuente = int.Parse(Request["idFuente"] ?? "0");

                CargarFuente(idFuente);
            }
        }

        protected void ActualizarFuente(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty($"{NombreFuente.Value}"))
            {
                controlMensajes.MostrarMensaje(true, "Ingrese un nombre para la fuente!");
                return;
            }

            if (TipoFuentes.SelectedValue.Equals("-1"))
            {
                controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione un Tipo de Fuente Valido.");
                return;
            }

            var fuente = (FuenteUT)Session["Fuente"];

            var mensajeError = new MensajeError();

            fuente.LstrNombreFuente = NombreFuente.Value;
            fuente.LobjTipoFuente = TipoFuenteBL.BuscarTipoFuente(int.Parse(TipoFuentes.SelectedValue), ref mensajeError);
            fuente.LstrTitulo = Titulo.Value;
            fuente.LstrSubTitulo = Subtitulo.Value;
            fuente.LbytActivo = true;
   

            var fuenteActualizada = FuenteBL.EditarFuente(fuente, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                EscribirLog.LogMensajeDebug("Error al actualizar la Fuente");

                controlMensajes.MostrarMensaje(true, "Error al actualizar la Fuente");
            }
            else
            {
                EscribirLog.LogMensajeDebug($"Fuente actualizada: {fuenteActualizada}");

                controlMensajes.MostrarMensaje(false, $"Se ha actualizado la fuente: {fuenteActualizada.LstrNombreFuente}");
            }
        }

        private void CargarFuente(int idFuente)
        {
            var mensajeError = new MensajeError();
            var fuente = FuenteBL.BuscarFuente(idFuente, ref mensajeError);

            CargarTiposFuente(fuente.LobjTipoFuente.LintID);

            if (!mensajeError.ExisteError())
            {
                Session.Add("Fuente", fuente);
              
                NombreFuente.Value = fuente.LstrNombreFuente;
                Subtitulo.Value = fuente.LstrSubTitulo;
                Titulo.Value = fuente.LstrTitulo;
            }
            else
            {
                controlMensajes.MostrarMensaje(true, "Error al cargar la Fuente");
            }
        }

        private void CargarTiposFuente(int idTipoFuente)
        {
            var mensajeError = new MensajeError();

            var tiposFuente = TipoFuenteBL.BuscarTodosTipoFuente(ref mensajeError);

            if (mensajeError.ExisteError())
            {
                controlMensajes.MostrarMensaje(true, "Error Cargando los tipos de Fuente");
            }
            else
            {
                foreach (var tipoFuente in tiposFuente)
                {
                    TipoFuentes.Items.Add(new ListItem(tipoFuente.LstrNombre, $"{tipoFuente.LintID}"));
                }

                TipoFuentes.SelectedValue = $"{idTipoFuente}";
            }
        }
    }
}