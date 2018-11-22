using Portfolio.Site.ContentSearch.Queries;
using Portfolio.Site.ContentSearch.SearchTypes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Data.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Portfolio.Site.ContentSearch.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        public string IndexName { get; set; } = $"pf_{Sitecore.Context.Database.Name.ToLower()}_index";

        private ISearchIndex _index;

        private ISearchIndex Index => _index ?? (_index = ContentSearchManager.GetIndex(IndexName));

        private IProviderSearchContext _context;

        private IProviderSearchContext Context => _context ?? (_context = Index.CreateSearchContext());

        public SearchResults<ProjectSearchResultItem> Get(ProjectsQueryArgs args)
        {
            var searchPredicate = PredicateBuilder.True<ProjectSearchResultItem>();
            if (!string.IsNullOrEmpty(args.Query))
            {
                searchPredicate = searchPredicate.And(x => x.ProjectName.Contains(args.Query));
            }
            if (args.Categories!=null)
            {
                searchPredicate = searchPredicate.And(x => args.Categories.Contains(x.Category));
            }
            if(args.Tags!=null)
            {
                foreach (var tag in args.Tags)
                {
                    searchPredicate = searchPredicate.And(x => x.Tags.Contains(tag));
                }
            }
            var result = Context.GetQueryable<ProjectSearchResultItem>()
                .Where(searchPredicate)
                .FacetOn(x => x.Category, 0)
                .FacetOn(x => x.Tags, 0)
                .Page(args.Page - 1, args.Size)
                .GetResults();
            return result;
        }
    }
}