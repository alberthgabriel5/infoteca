using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarFuente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposFuente();
            }
        }

        protected void RegistrarFuente(object sender, EventArgs e)
        {
            var mensajeError = new MensajeError();

            if (!string.IsNullOrEmpty(NombreFuente.Value))
            {
                if (!TipoFuentes.SelectedValue.Equals("-1"))
                {
                    var tipoFuente = TipoFuenteBL.BuscarTipoFuente(int.Parse(TipoFuentes.SelectedValue), ref mensajeError);

                    var fuente = new FuenteUT
                    {
                        LstrNombreFuente = NombreFuente.Value,
                        LstrTitulo = Titulo.Value,
                        LstrSubTitulo = Subtitulo.Value,
                        LbytActivo = true,
                        LobjTipoFuente = tipoFuente
                    };

                    var fuenteCreada = FuenteBL.InsertarFuente(fuente, ref mensajeError);

                    if (mensajeError.ExisteError())
                    {
                        controlMensajes.MostrarMensaje(true, "Error creando la fuente.");
                    }
                    else
                    {
                        controlMensajes.MostrarMensaje(false, $"Fuente {fuenteCreada.LstrNombreFuente} creada exitosamente.");
                    }
                }
                else
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione un Tipo de Fuente Valido.");
                    return;
                }
            }
            else
            {
                controlMensajes.MostrarMensaje(true, "Por Favor, Ingrese un Nombre de Fuente Valido.");
                return;
            }

            TipoFuentes.SelectedIndex = 0;
            NombreFuente.Value = string.Empty;
            Titulo.Value = string.Empty;
            Subtitulo.Value = string.Empty;
        }

        private void CargarTiposFuente()
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
            }
        }
    }
}