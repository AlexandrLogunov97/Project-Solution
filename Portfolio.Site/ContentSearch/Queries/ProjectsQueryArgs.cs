using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.ContentSearch.Queries
{
    public class ProjectsQueryArgs
    {
        public ProjectsQueryArgs()
        {
            Page = 1;
            Size = 10;
            CountPages = 0;
        }

        public string Query { get; set; }
        public string[] Categories { get; set; }
        public string[] Tags { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int CountPages { get; set; }
        public string Language { get; set; }
    }
}