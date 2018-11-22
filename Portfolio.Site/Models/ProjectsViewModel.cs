using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class ProjectsViewModel
    {

        public List<ProjectViewModel> Projects { get; set; }
        public List<FacetViewModel> Categories { get; set; }
        public List<FacetViewModel> Tags { get; set; }
        public int CountPages { get; set; }
        public int CurrentPage { get; set; }

        public ProjectsViewModel()
        {
            CurrentPage = 1;
            Projects = new List<ProjectViewModel>();
            Categories = new List<FacetViewModel>();
            Tags = new List<FacetViewModel>();
        }
    }
}