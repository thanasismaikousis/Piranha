using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Piranha;
using Piranha.Data;
using Piranha.Models;
using Piranha.Models.Manager.SettingModels;

namespace Piranha.Areas.Manager.Controllers
{
	/// <summary>
	/// Settings controller for the manager area.
	/// </summary>
    public class SettingsController : ManagerController
    {		
		#region Param actions
		/// <summary>
		/// Gets the param list.
		/// </summary>
		[Access(Function="ADMIN_PARAM")]
        public ActionResult ParamList() {
            return View(@"~/Areas/Manager/Views/Settings/ParamList.cshtml", ParamListModel.Get());
        }

		/// <summary>
		/// Edits or creates a new parameter
		/// </summary>
		/// <param name="id">Parameter id</param>
		[Access(Function="ADMIN_PARAM")]
		public ActionResult Param(string id) {
			if (!String.IsNullOrEmpty(id)) {
				ViewBag.Title = Piranha.Resources.Settings.EditTitleExistingParam ;
				return View(@"~/Areas/Manager/Views/Settings/Param.cshtml", ParamEditModel.GetById(new Guid(id))) ;
			} else {
				ViewBag.Title = Piranha.Resources.Settings.EditTitleNewParam ;
				return View(@"~/Areas/Manager/Views/Settings/Param.cshtml", new ParamEditModel()) ;
			}
		}

		/// <summary>
		/// Edits or creates a new parameter
		/// </summary>
		/// <param name="id">Parameter id</param>
		[HttpPost()]
		[Access(Function="ADMIN_PARAM")]
		public ActionResult Param(ParamEditModel pm) {
			if (pm.Param.IsNew)
				ViewBag.Title = Piranha.Resources.Settings.EditTitleNewParam ;
			else ViewBag.Title = Piranha.Resources.Settings.EditTitleExistingParam ;

			if (ModelState.IsValid) {
				try {
					if (pm.SaveAll()) {
						ModelState.Clear() ;
						ViewBag.Title = Piranha.Resources.Settings.EditTitleExistingParam ;
						SuccessMessage(Piranha.Resources.Settings.MessageParamSaved) ;
					} else ErrorMessage(Piranha.Resources.Settings.MessageParamNotSaved) ;
				} catch (Exception e) {
					ErrorMessage(e.ToString()) ;
				}
			}
			return View(@"~/Areas/Manager/Views/Settings/Param.cshtml", pm) ;
		}


		/// <summary>
		/// Deletes the specified param
		/// </summary>
		/// <param name="id">The param</param>
		[Access(Function="ADMIN_PARAM")]
		public ActionResult DeleteParam(string id) {
			ParamEditModel pm = ParamEditModel.GetById(new Guid(id)) ;
			
			ViewBag.SelectedTab = "params" ;
			if (pm.DeleteAll())
				SuccessMessage(Piranha.Resources.Settings.MessageParamDeleted) ;
			else ErrorMessage(Piranha.Resources.Settings.MessageParamNotDeleted) ;

			return ParamList() ;
		}
		#endregion
	}
}
