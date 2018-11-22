using Portfolio.Site.ContentSearch.Queries;
using Portfolio.Site.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Site.ContentSearch.Repositories
{
    public interface IProjectsRepository
    {
        SearchResults<ProjectSearchResultItem> Get(ProjectsQueryArgs args);
        string IndexName { get; set; }
    }
}
