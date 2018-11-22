using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class HeroBannerViewModel
    {
        public Sitecore.Data.Items.Item Image { get; set; }
        public HeroBannerViewModel() { }
        public HeroBannerViewModel(Sitecore.Data.Items.Item image)
        {
            Image = image;
        }
    }
}