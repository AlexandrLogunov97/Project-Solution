using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Pipelines
{
    public class Set404Status:HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (Sitecore.Context.Items["Is404Page"] != null && Sitecore.Context.Items["Is404Page"].ToString() == "true")
            {
                HttpContext.Current.Response.StatusCode = 404; HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}