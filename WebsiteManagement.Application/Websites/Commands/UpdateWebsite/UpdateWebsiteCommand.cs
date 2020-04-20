using WebsiteManagement.Application.Abstractions;
using WebsiteManagement.Application.Abstractions.Commands;
using WebsiteManagement.Application.Websites.Queries.FetchSiteCategories;
using System;
using WebsiteManagement.Application.Exceptions;

namespace WebsiteManagement.Application.Websites.Commands.UpdateWebsite
{
	public class UpdateWebsiteCommand : ICommand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public DateTime DateCreated { get; set; }
		public SiteCategoryDto Category { get; set; }
	}

	public class UpdateWebsiteCommandHandler : ICommandHandler<UpdateWebsiteCommand>
	{
		private readonly IContentManagementDbContext _dbContext;
		private ILoggerService _logger;
		public UpdateWebsiteCommandHandler(IContentManagementDbContext dbContext, ILoggerService logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}
		public void Handle(UpdateWebsiteCommand command)
		{
			try
			{
				var entity = _dbContext.Websites.Find(command.Id);
				if (entity == null)
				{
					_logger.LogError($"Not found website with {command.Id} from UpdateWebsiteCommand.");
					throw new EntityNotFoundException("Website", command.Id);
				}
				else
				{
					entity.SetWebsite(command.Name, command.Url, command.DateCreated, command.Category.Id);
					_dbContext.Websites.Update(entity);

					_dbContext.Commit();

					_logger.LogInfo($"Website with id: {command.Id} updated successfully.");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateWebsiteCommand: {ex.Message}");
				throw;
			}
		}
	}
}
