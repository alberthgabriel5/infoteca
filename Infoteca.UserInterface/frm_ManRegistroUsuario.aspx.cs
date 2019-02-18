using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using Infoteca.Utilitarios.Utiles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Infoteca.UserInterface
{
    public partial class frm_ManRegistroUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Nombre.Value = string.Empty;
                Apellido.Value = string.Empty;
                Usuario.Value = string.Empty;
                Rol.Value = Rol.Items[0].Value;
                Password.Text = string.Empty;
                ConfirmPassword.Text = string.Empty;
            }
        }

        protected void RegistrarUsuario(object sender, EventArgs e)
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;

            var context = new ApplicationDbContext(connectionString);
            var userStore = new UserStore<IdentityUser>(context);

            var realizarLogin = context.Users.ToList().Count <= 0;

            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser()
            {
                UserName = Usuario.Value
            };

            var result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
          
                if (!roleManager.RoleExists(Rol.Value))
                {
                    roleManager.Create(new IdentityRole(Rol.Value));
                }

                if (manager.AddToRole(userIdentity.GetUserId(), Rol.Value).Succeeded)
                {
                    EscribirLog.LogMensajeDebug($"Usuario Creado: {user.UserName}");

                    if (realizarLogin)
                    {
                        user = manager.Find(user.UserName, Password.Text);

                        if (user != null)
                        {
                            authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                            userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                            Session.Add("UsuarioActual", user);
                            Response.Redirect("~/frm_RepInicio.aspx");
                        }
                    }

                    controlMensajes.MostrarMensaje(false, $"Usuario creado: {Usuario.Value}");

                    Nombre.Value = string.Empty;
                    Apellido.Value = string.Empty;
                    Usuario.Value = string.Empty;
                    Rol.Value = Rol.Items[0].Value;
                    Password.Text = string.Empty;
                    ConfirmPassword.Text = string.Empty;
                }
            }
            else
            {
                controlMensajes.MostrarMensaje(true, result.Errors.FirstOrDefault());
            }
        }

    }
}