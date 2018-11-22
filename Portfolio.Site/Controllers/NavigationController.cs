using Portfolio.Site.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Site.Controllers
{
    public class NavigationController : Controller
    {
        public ActionResult Header()
        {
            var item = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            
            var items = item.GetChildren().Where(x => 
            {
                if(x.Template.BaseTemplates.FirstOrDefault(template=> template.Name.Equals("Navigation"))!=null)
                    return ((CheckboxField)x.Fields["Show Navigation"]).Checked;
                return false;
            });
            NavigationViewModel navigation = new NavigationViewModel(items,item);
            return View("~/Views/Renderings/Header.cshtml", navigation);
        }
        public ActionResult Footer()
        {
            var item = Sitecore.Context.Database.GetItem(new ID(RenderingContext.CurrentOrNull.Rendering.DataSource));
            return View("~/Views/Renderings/Footer.cshtml", item);
        }
    }
}