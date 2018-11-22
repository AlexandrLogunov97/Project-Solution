using Portfolio.Site.ContentSearch.Queries;
using Portfolio.Site.ContentSearch.Repositories;
using Portfolio.Site.ContentSearch.SearchTypes;
using Portfolio.Site.Models;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Mvc.Presentation;
using Sitecore.SecurityModel;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Site.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectsRepository _repository;
        private readonly Dictionary<string, string> hosts;
        public PortfolioController(IProjectsRepository repository)
        {
            hosts = new Dictionary<string, string>();
            hosts.Add("reply.demo.local", "pf_web_index");
            hosts.Add("new.site.local", "newpf_web_index");
            _repository = repository;
            _repository.IndexName = hosts[Sitecore.Context.Site.Name];
        }
        public ActionResult List()
        {
            var args = new ProjectsQueryArgs
            {                
                Page = 1,
                Size = 10,
                Language=Sitecore.Context.Language.Name            
            };
            var model = GetSearchResults(args);
            return View("~/Views/Renderings/List/List.cshtml", model);
        }

        private ProjectsViewModel GetSearchResults(ProjectsQueryArgs args) 
        {
            var results = _repository.Get(args);

            var model = new ProjectsViewModel
            {
                Projects = results.Select(x => new ProjectViewModel {
                    ImageUrl = x.Document.ImageUrl,
                    ItemUrl = x.Document.ItemUrl,
                    Name = x.Document.ProjectName
                }).ToList()
            };

            var categoryFacets = results.Facets.Categories.FirstOrDefault(x => x.Name == "category");
            
            if (categoryFacets != null)
            {
                model.Categories = categoryFacets.Values.Select(x => new FacetViewModel
                {
                    Name = x.Name,
                    Count = x.AggregateCount
                }).ToList();
            }

            var tagsFacets = results.Facets.Categories.FirstOrDefault(x => x.Name == "tags");
            if (tagsFacets != null)
            {
                model.Tags = tagsFacets.Values.Select(x => new FacetViewModel
                {                 
                    Name = x.Name,
                    Count = x.AggregateCount
                }).ToList();
            }
            model.CountPages = (int)Math.Ceiling((double)results.TotalSearchResults / args.Size);
            model.CurrentPage = ((ProjectsQueryArgs)args).Page;
            return model;
        }

        [HttpPost]
        public ActionResult Search(ProjectsQueryArgs args)
         {
            args.Language = Sitecore.Context.Language.Name;
            var model = GetSearchResults(args);
            return PartialView("~/Views/Renderings/List/Results.cshtml", model);
        }
    }
}