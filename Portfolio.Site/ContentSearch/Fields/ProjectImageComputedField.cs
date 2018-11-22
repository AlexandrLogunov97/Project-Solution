using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Portfolio.Site.ContentSearch.Fields
{
    public class ProjectImageComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, nameof(indexable));

            if (indexable is SitecoreIndexableItem indexableItem)
            {
                ImageField field = indexableItem.Item.Fields["Image"];
                string imageUrl=String.Empty;
                if (field?.MediaItem != null)
                {
                    var image = new MediaItem(field.MediaItem);
                    imageUrl = MediaManager.GetMediaUrl(image,new MediaUrlOptions() {AbsolutePath=false  });
                }
                return imageUrl;
            }
            return null;

        }
    }
}