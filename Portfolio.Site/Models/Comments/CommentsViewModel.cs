using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class CommentsViewModel
    {
        public ID ProjectID { get; set; }
        public List<CommentViewModel> Commnets { get; set; }
        public CommentsViewModel(ID id)
        {
            ProjectID = id;
            Commnets = new List<CommentViewModel>();
        }
        public CommentsViewModel(ID projectID, IEnumerable<Item> items)
        {
            Commnets = new List<CommentViewModel>();
            ProjectID = projectID;
            items.ToList().ForEach(x => Commnets.Add(new CommentViewModel(x)));
        }
    }
}