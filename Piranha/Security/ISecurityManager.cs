using System;
using System.Collections.Generic;

namespace Piranha.Security
{
	/// <summary>
	/// Interface for the security manager handling users, roles
	/// and authentication.
	/// </summary>
	public interface ISecurityManager
	{
		/// <summary>
		/// Gets whether the current user is authenticated.
		/// </summary>
		bool IsAuthenticated { get ; }

		/// <summary>
		/// Creates a new user with the given username and password.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="password">The password</param>
		/// <returns>If the user was created successfully</returns>
		bool CreateUser(string username, string password) ;

		/// <summary>
		/// Creates a new role with the given name.
		/// </summary>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the role was created successfully</returns>
		bool CreateRole(string rolename) ;

		/// <summary>
		/// Adds the user with the given username to the role with
		/// the given name.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the user was added to the role successfully</returns>
		bool AddToRole(string username, string rolename) ;

		/// <summary>
		/// Removes the user with the given username from the role with
		/// the given name.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the user was removed from the role successfully</returns>
		bool RemoveFromRole(string username, string rolename) ;

		/// <summary>
		/// Gets all of the currently available roles.
		/// </summary>
		/// <returns>The roles</returns>
		IList<SecurityRole> GetAllRoles() ;

		/// <summary>
		/// Checks if the current user has access to the manager interface.
		/// </summary>
		/// <returns>If the current is is an admin</returns>
		bool IsAdmin() ;

		/// <summary>
		/// Checks if the current user is a member of the given role.
		/// </summary>
		/// <param name="rolename">The rolename</param>
		/// <returns>If the current user is a member of the given role</returns>
		bool IsInRole(string rolename) ;

		/// <summary>
		/// Signs in the user with the given credentials.
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="password">The password</param>
		/// <param name="persistent">If the login should be persistent</param>
		/// <returns>If the user was successfully signed in</returns>
		bool SignIn(string username, string password, bool persistent = false) ;

		/// <summary>
		/// Signs out the currently logged in user.
		/// </summary>
		void SignOut() ;
	}
}
