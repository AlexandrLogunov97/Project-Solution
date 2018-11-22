using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Portfolio.Site.ContentSearch.Queries;
using Portfolio.Site.ContentSearch.Repositories;
using Portfolio.Site.ContentSearch.SearchTypes;
using Portfolio.Site.Models;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.SecurityModel;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Site.Controllers
{
    public class GlobalController : GlassController
    {
        private readonly ISitecoreContext _context;
        public GlobalController(ISitecoreContext context)
        {
            _context = context;
        }
        public ActionResult Slider()
        {
            var paramId = RenderingContext.CurrentOrNull.Rendering.Parameters["Speed"];
            var paramItem = Sitecore.Context.Database.GetItem(paramId);
            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            Item datasource = Sitecore.Context.Database.GetItem(datasourceId);
            MultilistField multilist = datasource.Fields["Images"];
            
            SliderViewModel slider = new SliderViewModel(multilist.GetItems().ToArray(), paramItem.Fields["Value"].Value);
            //new Exception("You dfvdvdfvnk");
            return View("~/Views/Renderings/Home/Slider.cshtml", slider);
        }
        public ActionResult HeroBanner()
        {
            var images= ((MultilistField)DataSourceItem.Fields["Images"]).GetItems();
            var heroImage = images.FirstOrDefault();       
            HeroBannerViewModel heroBanner = new HeroBannerViewModel(heroImage);
            return View("~/Views/Renderings/Home/HeroBanner.cshtml", heroBanner);
        }
        public ActionResult Top()
        {
            var item = Sitecore.Context.Database.GetItem(new ID(RenderingContext.CurrentOrNull.Rendering.DataSource));
            var result = (MultilistField)item.Fields["Projects"];           
            var top = result.GetItems().ToArray();
            return View("~/Views/Renderings/Home/Top.cshtml", top);
        }
    }
}