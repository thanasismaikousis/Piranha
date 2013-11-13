﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Piranha.Areas.Manager.Views.SiteTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
    using Piranha.Web;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Manager/Views/SiteTree/Edit.cshtml")]
    public partial class Edit : System.Web.Mvc.WebViewPage<Piranha.Areas.Manager.Models.SiteTreeEditModel>
    {
        public Edit()
        {
        }
        public override void Execute()
        {



DefineSection("Head", () => {

WriteLiteral("\r\n    <script type=\"text/javascript\" src=\"");


            
            #line 4 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                   Write(Href("~/res.ashx/areas/manager/content/js/jquery.form.js"));

            
            #line default
            #line hidden
WriteLiteral("\"></script>\r\n    <script type=\"text/javascript\" src=\"");


            
            #line 5 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                   Write(Href("~/res.ashx/areas/manager/content/js/jquery.regiontemplate.js"));

            
            #line default
            #line hidden
WriteLiteral("\"></script>\r\n    <script type=\"text/javascript\" src=\"");


            
            #line 6 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                   Write(Href("~/res.ashx/areas/manager/content/js/ext/json2.js"));

            
            #line default
            #line hidden
WriteLiteral("\"></script>\r\n    <script type=\"text/javascript\">\r\n        /**\r\n         * This va" +
"r is needed by the regiontemplate script.\r\n         */\r\n        var templateid =" +
" \'");


            
            #line 11 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                     Write(Model.Template.Id);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\r\n        $(document).ready(function () {\r\n            $(\'#Name\').focus();\r\n " +
"       });\r\n    </script>\r\n");


});

WriteLiteral("\r\n");


DefineSection("Toolbar", () => {

WriteLiteral("\r\n");


            
            #line 19 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
Write(Html.Partial("Partial/Tabs"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"toolbar\">\r\n    <div class=\"inner\">\r\n        <ul>\r\n            <li><" +
"a class=\"save submit\">");


            
            #line 23 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                  Write(Piranha.Resources.Global.ToolbarSave);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");


            
            #line 24 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
             if (Model.CanDelete && Model.Id != Piranha.Config.DefaultSiteTreeId) {

            
            #line default
            #line hidden
WriteLiteral("            <li><a href=\"");


            
            #line 25 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                    Write(Url.Action("delete", new { id = Model.Id }));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"delete\">");


            
            #line 25 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                                 Write(Piranha.Resources.Global.ToolbarDelete);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");


            
            #line 26 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <li><a href=\"");


            
            #line 27 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                    Write(Url.Action("index", "sitetree"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"back\">");


            
            #line 27 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                   Write(Piranha.Resources.Global.ToolbarBack);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n            <li><a href=\"");


            
            #line 28 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                    Write(Url.Action("edit", new { id = Model.Id }));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"refresh\">");


            
            #line 28 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                                Write(Piranha.Resources.Global.ToolbarReload);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n            ");


            
            #line 29 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
       Write(Piranha.WebPages.Hooks.Manager.Toolbar.Render(Url, Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </ul>\r\n        <div class=\"clear\"></div>\r\n    </div>\r\n</div>\r\n");


});

WriteLiteral("\r\n");


            
            #line 35 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
   Html.BeginForm() ; 

            
            #line default
            #line hidden

            
            #line 36 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
Write(Html.HiddenFor(m => m.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 37 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
Write(Html.HiddenFor(m => m.NamespaceId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 38 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
Write(Html.HiddenFor(m => m.CanDelete));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"grid_12\">\r\n    <div class=\"box\">\r\n        <div class=\"title\"><h2>");


            
            #line 41 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                          Write(Piranha.Resources.Global.Information);

            
            #line default
            #line hidden
WriteLiteral("</h2></div>\r\n        <div class=\"inner\">\r\n            <ul class=\"form\">\r\n        " +
"        <li>\r\n                    ");


            
            #line 45 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
               Write(Html.LabelFor(m => m.Name, Piranha.Resources.Global.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div class=\"input\">\r\n                        ");


            
            #line 47 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                   Write(Html.TextBoxFor(m => m.Name));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    ");


            
            #line 48 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
               Write(Html.ValidationMessageFor(m => m.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </li>\r\n                <li>\r\n                    ");


            
            #line 51 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
               Write(Html.LabelFor(m => m.InternalId, Piranha.Resources.Global.InternalId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div class=\"input\">\r\n");


            
            #line 53 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                         if (Model.Id != Piranha.Config.DefaultSiteTreeId) {
                        
            
            #line default
            #line hidden
            
            #line 54 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                   Write(Html.TextBoxFor(m => m.InternalId, new { @placeholder = Piranha.Resources.Global.Optional }));

            
            #line default
            #line hidden
            
            #line 54 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                                                                     
                        } else {
                        
            
            #line default
            #line hidden
            
            #line 56 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                   Write(Html.TextBoxFor(m => m.InternalId, new { @disabled = true }));

            
            #line default
            #line hidden
            
            #line 56 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                                     
                        
            
            #line default
            #line hidden
            
            #line 57 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                   Write(Html.HiddenFor(m => m.InternalId));

            
            #line default
            #line hidden
            
            #line 57 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                          
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                    ");


            
            #line 60 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
               Write(Html.ValidationMessageFor(m => m.InternalId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </li>\r\n                <li>\r\n                    ");


            
            #line 63 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
               Write(Html.LabelFor(m => m.Description, Piranha.Resources.Global.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div class=\"input\">\r\n                        ");


            
            #line 65 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                   Write(Html.TextAreaFor(m => m.Description, new { @placeholder = Piranha.Resources.Global.Optional }));

            
            #line default
            #line hidden
WriteLiteral(@"</div>
                </li>
            </ul>
        </div>
    </div>
    <div class=""box main-content content-editor"">
        <table>
            <tr>
                <td class=""tools"">
                    <ul>
                        <li class=""btn-settings active""><a href=""#"" data-id=""pnl-settings"">");


            
            #line 75 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                                      Write(Piranha.Resources.Global.Settings);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                        <li class=\"btn-regions\"><a href=\"#\" data-id=\"p" +
"nl-regions\">");


            
            #line 76 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                             Write(Piranha.Resources.Global.Regions);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                    </ul>\r\n                </td>\r\n                <td>" +
"\r\n                    <div id=\"pnl-settings\" class=\"main\">\r\n                    " +
"    <div class=\"title\"><h2>");


            
            #line 81 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                          Write(Piranha.Resources.Global.Settings);

            
            #line default
            #line hidden
WriteLiteral("</h2></div>\r\n                        <div class=\"inner\">\r\n                       " +
"     <ul class=\"form\">\r\n                                <li>\r\n                  " +
"                  ");


            
            #line 85 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                               Write(Html.LabelFor(m => m.HostNames, Piranha.Resources.SiteTree.HostNames));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    <div class=\"input\">\r\n                      " +
"                  ");


            
            #line 87 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                   Write(Html.TextBoxFor(m => m.HostNames, new { @placeholder = Piranha.Resources.Global.Optional }));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                                </li>\r\n                                <l" +
"i>\r\n                                    ");


            
            #line 90 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                               Write(Html.LabelFor(m => m.Template.Preview, Piranha.Resources.Page.HtmlPreview));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    <div class=\"input\">\r\n                      " +
"                  ");


            
            #line 92 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                   Write(Html.TextAreaFor(m => m.Template.Preview, new { @rows = 6 }));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                                </li>\r\n                            </ul>\r" +
"\n                        </div>\r\n                    </div>\r\n                   " +
" <div id=\"pnl-regions\" class=\"main hidden\">\r\n                        <div class=" +
"\"title\"><h2>");


            
            #line 98 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                          Write(Piranha.Resources.Global.Regions);

            
            #line default
            #line hidden
WriteLiteral("</h2></div>\r\n                        <div class=\"inner\">\r\n                       " +
"     <table class=\"list region-editor\">\r\n                                <tbody>" +
"\r\n                                    <tr>\r\n                                    " +
"    <th>");


            
            #line 103 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                       Write(Piranha.Resources.Global.Name);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                        <th>");


            
            #line 104 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                       Write(Piranha.Resources.Global.InternalId);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                        <th>");


            
            #line 105 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                       Write(Piranha.Resources.Global.Type);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                        <th></th>\r\n                       " +
"             </tr>\r\n                                    ");


            
            #line 108 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                               Write(Html.EditorFor(m => m.Regions));

            
            #line default
            #line hidden
WriteLiteral(@"
                                    <tr class=""dark"">
                                        <td class=""form"">
                                            <div class=""input"">
                                                <input type=""text"" id=""newregionName"" /></div>
                                        </td>
                                        <td class=""form"">
                                            <div class=""input"">
                                                <input type=""text"" id=""newregionInternalId"" /></div>
                                        </td>
                                        <td class=""form"">
                                            <div class=""input"">
                                                ");


            
            #line 120 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                           Write(Html.DropDownList("newregionType",
                                                    new SelectList(Model.RegionTypes, "Type", "Name")));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                                        </td>\r\n                          " +
"              <td class=\"buttons four\">\r\n                                       " +
"     <button id=\"btnAddRegion\" class=\"btn marg-big\">");


            
            #line 124 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
                                                                                      Write(Piranha.Resources.Global.Add);

            
            #line default
            #line hidden
WriteLiteral(@"</button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
");


            
            #line 136 "..\..\Areas\Manager\Views\SiteTree\Edit.cshtml"
   Html.EndForm() ; 

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
