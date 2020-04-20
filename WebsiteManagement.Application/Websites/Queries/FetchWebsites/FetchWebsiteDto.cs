using WebsiteManagement.Application.Websites.Queries.FetchSiteCategories;
using System;

namespace WebsiteManagement.Application.Websites.Queries.FetchWebsites
{
	public class FetchWebsiteDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public DateTime DateCreated { get; set; }
		public SiteCategoryDto Category { get; set; }
	}
}
