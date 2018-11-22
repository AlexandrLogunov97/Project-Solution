using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.ContentSearch.SearchTypes;

namespace Portfolio.Site.ContentSearch.SearchTypes
{
    public class ProjectSearchResultItem : SearchResultItem
    {
        [IndexField("name")]
        public string ProjectName { get; set; }

        [IndexField("description")]
        public string Description { get; set; }

        [IndexField("category")]
        public string Category { get; set; }

        [IndexField("tags")]
        public string[] Tags { get; set; }

        [IndexField("imageUrl")]
        public string ImageUrl { get; set; }

        [IndexField("itemUrl")]
        public string ItemUrl{ get; set; }
    }
}