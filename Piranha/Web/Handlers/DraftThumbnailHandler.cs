using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piranha.Web.Handlers
{
	public class DraftThumbnailHandler : ThumbnailHandler
	{
		/// <summary>
		/// Handles the current request.
		/// </summary>
		/// <param name="context">The current context</param>
		/// <param name="args">Optional url arguments passed to the handler</param>
		public override void HandleRequest(HttpContext context, params string[] args) {
			//if (Application.Current.SecurityManager.IsAdmin && Application.Current.SecurityManager.IsAdmin())
				HandleRequest(context, true, args) ;
			//else HandleRequest(context, false, args) ;
		}
	}
}