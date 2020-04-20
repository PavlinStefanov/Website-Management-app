using WebsiteManagement.Application.Abstractions;
using WebsiteManagement.Application.Abstractions.Commands;
using System;
using WebsiteManagement.Application.Exceptions;

namespace WebsiteManagement.Application.Websites.Commands.DeleteWebsite
{
	public class DeleteWebsiteCommand : ICommand
	{
		public DeleteWebsiteCommand(int id)
		{
			Id = id;
		}
		public int Id { get; }
	}

	public class DeleteWebsiteCommandHandler : ICommandHandler<DeleteWebsiteCommand>
	{
		private readonly IContentManagementDbContext _dbContext;
		private ILoggerService _logger;
		public DeleteWebsiteCommandHandler(IContentManagementDbContext dbContext, ILoggerService logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public void Handle(DeleteWebsiteCommand command)
		{
			try
			{
				var entity = _dbContext.Websites.Find(command.Id);
				if (entity == null)
				{
					_logger.LogError($"Not found website with {command.Id} from DeleteWebsiteCommand.");
					throw new EntityNotFoundException("Website", command.Id);
				}
				else
				{
					_dbContext.Websites.Remove(entity);
					_dbContext.Commit();

					_logger.LogInfo($"Website with id: {command.Id} deleted successfully.");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateWebsiteCommand: {ex.Message}");
				throw;
			}
		}
	}
}
