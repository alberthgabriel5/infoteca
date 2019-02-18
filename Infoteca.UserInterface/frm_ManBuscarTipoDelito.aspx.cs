using Infoteca.BizLayer;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infoteca.UserInterface
{
    public partial class frm_ManBuscarTipoDelito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposDelito();
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["id"]) && string.IsNullOrEmpty(borrarMensaje.Text))
                {
                    Session.Add("idTiposDelito", Request["id"]);

                    var mensajeError = new MensajeError();

                    var tipoDelito = TipoDelitoBL.BuscarTipoDelito(int.Parse(Request["id"]), ref mensajeError);

                    borrarMensaje.Text = $"Desea borrar el tipo delito {tipoDelito.LstrNombre}?";

                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
                }
            }
        }

        private void CargarTiposDelito()
        {
            var mensajeError = new MensajeError();

            var listaTiposDelito = TipoDelitoBL.BuscarTodosTipoDelito(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var tipoDelito in listaTiposDelito)
                {
                    var row = new TableRow();

                    var cell1 = new TableCell();
                    var cell2 = new TableCell();
                    var cell3 = new TableCell();

                    var cell4 = new TableCell();
                    var cell5 = new TableCell();
                 

                    cell1.Text = tipoDelito.LintID.ToString();
                    cell2.Text = tipoDelito.LstrNombre;
                    cell3.Text = tipoDelito.FdtiFechaCreaccion.ToString("G");

                    var newButton1 = new Button
                    {
                        Text = "Editar",
                        CssClass = "btn btn-primary",
                        PostBackUrl = $"/frm_ManEditarTipoDelito.aspx?id={tipoDelito.LintID}"
                    };
                    cell4.Controls.Add(newButton1);

                    var newButton2 = new Button
                    {
                        Text = "Borrar",
                        CssClass = "btn btn-primary",
                        PostBackUrl = $"/frm_ManBuscarTipoDelito.aspx?id={tipoDelito.LintID}"
                    };
                    cell5.Controls.Add(newButton2);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
          

                    tablaTiposDelito.Rows.Add(row);
                }
            }
        }

        protected void BorrarTipoDelito(object sender, EventArgs e)
        {
            var idTiposDelito = Session["idTiposDelito"] != null ? Session["idTiposDelito"].ToString(): "0";

            if (!idTiposDelito.Equals("0"))
            {
                var mensajeError = new MensajeError();

                if(TipoDelitoBL.BorrarTipoDelito(int.Parse(idTiposDelito), ref mensajeError)) 
                {
                    controlMensajes.MostrarMensaje(false, "Tipo delito eliminado");
                } 
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "closeModal();", true);
            CargarTiposDelito();
        }
    }
}