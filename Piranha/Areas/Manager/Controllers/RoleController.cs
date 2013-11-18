using System;
using System.Web.Mvc;

namespace Piranha.Areas.Manager.Controllers
{
	public class RoleController : Controller
	{
		public ActionResult Index() {
			return View(Models.Role.ListModel.Get()) ;
		}
	}
}