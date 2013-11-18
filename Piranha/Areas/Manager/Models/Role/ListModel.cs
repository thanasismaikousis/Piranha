using System;
using System.Collections.Generic;
using System.Linq;

namespace Piranha.Areas.Manager.Models.Role
{
	/// <summary>
	/// View model for the manager role list.
	/// </summary>
	public class ListModel
	{
		#region Properties
		/// <summary>
		/// Gets/sets the available roles.
		/// </summary>
		public IList<Security.SecurityRole> Roles { get ; set ; }
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ListModel() { 
			Roles = new List<Security.SecurityRole>() ;
		}

		/// <summary>
		/// Gets the list model for all roles sorted in alphabetical order.
		/// </summary>
		/// <returns>The model</returns>
		public static ListModel Get() { 
			var m = new ListModel() {
				Roles = Application.Current.SecurityManager.GetAllRoles().OrderBy(r => r.Name).ToList()
			} ;
			return m ;
		}
	}
}