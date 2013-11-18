using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

public class ApplicationUser : IdentityUser {}
public class ApplicationRole : IdentityRole {}
public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationContext() : base("piranha") {}
}

[assembly: OwinStartupAttribute(typeof(Startup))]
public partial class Startup
{
	public void Configuration(IAppBuilder app) {
		// Enable the application to use a cookie to store information for the signed in user
		app.UseCookieAuthentication(new CookieAuthenticationOptions {
			AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
			LoginPath = new PathString("/Account/Login")
		}) ;

		Piranha.Application.Current.InitSecurity<ApplicationUser, ApplicationRole, ApplicationContext>() ;
	}
}
