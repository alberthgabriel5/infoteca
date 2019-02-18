using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.UserInterface.utils;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using Microsoft.AspNet.Identity;

namespace Infoteca.UserInterface
{
    public partial class frm_ConReporteNoticiasPorTipo : Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvNoticia.AllowPaging = true;
                gvNoticia.PageSize = 20;
        
                gvNoticia.AllowSorting = true;

                ViewState["SortExpression"] = "LintId";
            }
        }

        protected void BuscarPorTipo(object sender, EventArgs e)
        {
            Mensaje.Visible = false;
            BtnGenerarPDF.Visible = false;
            gvNoticia.Visible = false;

            var mensajeError = new MensajeError();
            var noticias = new List<NoticiaUT>();

            //Tipo Delito
            if (FiltroBusqueda.SelectedValue.Equals("1"))
            {
                if (TipoDelitos.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione un Tipo de Delito.");
                    return;
                }

                noticias = NoticiaBL.BuscarNoticiaPorTipoDelito(int.Parse(TipoDelitos.SelectedValue), ref mensajeError);
            }

            //Fuente
            if (FiltroBusqueda.SelectedValue.Equals("2"))
            {
                if (Fuentes.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Fuente.");
                    return;
                }

                noticias = NoticiaBL.BuscarNoticiaPorFuente(int.Parse(Fuentes.SelectedValue), ref mensajeError);
            }

            //Persona
            if (FiltroBusqueda.SelectedValue.Equals("3"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Persona.");
                    return;
                }

                noticias = NoticiaBL.BuscarNoticiaPorPersona(int.Parse(PersonasMLB.SelectedValue), ref mensajeError);
            }

            //Vehiculo
            if (FiltroBusqueda.SelectedValue.Equals("4"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione un Vehiculo.");
                    return;
                }

                noticias = NoticiaBL.BuscarNoticiaPorVehiculo(int.Parse(VehiculoMLB.SelectedValue), ref mensajeError);
            }

            //Persona Juridica
            if (FiltroBusqueda.SelectedValue.Equals("5"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Persona Juridica.");
                    return;
                }

                noticias = NoticiaBL.BuscarNoticiaPorPersonaJuridica(int.Parse(PersonaJuridicaMLB.SelectedValue), ref mensajeError);
            }

            //Propiedad
            if (FiltroBusqueda.SelectedValue.Equals("6"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Propiedad.");
                    return;
                }

                noticias = NoticiaBL.BuscarNoticiaPorPropiedad(int.Parse(PropiedadMLB.SelectedValue), ref mensajeError);
            }

            if (!mensajeError.ExisteError())
            {
                if (noticias.Count > 0)
                {
                    var noticiasGrid = new List<NoticiaGridView>();

                    foreach (var noticiaUt in noticias)
                    {
                        noticiasGrid.Add(NoticiaGridView.GetNoticiaGridView(noticiaUt));
                    }

                    var dsPerson = ToDataSet(noticiasGrid);

                    // Get the DataView from Person DataTable. 
                    var dvPerson = dsPerson.Tables["Table1"].DefaultView;

                    // Set the sort column and sort order. 
                    dvPerson.Sort = ViewState["SortExpression"].ToString();

                    if (Session["PageIndex"] != null)
                    {
                        gvNoticia.PageIndex = (int)Session["PageIndex"];
                    }

                    // Bind the GridView control. 
                    gvNoticia.DataSource = dvPerson;
                    gvNoticia.DataBind();
                    gvNoticia.Visible = true;

                    BtnGenerarPDF.Visible = true;
                }
                else
                {
                    Mensaje.Text = "No se encontraron noticias con los parametros ingresados";
                    Mensaje.Visible = true;
                }
            }
            else
            {
                Mensaje.Text = mensajeError.Mensaje;
                Mensaje.Visible = true;
            }
        }

        protected void GenerarPDF_OnClick(object sender, EventArgs e)
        {
            BtnGenerarPDF.Visible = false;

            var noticias = new List<NoticiaUT>();
            var mensajeError = new MensajeError();
            var titulo = string.Empty;
          
            //Tipo Delito
            if (FiltroBusqueda.SelectedValue.Equals("1"))
            {
                if (TipoDelitos.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione un Tipo de Delito.");
                    return;
                }

                titulo = $"Reporte de noticias por Tipo Delito: {TipoDelitos.SelectedItem.Text}";

                noticias = NoticiaBL.BuscarNoticiaPorTipoDelito(int.Parse(TipoDelitos.SelectedValue), ref mensajeError);
            }

            //Fuente
            if (FiltroBusqueda.SelectedValue.Equals("2"))
            {
                if (Fuentes.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Fuente.");
                    return;
                }

                titulo = $"Reporte de noticias por Fuente: {Fuentes.SelectedItem.Text}";
                noticias = NoticiaBL.BuscarNoticiaPorFuente(int.Parse(Fuentes.SelectedValue), ref mensajeError);
            }

            //Persona
            if (FiltroBusqueda.SelectedValue.Equals("3"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Persona.");
                    return;
                }

                titulo = $"Reporte de noticias por Persona: {PersonasMLB.SelectedItem.Text}";
                noticias = NoticiaBL.BuscarNoticiaPorPersona(int.Parse(PersonasMLB.SelectedValue), ref mensajeError);
            }

            //Vehiculo
            if (FiltroBusqueda.SelectedValue.Equals("4"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione un Vehiculo.");
                    return;
                }

                titulo = $"Reporte de noticias por Vehiculo: {VehiculoMLB.SelectedItem.Text}";
                noticias = NoticiaBL.BuscarNoticiaPorVehiculo(int.Parse(VehiculoMLB.SelectedValue), ref mensajeError);
            }

            //Persona Juridica
            if (FiltroBusqueda.SelectedValue.Equals("5"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Persona Juridica.");
                    return;
                }

                titulo = $"Reporte de noticias por Persona Juridica: {PersonaJuridicaMLB.SelectedItem.Text}";
                noticias = NoticiaBL.BuscarNoticiaPorPersonaJuridica(int.Parse(PersonaJuridicaMLB.SelectedValue), ref mensajeError);
            }

            //Propiedad
            if (FiltroBusqueda.SelectedValue.Equals("6"))
            {
                if (PersonasMLB.SelectedValue.Equals("-1"))
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Propiedad.");
                    return;
                }

                titulo = $"Reporte de noticias por Propiedad: {PropiedadMLB.SelectedItem.Text}";
                noticias = NoticiaBL.BuscarNoticiaPorPropiedad(int.Parse(PropiedadMLB.SelectedValue), ref mensajeError);
            }


            var listaNoticiasGridView = new List<NoticiaGridView>();

                foreach (var noticiaUt in noticias)
                {
                    listaNoticiasGridView.Add(NoticiaGridView.GetNoticiaGridView(noticiaUt));
                }

                var bytes = GenerarPdf.GenerarPdfListaDeNoticiasPorTipo(listaNoticiasGridView, titulo);

                Response.Clear();
                Response.ContentType = "application/pdf";

                var pdfName = "Reporte-Noticias";

                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            
        }

        protected void FiltroBusqueda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DivTipoDelito.Visible = false;
            DivFuente.Visible = false;
            DivPersona.Visible = false;
            DivVehiculo.Visible = false;
            DivPersonaJuridica.Visible = false;
            DivPropiedad.Visible = false;

            //Tipo Delito
            if (FiltroBusqueda.SelectedValue.Equals("1"))
            {
                DivTipoDelito.Visible = true;
                BtnBuscar.Visible = true;
                CargarTiposDelito();
            }

            //Fuente
            if (FiltroBusqueda.SelectedValue.Equals("2"))
            {
                DivFuente.Visible = true;
                BtnBuscar.Visible = true;
                CargarFuentes();
            }

            //Persona
            if (FiltroBusqueda.SelectedValue.Equals("3"))
            {
                DivPersona.Visible = true;
                BtnBuscar.Visible = true;
                CargarPersonas();
            }

            //Vehiculo
            if (FiltroBusqueda.SelectedValue.Equals("4"))
            {
                DivVehiculo.Visible = true;
                BtnBuscar.Visible = true;
                CargarVehiculos();
            }

            //Persona Juridica
            if (FiltroBusqueda.SelectedValue.Equals("5"))
            {
                DivPersonaJuridica.Visible = true;
                BtnBuscar.Visible = true;
                CargarPersonaJuridicas();
            }

            //Propiedad
            if (FiltroBusqueda.SelectedValue.Equals("6"))
            {
                DivPropiedad.Visible = true;
                BtnBuscar.Visible = true;
                CargarPropiedades();
            }
        }

        #endregion

        #region Eventos Grid

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
            //BindGridView();
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
            //BindGridView();
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

        #endregion

        #region Metodos Privados
        
        private void CargarTiposDelito()
        {
            var mensajeError = new MensajeError();

            var tiposDelito = TipoDelitoBL.BuscarTodosTipoDelito(ref mensajeError);

            if (mensajeError.ExisteError())
            {
                controlMensajes.MostrarMensaje(true, "Error Cargando los tipos de delito");
            }
            else
            {
                foreach (var tipoDelito in tiposDelito)
                {
                    TipoDelitos.Items.Add(new ListItem(tipoDelito.LstrNombre, $"{tipoDelito.LintID}"));
                }
            }
        }

        private void CargarFuentes()
        {
            var mensajeError = new MensajeError();

            var fuenteList = FuenteBL.BuscarTodosFuente(ref mensajeError);

            if (mensajeError.ExisteError())
            {
                controlMensajes.MostrarMensaje(true, "Error Cargando las Fuentes");
            }
            else
            {
                foreach (var fuente in fuenteList)
                {
                    Fuentes.Items.Add(new ListItem(fuente.LstrNombreFuente, $"{fuente.LintID}"));
                }
            }
        }

        private void CargarPersonas()
        {
            var mensajeError = new MensajeError();

            var personas = PersonaBL.BuscarTodosPersona(ref mensajeError);

            personas = personas.OrderBy(s => s.LstrNombre).ToList();

            if (!mensajeError.ExisteError())
            {
                foreach (var persona in personas)
                {
                    var alias = string.IsNullOrEmpty(persona.LstrAlias) ? "" : $"({persona.LstrAlias})";
                    var item = new ListItem()
                    {
                        Value = persona.LintID.ToString(),
                        Text = $"{persona.LstrNombre} {persona.LstrApelido} {alias}"
                    };

                    PersonasMLB.Items.Add(item);
                }
            }
        }

        private void CargarVehiculos()
        {
            var mensajeError = new MensajeError();

            var vehiculos = VehiculoBL.BuscarTodosVehiculo(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var vehiculo in vehiculos)
                {
                    var item = new ListItem()
                    {
                        Value = vehiculo.LintID.ToString(),
                        Text = $"{vehiculo.LstrPlaca} {vehiculo.LstrMarca} {vehiculo.LstrModelo}"
                    };

                    VehiculoMLB.Items.Add(item);
                }
            }
        }

        private void CargarPersonaJuridicas()
        {
            var mensajeError = new MensajeError();

            var personaJuridicas = PersonaJuridicaBL.BuscarTodosPersonaJuridica(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var personaJuridica in personaJuridicas)
                {
                    var item = new ListItem()
                    {
                        Value = personaJuridica.LintID.ToString(),
                        Text = $"{personaJuridica.LstrCedulaJuridica} {personaJuridica.LstrNombreJuridico}"
                    };

                    PersonaJuridicaMLB.Items.Add(item);
                }
            }
        }

        private void CargarPropiedades()
        {
            var mensajeError = new MensajeError();

            var propiedades = PropiedadBL.BuscarTodosPropiedad(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var propiedad in propiedades)
                {
                    var item = new ListItem()
                    {
                        Value = propiedad.LintID.ToString(),
                        Text = $"{propiedad.LstrLugar} {propiedad.LstrTipoPropiedad}"
                    };

                    PropiedadMLB.Items.Add(item);
                }
            }
        }

        #endregion
    }
}