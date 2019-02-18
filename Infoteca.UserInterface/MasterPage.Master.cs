using System;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infoteca.UserInterface
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var usuario = HttpContext.Current.User.Identity;

                if (usuario.IsAuthenticated)
                {
                    StatusText.Text = $"Bienvenido {usuario.GetUserName()}";
                    LoginStatus.Visible = true;
                    LogoutButton.Visible = true;

                    var usr = (IdentityUser)Session["UsuarioActual"];

                    if (usr != null)
                    {
                        if (usr.Roles.ToArray()[0].Role.Name.Equals("Administrador"))
                        {
                            LiInicio.Visible = true;
                            LiNoticia.Visible = true;
                            LiBusqueda.Visible = true;
                            LiCatalogo.Visible = true;
                            LiReporte.Visible = true;
                            LiAdmin.Visible = true;
                        }
                        else if (usr.Roles.ToArray()[0].Role.Name.Equals("Oficina Prensa"))
                        {
                            LiInicio.Visible = true;
                            LiNoticia.Visible = true;
                            LiBusqueda.Visible = true;
                            LiCatalogo.Visible = true;
                            LiReporte.Visible = true;
                            LiAdmin.Visible = false;
                        }
                        else if (usr.Roles.ToArray()[0].Role.Name.Equals("Agente Policial"))
                        {
                            LiInicio.Visible = true;
                            LiNoticia.Visible = false;
                            LiBusqueda.Visible = true;
                            LiCatalogo.Visible = false;
                            LiReporte.Visible = true;
                            LiAdmin.Visible = false;
                        }
                    }
                }
                else
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;
                    var context = new ApplicationDbContext(connectionString);

                    if (context.Users.ToList().Count > 0)
                    {
                        LiAdmin.Visible = true;
                        Response.Redirect("~/frm_Login.aspx");
                    }
                }
            }
        }

        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/frm_Login.aspx");
        }
    }
}