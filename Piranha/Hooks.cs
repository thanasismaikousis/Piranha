using System;
using System.Text;

namespace Piranha
{
	/// <summary>
	/// Static class containing all of the application hooks available.
	/// </summary>
	public static class Hooks
	{
		#region Delegates
		/// <summary>
		/// Class containing all of the delegates used by the hooks.
		/// </summary>
		public static class Delegates
		{
			public delegate bool SecuritySignInDelegate(string username, string password, bool persist) ;
			public delegate void SecuritySignOutDelegate() ;
			public delegate bool SecurityIsAuthenticatedDelegate() ;
			public delegate bool SecurityIsInRoleDelegate(string rolename) ;
			public delegate bool SecurityIsAdminDelegate() ;

			public delegate void BreadcrumbStartDelegate(Web.UIHelper ui, StringBuilder str) ;
			public delegate void BreadcrumbEndDelegate(Web.UIHelper ui, StringBuilder str) ;
			public delegate void BreadcrumbItemDelegate(Web.UIHelper ui, StringBuilder str, Models.Sitemap page) ;

			public delegate void HeadDelegate(Web.UIHelper ui, StringBuilder str, Models.Page page, Models.Post post) ;

			public delegate void MenuItemDelegate(Web.UIHelper ui, StringBuilder str, Models.Sitemap page, bool active, bool activechild) ;
			public delegate void MenuItemLinkDelegate(Web.UIHelper ui, StringBuilder str, Models.Sitemap page) ;
			public delegate void MenuLevelDelegate(Web.UIHelper ui, StringBuilder str, string cssclass) ;
		}
		#endregion

		/// <summary>
		/// The security group contains all of the hooks available when different security actions
		/// is executed by the security manager.
		/// </summary>
		public static class Security
		{
			/// <summary>
			/// Signs in the user with the given credentials. If this hook is implemented the 
			/// default sign in will be bypassed.
			/// </summary>
			public static Delegates.SecuritySignInDelegate SignIn ;

			/// <summary>
			/// Signs out the current user. If this hook is implemented the default sign out
			/// will be bypassed.
			/// </summary>
			public static Delegates.SecuritySignOutDelegate SignOut ;

			/// <summary>
			/// Checks if the current user is authenticated. If this hook is implemented the
			/// default authentication check will be bypassed.
			/// </summary>
			public static Delegates.SecurityIsAuthenticatedDelegate IsAuthenticated ;

			/// <summary>
			/// Checks if the current user is a member of the given role. If this hook is
			/// implemented the default role check will be bypassed.
			/// </summary>
			public static Delegates.SecurityIsInRoleDelegate IsInRole ;

			/// <summary>
			/// Checks if the current user has access to the manager interface. If this hook
			/// is implemented the default check will be bypassed.
			/// </summary>
			public static Delegates.SecurityIsAdminDelegate IsAdmin ;
		}

		/// <summary>
		/// The UI group contains all of the hooks available when rendering UI components in
		/// the client framework.
		/// </summary>
		public static class UI
		{
			/// <summary>
			/// The different hooks available for the breadcrumb.
			/// </summary>
			public static class Breadcrumb
			{
				/// <summary>
				/// Renders the start of the breadcrumb. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.BreadcrumbStartDelegate RenderStart ;

				/// <summary>
				/// Renders the end of the breadcrumb. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.BreadcrumbEndDelegate RenderEnd ;

				/// <summary>
				/// Renders a breadcrumb item. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.BreadcrumbItemDelegate RenderItem ;

				/// <summary>
				/// Renders the currently active breadcrumb item. If this hooks is 
				/// implemented it replaces the default rendering.
				/// </summary>
				public static Delegates.BreadcrumbItemDelegate RenderActiveItem ;
			}

			/// <summary>
			/// The different hooks available for the head.
			/// </summary>
			public static class Head
			{
				/// <summary>
				/// Renders optional information in the head.
				/// </summary>
				public static Delegates.HeadDelegate Render ;
			}

			/// <summary>
			/// The different hooks availble for the menu.
			/// </summary>
			public static class Menu
			{
				/// <summary>
				/// Renders the start of a menu level. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.MenuLevelDelegate RenderLevelStart ;

				/// <summary>
				/// Renders the end of a menu level. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.MenuLevelDelegate RenderLevelEnd ;

				/// <summary>
				/// Renders the start of a menu item. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.MenuItemDelegate RenderItemStart ;

				/// <summary>
				/// Renders the end of a menu item. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.MenuItemDelegate RenderItemEnd ;

				/// <summary>
				/// Renders the menu item link. If this hooks is implemented it
				/// replaces the default rendering.
				/// </summary>
				public static Delegates.MenuItemLinkDelegate RenderItemLink ;
			}
		}
	}
}