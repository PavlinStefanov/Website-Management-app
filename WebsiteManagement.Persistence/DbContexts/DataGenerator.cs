using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebsiteManagement.Application;

namespace WebsiteManagement.Persistence.DbContexts
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContentManagementDbContext(serviceProvider.GetRequiredService<DbContextOptions<ContentManagementDbContext>>()))
            {
                if (!context.SiteCategories.Any())
                {
                    context.SiteCategories.AddRange(DataInitializer.CreateCategories());
                    context.Commit();
                }

				if (!context.Websites.Any())
				{
                    context.Websites.AddRange(DataInitializer.CreateWebsites());
                    context.Commit();
				}
			}
        }
    }
}
