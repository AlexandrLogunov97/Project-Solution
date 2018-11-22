using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class CommentViewModel
    {
        public string Author { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public CommentViewModel()
        {
        }
        public CommentViewModel(Item item)
        {
            Author = item.Fields["Author"].Value;
            Date = ((DateField)item.Fields["Date"]).DateTime.ToShortDateString();
            Text = item.Fields["Text"].Value;
        }
        public CommentViewModel(string author, string date, string text)
        {
            Author = author;
            Date = date;
            Text = text;
        }
    }
}