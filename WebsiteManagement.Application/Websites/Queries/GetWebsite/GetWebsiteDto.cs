using WebsiteManagement.Application.Websites.Queries.FetchSiteCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteManagement.Application.Websites.Queries.GetWebsite
{
    public class GetWebsiteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
        public SiteCategoryDto Category { get; set; }
    }
}
