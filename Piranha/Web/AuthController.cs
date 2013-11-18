using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Piranha.Models;

namespace Piranha.Web
{
	/// <summary>
	/// Controller handling login/logout functionality.
	/// </summary>
    public class AuthController : Controller
    {
		/// <summary>
		/// Logs in the current user.
		/// </summary>
		public ActionResult Login() {
			string login  = Request["login"] ;
			string passwd = Request["password"] ;
			string returl = Request["returnurl"] ;
			string failurl = Request["failureurl"] ;
			bool persist = Request["remeberme"] == "1" ;

			if (!Piranha.Application.Current.SecurityManager.SignIn(login, passwd, persist) && !String.IsNullOrEmpty(failurl))
				return Redirect(failurl) ;

			if (!String.IsNullOrEmpty(returl))
				return Redirect(returl) ;
			return Redirect("~/") ;
		}

		/// <summary>
		/// Logs out the current user.
		/// </summary>
		public ActionResult Logout() {
			string returl = Request["returnurl"] ;

			Piranha.Application.Current.SecurityManager.SignOut() ;
			Session.Clear() ;

			if (!String.IsNullOrEmpty(returl))
				return Redirect(returl) ;
			return Redirect("~/") ;
		}

		public ActionResult NewPassword() {
            /*
             * TODO: Security has to be rewritten
             * 
			string login = Request["login"];
			string returl = Request["returnurl"];
			string failurl = Request["failureurl"];

			var userexists = false ;
			using (var db = new DataContext()) {
				userexists = db.Users.Where(u => u.Login == login).Count() > 0 ;
			}

			if (userexists) {
				if (WebPages.Hooks.Mail.SendPassword != null) {
					using (var db = new DataContext()) {
						var user = db.Users.Where(u => u.Login == login).Single() ;
						user.GenerateAndSendPassword(db) ;

						if (!String.IsNullOrEmpty(returl))
							return Redirect(returl);
						return Redirect("~/");
					}
				}
			}
			if (!String.IsNullOrEmpty(failurl))
				return Redirect(failurl);
             */
			return Redirect("~/");
		} 
    }
}
