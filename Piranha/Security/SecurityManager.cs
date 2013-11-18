using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Piranha.Security
{
	/// <summary>
	/// Internal implementation of the ISecurityManager interface.
	/// </summary>
	/// <typeparam name="TUser">The identity user type</typeparam>
	/// <typeparam name="TRole">The identity user role type</typeparam>
	/// <typeparam name="TContext">The identity context type</typeparam>
	internal class SecurityManager<TUser, TRole, TContext> : ISecurityManager
		where TUser : IdentityUser
		where TRole : IdentityRole
		where TContext : IdentityDbContext<TUser>
	{
		#region Properties
		/// <summary>
		/// Gets the current authentication manager.
		/// </summary>
		private IAuthenticationManager AuthenticationManager {
			get { return HttpContext.Current.GetOwinContext().Authentication ; }
		}

		/// <summary>
		/// Gets whether the current user is authenticated.
		/// </summary>
		public bool IsAuthenticated {
			get {
				if (Hooks.Security.IsAuthenticated != null)
					return Hooks.Security.IsAuthenticated();
				return HttpContext.Current.User.Identity.IsAuthenticated ;
			}
		}
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SecurityManager() {}

		/// <summary>
		/// Creates a new user with the given username and password.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="password">The password</param>
		/// <returns>If the user was created successfully</returns>
		public bool CreateUser(string username, string password) {
			using (var manager = GetUserManager()) {
				var user = Activator.CreateInstance<TUser>() ;

				user.UserName = username ;

				var result = manager.Create(user, password) ;

				return result.Succeeded ;
			}
		}

		/// <summary>
		/// Creates a new role with the given name.
		/// </summary>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the role was created successfully</returns>
		public bool CreateRole(string rolename) {
			using (var manager = GetRoleManager()) {
				var role = Activator.CreateInstance<TRole>() ;

				role.Name = rolename ;

				return manager.Create(role).Succeeded ;
			}
		}

		/// <summary>
		/// Adds the user with the given username to the role with
		/// the given name.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the user was added to the role successfully</returns>
		public bool AddToRole(string username, string rolename) {
			using (var manager = GetUserManager()) {
				var user = manager.FindByName(username) ;
				if (user != null) {
					return manager.AddToRole(user.Id, rolename).Succeeded ;
				}
				return false ;
			}
		}

		/// <summary>
		/// Removes the user with the given username from the role with
		/// the given name.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the user was removed from the role successfully</returns>
		public bool RemoveFromRole(string username, string rolename) {
			using (var manager = GetUserManager()) {
				var user = manager.FindByName(username) ;
				if (user != null) {
					return manager.RemoveFromRole(user.Id, rolename).Succeeded ;
				}
				return false ;
			}
		}

		/// <summary>
		/// Gets all of the currently available roles.
		/// </summary>
		/// <returns>The roles</returns>
		public IList<SecurityRole> GetAllRoles() {
			using (var context = Activator.CreateInstance<TContext>()) {
				return context.Roles.Select(r => new SecurityRole() { Id = r.Id, Name = r.Name }).ToList() ;
			}
		}

		/// <summary>
		/// Checks if the current user has access to the manager interface.
		/// </summary>
		/// <returns>If the current is is an admin</returns>
		public bool IsAdmin() {
			if (Hooks.Security.IsAdmin != null) {
				return Hooks.Security.IsAdmin() ;
			} else {
				if (Config.ManagerRoles.Length > 0) {
					foreach (var role in Config.ManagerRoles) {
						if (IsInRole(role))
							return true ;
					}
					return false ;
				}
				return true ;
			}
		}

		/// <summary>
		/// Checks if the current user is a member of the given role.
		/// </summary>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the current user is a member of the given role</returns>
		public bool IsInRole(string rolename) {
			if (Hooks.Security.IsInRole != null)
				return Hooks.Security.IsInRole(rolename) ;
			return HttpContext.Current.User.IsInRole(rolename) ;
		}

		/// <summary>
		/// Signs in the user with the given credentials.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="password">The password</param>
		/// <param name="persist">If the login should be persistent</param>
		/// <returns>If the user was successfully signed in</returns>
		public bool SignIn(string username, string password, bool persist = false) {
			if (Hooks.Security.SignIn != null) {
				return Hooks.Security.SignIn(username, password, persist) ;
			} else {
				using (var manager = GetUserManager()) {
					var user = manager.Find(username, password) ;
					if (user != null) {
						AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie) ;
						var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie) ;
						AuthenticationManager.SignIn(new AuthenticationProperties() {
							IsPersistent = persist
						}, identity) ;

						return true ;
					}
					return false ;
				}
			}
		}

		/// <summary>
		/// Signs out the currently logged in user.
		/// </summary>
		public void SignOut() {
			if (Hooks.Security.SignOut != null)
				Hooks.Security.SignOut() ;
			else AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie) ;
		}

		#region Private methods
		/// <summary>
		/// Gets a new instance of the user manager.
		/// </summary>
		/// <param name="context">Optional identity context</param>
		/// <returns>The user manager</returns>
		private UserManager<TUser> GetUserManager(TContext context = null) {
			if (context == null)
				context = Activator.CreateInstance<TContext>() ;
			return new UserManager<TUser>(new UserStore<TUser>(context)) ;
		}

		/// <summary>
		/// Gets a new instance of the role manager.
		/// </summary>
		/// <param name="context">Optional identity context</param>
		/// <returns>The role manager</returns>
		private RoleManager<TRole> GetRoleManager(TContext context = null) {
			if (context == null)
				context = Activator.CreateInstance<TContext>() ;
			return new RoleManager<TRole>(new RoleStore<TRole>(context)) ;
		}
		#endregion
	}
}