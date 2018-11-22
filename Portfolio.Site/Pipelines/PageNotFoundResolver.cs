using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Portfolio.Site.Pipelines
{
    public class PageNotFoundResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            string filePath = HttpContext.Current.Server.MapPath(args.Url.FilePath);
            if (IsValidItem() || args.LocalPath.StartsWith("/sitecore") || File.Exists(filePath))
                return;
            Sitecore.Context.Item = Get404Page();
            if (Sitecore.Context.Item != null)
                Sitecore.Context.Items["Is404Page"] = "true";
        }
        protected virtual bool IsValidItem()
        {
            if (Sitecore.Context.Item == null || Sitecore.Context.Item.Versions.Count == 0)
                return false;
            if (Sitecore.Context.Item.Visualization.Layout == null)
                return false;
            return true;
        }
        private Item Get404Page()
        {
            string itemPath = Sitecore.Context.Site.RootPath + "/Home/404-Page";
            Log.Info(itemPath, this);
            return Sitecore.Context.Database.GetItem(itemPath);
        }
    }
}