using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Infoteca.UserInterface
{
    public partial class frm_Login : Page
    {
        protected void Page_Load(object sender, EventArgs e){
            
            var connectionString = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;

            var context = new ApplicationDbContext(connectionString);

            if (context.Users.ToList().Count <= 0)
            {
                Response.Redirect("~/frm_ManRegistroUsuario.aspx");
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;

            var context = new ApplicationDbContext(connectionString);

            var userStore = new UserStore<IdentityUser>(context);
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(UserName.Text, Password.Text);

            Session.Add("UsuarioActual", user);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect("~/frm_RepInicio.aspx");
            }
            else
            {
                lblMessage.Text = "Usuario o contraseña invalidos.";
                dvMessage.Visible = true;
            }
        }        
    }
}