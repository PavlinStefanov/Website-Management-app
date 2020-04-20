using System;
using System.Collections.Generic;
using WebsiteManagement.Domain.Exceptions;
using WebsiteManagement.Domain.ValueObjects;

namespace WebsiteManagement.Domain.Entities
{
	public class Website
	{
		public Website()
		{
			MediaTypes = new HashSet<MediaType>();
		}
		public int WebsiteId { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public int SiteCategoryId { get; set; }
		public SiteCategory SiteCategory { get; set; }
		public virtual ICollection<MediaType> MediaTypes { get; set; }
		public DateTime DateCreated { get; set; }

		public void SetWebsite(string name, string url, DateTime dateCreated, int siteCategoryId)
		{
			try
			{
				if (url.IsValidUrl())
				{
					Name = name;
					Url = url;
					DateCreated = dateCreated;
					SiteCategoryId = siteCategoryId;
				}
				else
				{
					throw new Exception();
				}
			}
			catch (Exception ex)
			{
				throw new CreateUrlException(url, ex);
			}
		}
	}
}
