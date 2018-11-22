using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Site.Models
{
    public class ProjectDetailsViewModel
    {
        [SitecoreField("Name")]
        public virtual string Name { get; set; }
        [SitecoreField("Description")]
        public virtual string Description { get; set; }
        [SitecoreField("Image")]
        public virtual Image Image { get; set; }
    }
}