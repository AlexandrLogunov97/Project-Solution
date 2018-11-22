using Sitecore.Collections;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class NavigationViewModel
    { 
        public List<Item> NavigationItems { get; set; }
        public Item Root { get; set; }
        public NavigationViewModel(){}
        public NavigationViewModel(IEnumerable<Item> items,Item root)
        {
            NavigationItems = items.ToList();
            Root = root;
        }
    }
}