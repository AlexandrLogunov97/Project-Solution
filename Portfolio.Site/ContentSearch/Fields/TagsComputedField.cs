using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Portfolio.Site.ContentSearch.Fields
{
    public class TagsComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, nameof(indexable));

            if (indexable is SitecoreIndexableItem indexableItem)
            {
                using (new LanguageSwitcher(Sitecore.Context.Language.Name))
                {
                    MultilistField field = indexableItem.Item.Fields["Tags"];
                    var items = field.GetItems();
                    return items.Select(x => x.Fields["Value"].Value);

                }
            }
            return null;

        }
    }
}