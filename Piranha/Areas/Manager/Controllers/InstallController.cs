using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Piranha.Data;
using Piranha.Data.Updates;
using Piranha.Models;

namespace Piranha.Areas.Manager.Controllers
{
	public class InstallModel 
	{
		[Required(ErrorMessage="Du måste välja ett användarnamn.")]
		public string UserLogin { get ; set ; }

		[Required(ErrorMessage="Du måste ange en e-post adress.")]
		public string UserEmail { get ; set ; }

		[Required(ErrorMessage="Du måste ange ett lösenord")]
		public string Password { get ; set ; }

		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage="Lösenorden matchar inte.")]
		public string PasswordConfirm { get ; set ; }

		public string InstallType { get ; set ; }
	}

	/// <summary>
	/// Login controller for the manager interface.
	/// </summary>
    public class InstallController : Controller
    {
		/// <summary>
		/// Default action
		/// </summary>
        public ActionResult Index() {
			// Check for existing installation.
			try {
				if (Data.Database.InstalledVersion < Data.Database.CurrentVersion)
					return RedirectToAction("update", "install") ;
				return RedirectToAction("index", "account") ;
			} catch {}
			return View("Index");
        }

		/// <summary>
		/// Shows the update page.
		/// </summary>
		/// <returns></returns>
		public ActionResult Update() {
			if (Data.Database.InstalledVersion < Data.Database.CurrentVersion)
				return View("Update") ;
			return RedirectToAction("index", "account") ;
		}

		/// <summary>
		/// Updates the database.
		/// </summary>
		[HttpPost()]
		public ActionResult RunUpdate(LoginModel m) {
			// Authenticate the user
			if (ModelState.IsValid) {
                if (Piranha.Application.Current.SecurityManager.SignIn(m.Login, m.Password)) {
					return RedirectToAction("ExecuteUpdate") ;
				} else {
					ViewBag.Message = @Piranha.Resources.Account.MessageLoginFailed ;
					ViewBag.MessageCss = "error" ;
					return Update() ;
				}
			} else {
				ViewBag.Message = @Piranha.Resources.Account.MessageLoginEmptyFields ;
				ViewBag.MessageCss = "" ;
				return Update() ;
			}
		}

		[HttpGet()]
		public ActionResult ExecuteUpdate() {
			if (Application.Current.SecurityManager.IsAuthenticated && Application.Current.SecurityManager.IsAdmin()) {
				// Execute all incremental updates in a transaction.
				using (IDbTransaction tx = Database.OpenTransaction()) {
					for (int n = Data.Database.InstalledVersion + 1; n <= Data.Database.CurrentVersion; n++) {
						// Read embedded create script
						Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream(Database.ScriptRoot + ".Updates." +
							n.ToString() + ".sql") ;
						String sql = new StreamReader(str).ReadToEnd() ;
						str.Close() ;

						// Split statements and execute
						string[] stmts = sql.Split(new char[] { ';' }) ;
						foreach (string stmt in stmts) {
							if (!String.IsNullOrEmpty(stmt.Trim()))
								SysGroup.Execute(stmt.Trim(), tx) ;
						}

						// Check for update class
						var utype = Type.GetType("Piranha.Data.Updates.Update" + n.ToString()) ;
						if (utype != null) {
							IUpdate update = (IUpdate)Activator.CreateInstance(utype) ;
							update.Execute(tx) ;
						}
					}
					// Now lets update the database version.
					SysGroup.Execute("UPDATE sysparam SET sysparam_value = @0 WHERE sysparam_name = 'SITE_VERSION'", 
						tx, Data.Database.CurrentVersion) ;
					SysParam.InvalidateParam("SITE_VERSION") ;
					tx.Commit() ;
				}
				return RedirectToAction("index", "account") ;
			} else return RedirectToAction("update") ;
		}

		/// <summary>
		/// Creates a new site installation.
		/// </summary>
		/// <param name="m">The model</param>
		[HttpPost()]
		public ActionResult Create(InstallModel m) {
			if (m.InstallType == "SCHEMA" || ModelState.IsValid) {
				// Read embedded create script
				Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream(Database.ScriptRoot + ".Create.sql") ;
				String sql = new StreamReader(str).ReadToEnd() ;
				str.Close() ;

				// Read embedded data script
				str = Assembly.GetExecutingAssembly().GetManifestResourceStream(Database.ScriptRoot + ".Data.sql") ;
				String data = new StreamReader(str).ReadToEnd() ;
				str.Close() ;

				// Split statements and execute
				string[] stmts = sql.Split(new char[] { ';' }) ;
				using (IDbTransaction tx = Database.OpenTransaction()) {
					// Create database from script
					foreach (string stmt in stmts) {
						if (!String.IsNullOrEmpty(stmt.Trim()))
							SysGroup.Execute(stmt, tx) ;
					}
					tx.Commit() ;
				}

				if (m.InstallType.ToUpper() == "FULL") {
					// Split statements and execute
					stmts = data.Split(new char[] { ';' }) ;
					using (IDbTransaction tx = Database.OpenTransaction()) {
                        // Create admin role
                        Piranha.Application.Current.SecurityManager.CreateRole("Admin") ;

                        // Create admin user
                        Piranha.Application.Current.SecurityManager.CreateUser(m.UserLogin, m.Password) ;

						// Create default data
						foreach (string stmt in stmts) {
							if (!String.IsNullOrEmpty(stmt.Trim()))
								SysGroup.Execute(stmt, tx) ;
						}		
						tx.Commit() ;
					}	
				}

				// Create ASP.NET Identity roles
				foreach (var role in Config.ManagerRoles) { 
					Application.Current.SecurityManager.CreateRole(role) ;
				}

				// Create ASP.NET Identity user
				Application.Current.SecurityManager.CreateUser(m.UserLogin, m.Password) ;

				// Add user to roles
				foreach (var role in Config.ManagerRoles) { 
					Application.Current.SecurityManager.AddToRole(m.UserLogin, role) ;
				}

				// Create default permissions
				CreatePermissions(Config.ManagerRoles) ;

				return RedirectToAction("index", "account") ;
			}
			return Index() ;
		}

		#region Private methods
		/// <summary>
		/// Creates all of the default permissions.
		/// </summary>
		/// <param name="roles">The manager roles</param>
		private void CreatePermissions(string[] roles) {
			// Permissions
			using (var db = new DataContext()) {
				var roleStr = roles.Implode(",") ;

				var perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_PAGE_TEMPLATE",
					Name = "Page types",
					Description = "Permission to manage page types.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_POST_TEMPLATE",
					Name = "Post types",
					Description = "Permission to manage post types.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_PARAM",
					Name = "Params",
					Description = "Permission to manage parameters.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_ACCESS",
					Name = "Permissions",
					Description = "Permission to manage permissions.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_ROLE",
					Name = "Roles",
					Description = "Permission to manage roles.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_PAGE",
					Name = "Pages",
					Description = "Permission to create and update pages.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_PAGE_PUBLISH",
					Name = "Page publishing",
					Description = "Permission to publish, unpublish and delete pages.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_POST",
					Name = "Posts",
					Description = "Permission to create and update pages.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_POST_PUBLISH",
					Name = "Post publishing",
					Description = "Permission to publish, unpublish and delete posts.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_CATEGORY",
					Name = "Categories",
					Description = "Permission to manage categories",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_CONTENT",
					Name = "Media",
					Description = "Permission to create and update media.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_CONTENT_PUBLISH",
					Name = "Media publishing",
					Description = "Permission to manage media.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_USER",
					Name = "Users",
					Description = "Permission to manage user accounts.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_COMMENT",
					Name = "Comments",
					Description = "Permission to manage comments.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				perm = new Entities.Permission() {
					IsLocked = true,
					InternalId = "ADMIN_SITETREE",
					Name = "Sites",
					Description = "Permission to manage sites.",
					Roles = roleStr
				} ;
				db.Permissions.Add(perm) ;

				db.SaveChanges() ;
			}
		}
		#endregion
	}
}
