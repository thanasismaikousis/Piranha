using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piranha
{
	/// <summary>
	/// The main application api for working with the Piranha CMS models.
	/// </summary>
	public sealed class Api : IDisposable
	{
		#region Members
		/// <summary>
		/// The private data context.
		/// </summary>
		private readonly DataContext uow ;

		/// <summary>
		/// Gets the permission repository.
		/// </summary>
		public readonly Repositories.IPermissionRepository Permissions ;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Api() { 
			uow = new DataContext() ;

			Permissions = new Repositories.PermissionRepository(uow) ;
		}

		/// <summary>
		/// Saves the changes made to the current api.
		/// </summary>
		/// <returns>The number of changes saved to the database</returns>
		public int SaveChanges() { 
			return uow.SaveChanges() ;
		}

		/// <summary>
		/// Disposes the api and all of its resources.
		/// </summary>
		public void Dispose() { 
			uow.Dispose() ;
			GC.SuppressFinalize(this) ;
		}
	}
}