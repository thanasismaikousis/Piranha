using System;
using System.Collections.Generic;

namespace Piranha.Models
{
	/// <summary>
	/// Permissions are used to limit users of different roles to different
	/// parts of the application.
	/// </summary>
	public sealed class Permission
	{
		/// <summary>
		/// The unique id.
		/// </summary>
		public Guid? Id { get ; internal set ; }

		/// <summary>
		/// The internal id that should be used when accessing the
		/// permission from the application logic.
		/// </summary>
		public string InternalId { get ; set ; }

		/// <summary>
		/// The display name of the permission.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// The optional description.
		/// </summary>
		public string Description { get ; set ; }

		/// <summary>
		/// The roles that are granted this permission.
		/// </summary>
		public IList<string> Roles { get ; set ; }

		/// <summary>
		/// When the permission was initially created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// When the permission was last updated.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Permission() { 
			Roles = new List<string>() ;
		}
	}
}