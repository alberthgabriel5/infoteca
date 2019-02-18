using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using Microsoft.AspNet.Identity;

namespace Infoteca.UserInterface
{
    public partial class frm_ConBusquedaPorRango : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvNoticia.AllowPaging = true;
                gvNoticia.PageSize = 20;
                gvNoticia.AllowSorting = true;
                ViewState["SortExpression"] = "LintId";

                if (Session["FechaDesde"] != null && Session["FechaHasta"] != null)
                {
                    FechaDesde.Value = Session["FechaDesde"].ToString();
                    FechaHasta.Value = Session["FechaHasta"].ToString();

                    Session["FechaDesde"] = null;
                    Session["FechaHasta"] = null;

                    BindGridView();
                }
            }
        }

        protected void BuscarPorFechas(object sender, EventArgs e)
        {
            Mensaje.Visible = false;

            var mensajeError = new MensajeError();

            if (!string.IsNullOrEmpty(FechaDesde.Value) && !string.IsNullOrEmpty(FechaHasta.Value))
            {

                var FechaDesdeDT = DateTime.ParseExact(FechaDesde.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var FechaHastaDT = DateTime.ParseExact(FechaHasta.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (FechaHastaDT < FechaDesdeDT)
                {
                    Mensaje.Text = "La fecha inicial no puede ser mayor que la fecha final";
                    Mensaje.Visible = true;

                    return;
                }

                BindGridView();
            }
            else
            {
                Mensaje.Text = "Por Favor, Ingrese un Rango de fecha valido";
                Mensaje.Visible = true;
            }
        }
                
        protected void gvNoticia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.BorderStyle = BorderStyle.None;
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
                Session.Add("FechaDesde", FechaDesde.Value);
                Session.Add("FechaHasta", FechaHasta.Value);
                Response.Redirect($"/frm_ManVerNoticia.aspx?idNoticia={idNoticia}&PaginaActual=Rango", false);
            }
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

            var FechaDesdeDT = DateTime.ParseExact(FechaDesde.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var FechaHastaDT = DateTime.ParseExact(FechaHasta.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var mensajeError = new MensajeError();

            var usuario = HttpContext.Current.User.Identity;

            var noticias = NoticiaBL.BuscarPorFechaNoticia(FechaDesdeDT, FechaHastaDT, usuario.GetUserName(), ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                if (noticias.Count > 0)
                {
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
                }
                else
                {
                    Mensaje.Text = "No se encontraron noticias con los criterios ingresados";
                    Mensaje.Visible = true;
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
    }
}