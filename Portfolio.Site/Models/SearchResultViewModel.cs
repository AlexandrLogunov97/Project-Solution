using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class SearchResultViewModel
    {
        public ID ParentID { get; set; }
        public int NumberOfResults { get; set; }
        public Item[] Items { get; set; }
        public SearchResultViewModel()
        {
        }
        public SearchResultViewModel(ID parentID,int numberofResults, Item[] items)
        {
            NumberOfResults = numberofResults;
            Items = items;
            ParentID = parentID;
        }
    }
}