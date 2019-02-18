using Infoteca.BizLayer;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infoteca.UserInterface
{
    public partial class frm_ManBuscarTipoFuente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposFuente();
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["id"]) && string.IsNullOrEmpty(borrarMensaje.Text))
                {
                    Session.Add("idTiposFuente", Request["id"]);

                    var mensajeError = new MensajeError();

                    var tipoFuente = TipoFuenteBL.BuscarTipoFuente(int.Parse(Request["id"]), ref mensajeError);

                    borrarMensaje.Text = $"Desea borrar el tipo fuente {tipoFuente.LstrNombre}?";

                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
                }
            }
        }

        private void CargarTiposFuente()
        {
            var mensajeError = new MensajeError();

            var listaTiposFuente = TipoFuenteBL.BuscarTodosTipoFuente(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var tipoFuente in listaTiposFuente)
                {
                    var row = new TableRow();

                    var cell1 = new TableCell();
                    var cell2 = new TableCell();
                    var cell3 = new TableCell();

                    var cell4 = new TableCell();
                    var cell5 = new TableCell();
                 

                    cell1.Text = tipoFuente.LintID.ToString();
                    cell2.Text = tipoFuente.LstrNombre;
                    cell3.Text = tipoFuente.FdtiFechaCreaccion.ToString("G");

                    var newButton1 = new Button
                    {
                        Text = "Editar",
                        CssClass = "btn btn-primary",
                        PostBackUrl = $"/frm_ManEditarTipoFuente.aspx?id={tipoFuente.LintID}"
                    };
                    cell4.Controls.Add(newButton1);

                    var newButton2 = new Button
                    {
                        Text = "Borrar",
                        CssClass = "btn btn-primary",
                        PostBackUrl = $"/frm_ManBuscarTipoFuente.aspx?id={tipoFuente.LintID}"
                    };
                    cell5.Controls.Add(newButton2);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
          

                    tablaTiposFuente.Rows.Add(row);
                }
            }
        }

        protected void BorrarTipoFuente(object sender, EventArgs e)
        {
            var idTiposFuente = Session["idTiposFuente"] != null ? Session["idTiposFuente"].ToString(): "0";

            if (!idTiposFuente.Equals("0"))
            {
                var mensajeError = new MensajeError();

                if(TipoFuenteBL.BorrarTipoFuente(int.Parse(idTiposFuente), ref mensajeError)) 
                {
                    controlMensajes.MostrarMensaje(false, "Tipo fuente eliminado");
                } 
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "closeModal();", true);
            CargarTiposFuente();
        }
    }
}