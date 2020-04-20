using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebsiteManagement.Application.Websites.Queries.FetchSiteCategories;
using WebsiteManagement.Application.Websites.Queries.FetchWebsites;
using WebsiteManagement.Application.Websites.Queries.GetWebsite;

namespace WebsiteManagement.Application.Common
{
	public static class SharedResourcesExtensionMethods
	{
		public static IEnumerable<FetchWebsiteDto> ToDtoList(this IQueryable<Domain.Entities.Website> webSites)
		{
			return webSites.Include(x => x.SiteCategory).Select(x => new FetchWebsiteDto
			{
				Id = x.WebsiteId,
				Name = x.Name,
				Url = x.Url,
				DateCreated = x.DateCreated,
				Category = new SiteCategoryDto
				{
					Id = x.SiteCategoryId,
					Name = x.SiteCategory.Name
				}
			});
		}

		public static IEnumerable<SiteCategoryDto> ToDtoList(this IEnumerable<Domain.Entities.SiteCategory> categories)
		{
			return categories.Select(x => new SiteCategoryDto
			{
				Id = x.SiteCategoryId,
				Name = x.Name
			});
		}

		public static GetWebsiteDto ToSigleDto(this Domain.Entities.Website website)
		{
			var singleWebsite = new GetWebsiteDto
			{
				Id = website.WebsiteId,
				Name = website.Name,
				Url = website.Url,
				DateCreated = website.DateCreated,
				Category = new SiteCategoryDto
				{
					Id = website.SiteCategoryId,
					Name = website.SiteCategory.Name
				}
			};
			return singleWebsite;
		}
	}
}
