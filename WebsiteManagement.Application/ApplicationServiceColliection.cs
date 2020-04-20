using Microsoft.Extensions.DependencyInjection;
using WebsiteManagement.Application.Abstractions.Commands;
using WebsiteManagement.Application.Abstractions.Queries;
using WebsiteManagement.Application.Website.Commands.CreateWebsite;
using WebsiteManagement.Application.Websites.Commands.DeleteWebsite;
using WebsiteManagement.Application.Websites.Commands.UpdateWebsite;
using WebsiteManagement.Application.Websites.Queries.FetchWebsites;
using WebsiteManagement.Application.Websites.Queries.GetWebsite;
using WebsiteManagement.Application.Websites.Queries.FetchSiteCategories;
using System.Collections.Generic;

namespace WebsiteManagement.Application
{
	public static class ApplicationServiceColliection
	{
		public static void AddApplicationDependencies(this IServiceCollection services)
		{
			services.AddScoped<IQueryProcessor, QueryProcessor>();
			services.AddScoped<ICommandDispatcher, CommandDispatcher>();

			// query dependencies
			services.AddTransient<IHandleQuery<FetchWebsiteQuery, IEnumerable<FetchWebsiteDto>>, FetchWebsiteQueryHandler>();
			services.AddTransient<IHandleQuery<GetWebsiteQuery, GetWebsiteDto>, GetWebsiteQueryHandler>();
			services.AddTransient<IHandleQuery<SiteCategoryQuery, IEnumerable<SiteCategoryDto>>, SiteCategoryQueryHandler>();

			// command dependencies
			services.AddScoped<ICommandHandler<CreateWebsiteCommand>, CreateWebsiteCommandHandler>();
			services.AddScoped<ICommandHandler<DeleteWebsiteCommand>, DeleteWebsiteCommandHandler>();
			services.AddScoped<ICommandHandler<UpdateWebsiteCommand>, UpdateWebsiteCommandHandler>();
		}
	}
}
