using Infoteca.BizLayer;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infoteca.UserInterface
{
    public partial class frm_ManBuscarPersonaJuridica : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvPerson.AllowPaging = true;
                gvPerson.PageSize = 20;

                // Enable the GridView sorting option. 
                gvPerson.AllowSorting = true;

                // Initialize the sorting expression. 
                ViewState["SortExpression"] = "LintID";

                // Populate the GridView. 
                BindGridView();
            }
        }
        
        protected void BorrarPersonaJuridica(object sender, EventArgs e)
        {
            var idTiposFuente = Session["idPersonaJuridica"] != null ? Session["idPersonaJuridica"].ToString(): "0";

            if (!idTiposFuente.Equals("0"))
            {
                var mensajeError = new MensajeError();

                if(PersonaJuridicaBL.BorrarPersonaJuridica(int.Parse(idTiposFuente), ref mensajeError)) 
                {
                    controlMensajes.MostrarMensaje(false, "Persona Juridica eliminada");
                } 
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "closeModal();", true);
            BindGridView();
        }

        protected void gvPerson_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.BorderStyle = BorderStyle.None;
            }
        }

        protected void gvPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            gvPerson.PageIndex = e.NewPageIndex;

            Session.Add("PageIndex", e.NewPageIndex);

            // Rebind the GridView control to  
            // show data in the new page. 
            BindGridView();
        }

        protected void gvPerson_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var idPersonaJuridica = gvPerson.Rows[e.NewEditIndex].Cells[0].Text;

            if (idPersonaJuridica != null)
            {
                Response.Redirect("/frm_ManEditarPersonaJuridica.aspx?idPersonaJuridica=" + idPersonaJuridica, false);
            }
        }

        protected void gvPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var idPersonaJuridica = gvPerson.Rows[e.RowIndex].Cells[0].Text;
            
            Session.Add("idPersonaJuridica", idPersonaJuridica);

            var mensajeError = new MensajeError();

            var personaJuridica = PersonaJuridicaBL.BuscarPersonaJuridica(int.Parse(idPersonaJuridica), ref mensajeError);
            var apariciones = PersonaJuridicaBL.BuscarCantidadApariciones(int.Parse(idPersonaJuridica), ref mensajeError);

            borrarMensaje.Text = $"Desea borrar la personaJuridica: {personaJuridica.LstrNombrePublico}? Registrada en {apariciones} Noticia(s).";

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
            
        }

        protected void gvPerson_Sorting(object sender, GridViewSortEventArgs e)
        {
            var strSortExpression = ViewState["SortExpression"].ToString().Split(' ');
            
            // If the sorting column is the same as the previous one,  
            // then change the sort order. 
            if (strSortExpression[0] == e.SortExpression)
            {
                if (strSortExpression[1] == "ASC")
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
                }
            }
            // If sorting column is another column,   
            // then specify the sort order to "Ascending". 
            else
            {
                ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
            }


            // Rebind the GridView control to show sorted data. 
            BindGridView();
        }

        private void BindGridView()
        {
            var mensajeError = new MensajeError();

            var listaTiposFuente = PersonaJuridicaBL.BuscarTodosPersonaJuridica(ref mensajeError);

            var dsPerson = ToDataSet(listaTiposFuente);

            // Get the DataView from Person DataTable. 
            var dvPerson = dsPerson.Tables["Table1"].DefaultView;

            // Set the sort column and sort order. 
            dvPerson.Sort = ViewState["SortExpression"].ToString();

            if (Session["PageIndex"] != null)
            {
                gvPerson.PageIndex = (int)Session["PageIndex"];
            }

            // Bind the GridView control. 
            gvPerson.DataSource = dvPerson;
            gvPerson.DataBind();
        }

        public static DataSet ToDataSet<T>(IList<T> list)
        {
            var elementType = typeof(T);
            var ds = new DataSet();
            var t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                var colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, colType);
            }

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                var row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }
    }
}