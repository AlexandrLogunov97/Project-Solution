using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class SliderViewModel
    {
        private Item[] images;
        public Sitecore.Data.Items.Item First { get; set; }
        public string Speed { get; set; }
        [SitecoreField("Images")]
        public Sitecore.Data.Items.Item[] Images
        {
            get
            {
                return images;
            }
            set
            {
                First = value.ToList().Take(1).First();
                images = value.ToList().Skip(1).ToArray();
            }
        }

        public SliderViewModel() {}
        public SliderViewModel(Sitecore.Data.Items.Item[] images, string speed="3")
        {
            Images = images;
            Speed = speed;
        }
    }
}