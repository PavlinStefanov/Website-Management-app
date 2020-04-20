using System;
using System.Collections.Generic;
using System.Text;
using EM = WebsiteManagement.Domain.Entities;

namespace WebsiteManagement.Application
{
    public class DataInitializer
    {
        public static IEnumerable<EM.Website> CreateWebsites()
        {
            var websites = new List<EM.Website>()
            {
                new EM.Website{ Name = "Stackowerflow",  Url = "https://stackowerflou.com", SiteCategoryId = 2, DateCreated = DateTime.Now},
                new EM.Website{ Name = "Google",  Url = "https://google.com", SiteCategoryId = 2, DateCreated = DateTime.Now},
                new EM.Website{ Name = "Microsoft",  Url = "https://microsorf.com", SiteCategoryId = 1, DateCreated = DateTime.Now},
                new EM.Website{ Name = "Ancora software",  Url = "https://ancorasoftware.com", SiteCategoryId = 3, DateCreated = DateTime.Now},
                new EM.Website{ Name = "Bulpros",  Url = "https://bulpros.bg", SiteCategoryId = 3, DateCreated = DateTime.Now}
            };

            return websites;
        }

        public static IEnumerable<EM.SiteCategory> CreateCategories()
        {
            var categories = new List<EM.SiteCategory>()
            {
                new EM.SiteCategory{ Name = "Business"},
                new EM.SiteCategory{ Name = "Social"},
                new EM.SiteCategory{ Name = "Corporation"},
            };

            return categories;
        }
    }
}
