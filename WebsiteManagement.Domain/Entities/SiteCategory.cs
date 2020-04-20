
using System.Collections.Generic;

namespace WebsiteManagement.Domain.Entities
{
    public class SiteCategory
    {
        public int SiteCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Website> Websites { get; set; }
    }
}
