using Portfolio.Site.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Site.Controllers
{
    public class CommentsController : Controller
    {
        private CommentsViewModel GetComments(ID id)
        {
            var project = Sitecore.Context.Database.GetItem(id);
            CommentsViewModel comments;
            var searchQuery = $".//*[@@templatename='Comment' and @Author!='']";
            try
            {
                var result = project.Axes.SelectItems(searchQuery)
                    .OrderBy(x => x.Fields["Date"].Value);
                comments = new CommentsViewModel(project.ID, result);
            }
            catch (Exception)
            {
                comments = new CommentsViewModel(id);
            }
            return comments;
        }
        public ActionResult Get()
        {
            CommentsViewModel comments = GetComments(RenderingContext.CurrentOrNull.PageContext.Item.ID);
            return View("~/Views/Renderings/Comments/Comments.cshtml", comments);
        }
        private void PublishItem(Item item)
        {
            Sitecore.Publishing.PublishOptions publishOptions =
              new Sitecore.Publishing.PublishOptions(item.Database,
                                                     Database.GetDatabase("web"),
                                                     Sitecore.Publishing.PublishMode.SingleItem,
                                                     item.Language,
                                                     System.DateTime.Now);
            Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);
            publisher.Options.RootItem = item;
            publisher.Options.Deep = true;
            publisher.Publish();
        }
        [HttpPost]
        [ValidateInput(false)]
        public PartialViewResult CreateComment(string comment, string id)
        {
            CommentsViewModel comments;
            Database master;
            TemplateItem template;
            Item parentItem;
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                master = Database.GetDatabase("master");
                template = master.GetTemplate(new ID("{D9993333-F7A9-4BA5-8205-EAB0D203510A}"));
                parentItem = master.GetItem(new ID(id));
                Item newItem = parentItem.Add("Comment", template);
                newItem.Editing.BeginEdit();
                try
                {
                    newItem.Fields["Author"].Value = "Anonymous";
                    newItem.Fields["Text"].Value = comment;
                    newItem.Fields["Date"].Value = Sitecore.DateUtil.IsoNowDate;
                    newItem.Editing.EndEdit();
                    PublishItem(newItem);
                }
                catch (System.Exception ex)
                {
                    newItem.Editing.CancelEdit();
                }
            }
            comments = GetComments(parentItem.ID);
            return PartialView("~/Views/Renderings/Comments/List.cshtml", comments);
        }
    }
}