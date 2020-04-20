using WebsiteManagement.Application.Abstractions;
using WebsiteManagement.Application.Abstractions.Commands;
using WebsiteManagement.Application.Websites.Queries.FetchSiteCategories;
using System;
using EM = WebsiteManagement.Domain.Entities;

namespace WebsiteManagement.Application.Website.Commands.CreateWebsite
{
	public class CreateWebsiteCommand : ICommand
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public DateTime DateCreated { get; set; }
		public SiteCategoryDto Category { get; set; }
	}

	public class CreateWebsiteCommandHandler : ICommandHandler<CreateWebsiteCommand>
	{
		private readonly IContentManagementDbContext _dbContext;
		private ILoggerService _logger;

		public CreateWebsiteCommandHandler(IContentManagementDbContext dbContext, ILoggerService logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public void Handle(CreateWebsiteCommand command)
		{
			try
			{
				var website = new EM.Website();
				website.SetWebsite(command.Name, command.Url, command.DateCreated, command.Category.Id);
				
				_dbContext.Websites.Add(website);

				_dbContext.Commit();

				_logger.LogInfo($"Website created from CreateWebsiteCommand.");
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateWebsiteCommand: {ex.Message}");
				throw;
			}
		}
	}
}
