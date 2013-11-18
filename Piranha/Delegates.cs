using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Piranha.WebPages;

namespace Piranha
{
	/// <summary>
	/// The different delegates used by the framework.
	/// </summary>
	public static class Delegates
	{
		public delegate void ModelLoadedHook<T>(T model) ;
		public delegate void ManagerModelHook<T>(Controller controller, WebPages.Manager.MenuItem menu, T model) ;

		public delegate void ManagerToolbarRender<T>(UrlHelper url, StringBuilder str, T model) ;

        /*
         * TODO
		public delegate void SendPassword(Entities.User user, string password);
         */
	}
}
