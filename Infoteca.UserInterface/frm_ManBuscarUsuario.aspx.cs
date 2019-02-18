using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infoteca.UserInterface
{
    public partial class frm_ManBuscarUsuario : Page
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
                ViewState["SortExpression"] = "Id";

                // Populate the GridView. 
                BindGridView();
            }
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

        protected void gvPerson_Sorting(object sender, GridViewSortEventArgs e)
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
        
            else
            {
                ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
            }

            BindGridView();
        }

        private void BindGridView()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;
            var context = new ApplicationDbContext(connectionString);

            var usuarios = context.Users.ToList();

            var listUsuarios = new List<Usuario>();

            foreach (var usuario in usuarios)
            {
                listUsuarios.Add(new Usuario()
                {
                    Id = usuario.Id,
                    Username = usuario.UserName,
                    Rol = usuario.Roles.ToArray()[0].Role.Name
                });
            }

            var dsPerson = ToDataSet(listUsuarios);

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

        protected void gvPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var idUsuario = gvPerson.Rows[e.RowIndex].Cells[0].Text;

            Session.Add("idUsuario", idUsuario);

            var connectionString = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;
            var context = new ApplicationDbContext(connectionString);

            var usuario = context.Users.Find(idUsuario);

            borrarMensaje.Text = $"Desea borrar el usuario: {usuario.UserName}?";

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
        }

        protected void BorrarUsuario(object sender, EventArgs e)
        {
            var idUsuario = Session["idUsuario"] != null ? Session["idUsuario"].ToString() : "0";

            if (!idUsuario.Equals("0"))
            {
                var connectionString = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;
                var context = new ApplicationDbContext(connectionString);

                var usuario = context.Users.Find(idUsuario);

                context.Users.Remove(usuario);

                context.SaveChanges();

                controlMensajes.MostrarMensaje(false, "Usuario eliminado");
                
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "closeModal();", true);
            BindGridView();
        }
    }

    public class Usuario
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Rol { get; set; }
    }
}