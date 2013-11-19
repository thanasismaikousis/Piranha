using System;

namespace Piranha.Entities
{
	/// <summary>
	/// The permission entity.
	/// </summary>
	[Serializable]
	public class Permission : StandardEntity<Permission>, IInternalIdEntity, ICacheEntity
	{
		#region Properties
		/// <summary>
		/// Gets/sets the internal id of the permission.
		/// </summary>
		public string InternalId { get ; set ; }

		/// <summary>
		/// Gets/sets the name of the permission.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the description shown in the manager interface.
		/// </summary>
		public string Description { get ; set ; }

		/// <summary>
		/// Gets/sets whether this permission can be removed or not.
		/// </summary>
		public bool IsLocked { get ; set ; }

		/// <summary>
		/// Gets/sets the roles that are granted this permission.
		/// </summary>
		public string Roles { get ; set ; }
		#endregion

        /// <summary>
        /// Removes the current entity from the application cache.
        /// </summary>
		public void RemoveFromCache() {
			Application.Current.EntityCache.Permissions.Remove(Id) ;
		}
	}
}
