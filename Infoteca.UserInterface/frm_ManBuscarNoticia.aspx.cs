using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManBuscarNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvNoticia.AllowPaging = true;
                gvNoticia.PageSize = 20;
                gvNoticia.AllowSorting = true;
                ViewState["SortExpression"] = "LintId";
                
                BindGridView();
            }
        }

        protected void gvNoticia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.BorderStyle = BorderStyle.None;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Make sure the current GridViewRow is either  
                // in the normal state or an alternate row. 
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    DataRowView dev = (DataRowView)e.Row.DataItem;
                    object[] ob = dev.Row.ItemArray;

                    ((LinkButton)e.Row.Cells[8].Controls[1]).Attributes["href"] = "/frm_ConReporteNoticia.aspx?idNoticia=" + ob[0];
                }
            }
        }

        protected void gvNoticia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            gvNoticia.PageIndex = e.NewPageIndex;

            Session.Add("PageIndex", e.NewPageIndex);

            // Rebind the GridView control to  
            // show data in the new page. 
            BindGridView();
        }

        protected void gvNoticia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var idNoticia = gvNoticia.Rows[e.NewEditIndex].Cells[0].Text;

            if (idNoticia != null)
            {
                Response.Redirect($"/frm_ManEditarNoticia.aspx?idNoticia={idNoticia}", false);
            }
        }

        protected void gvNoticia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var idNoticia = gvNoticia.Rows[e.RowIndex].Cells[0].Text;

            Session.Add("idNoticia", idNoticia);

            var mensajeError = new MensajeError();

            var noticia = NoticiaBL.BuscarNoticia(int.Parse(idNoticia), ref mensajeError);

            borrarMensaje.Text = $"Desea borrar la noticia: #{noticia.LintId}?";

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);

        }

        protected void gvNoticia_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] strSortExpression = ViewState["SortExpression"].ToString().Split(' ');


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
            gvNoticia.Visible = false;
            Coincidencias.Visible = false;

            var mensajeError = new MensajeError();
            var noticias = NoticiaBL.BuscarNoticiasActivas(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                if (noticias.Count > 0)
                {
                    Coincidencias.Text = $"Cantidad de noticias: {noticias.Count}";

                    var noticiasGridviewList = new List<NoticiaGridView>();

                    foreach (var noticia in noticias)
                    {
                        noticiasGridviewList.Add(NoticiaGridView.GetNoticiaGridView(noticia));
                    }

                    var dsNoticia = ToDataSet(noticiasGridviewList);

                    // Get the DataView from Person DataTable. 
                    var dvNoticia = dsNoticia.Tables["Table1"].DefaultView;

                    // Set the sort column and sort order. 
                    dvNoticia.Sort = ViewState["SortExpression"].ToString();

                    if (Session["PageIndex"] != null)
                    {
                        gvNoticia.PageIndex = (int)Session["PageIndex"];
                    }

                    // Bind the GridView control. 
                    gvNoticia.DataSource = dvNoticia;
                    gvNoticia.DataBind();
                    gvNoticia.Visible = true;
                    Coincidencias.Visible = true;
                }
            }
            else
            {
                Mensaje.Text = mensajeError.Mensaje;
                Mensaje.Visible = true;
            }
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

        protected void BorrarNoticia(object sender, EventArgs e)
        {
            var idNoticia = Session["idNoticia"] != null ? Session["idNoticia"].ToString() : "0";

            if (!idNoticia.Equals("0"))
            {
                var mensajeError = new MensajeError();

                if (NoticiaBL.BorrarNoticia(int.Parse(idNoticia), ref mensajeError))
                {
                    controlMensajes.MostrarMensaje(false, "Noticia eliminada");
                }
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "closeModal();", true);
            BindGridView();
        }
    }
}