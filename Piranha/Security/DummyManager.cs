using System;
using System.Collections.Generic;
using System.Configuration;

namespace Piranha.Security
{
	/// <summary>
	/// The dummy security manager is active until the framework security been 
	/// initialized. This is to avoid null pointer exception and to inform 
	/// the developer that security has not been properly initialized,
	/// </summary>
	internal class DummyManager : ISecurityManager
	{
		/// <summary>
		/// Gets whether the current user is authenticated.
		/// </summary>
		public bool IsAuthenticated {
			get {
				throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
			}
		}

		/// <summary>
		/// Creates a new user with the given username and password.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="password">The password</param>
		/// <returns>If the user was created successfully</returns>
		public bool CreateUser(string username, string password) {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Creates a new role with the given name.
		/// </summary>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the role was created successfully</returns>
		public bool CreateRole(string rolename) {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Adds the user with the given username to the role with
		/// the given name.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the user was added to the role successfully</returns>
		public bool AddToRole(string username, string rolename) {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Removes the user with the given username from the role with
		/// the given name.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the user was removed from the role successfully</returns>
		public bool RemoveFromRole(string username, string rolename) {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Gets all of the currently available roles.
		/// </summary>
		/// <returns>The roles</returns>
		public IList<SecurityRole> GetAllRoles() {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Checks if the current user has access to the manager interface.
		/// </summary>
		/// <returns>If the current is is an admin</returns>
		public bool IsAdmin() {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Checks if the current user is a member of the given role.
		/// </summary>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the current user is a member of the given role</returns>
		public bool IsInRole(string rolename) {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Signs in the user with the given credentials.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="password">The password</param>
		/// <param name="persistent">If the login should be persistent</param>
		/// <returns>If the user was successfully signed in</returns>
		public bool SignIn(string username, string password, bool persistent = false) {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}

		/// <summary>
		/// Signs out the currently logged in user.
		/// </summary>
		public void SignOut() {
			throw new ConfigurationErrorsException("The security manager has not been initialized. Please call Piranha.Application.Current.InitSecurity in your startup code.") ;
		}
	}
}