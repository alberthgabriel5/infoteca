using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infoteca.UserInterface.controles
{
    public partial class MostrarMensajes : UserControl
    {
        public bool Visible
        {
            get => mensajeError.Visible;
            set
            {
                mensajeError.Visible = value;
                mensajeExito.Visible = value;
            } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mensajeError.Visible = false;
                mensajeExito.Visible = false;
            }
        }

        public void MostrarMensaje(bool esMensajeError, string mensaje)
        {
            mensajeError.Visible = false;
            mensajeExito.Visible = false;

            if (esMensajeError)
            {
                labelError.Text = mensaje;
                mensajeError.Visible = true;

            }
            else
            {
                mensajeExito.Visible = true;
                labelExito.Text = mensaje;
            }
        }
    }
}