using WebsiteManagement.Application.Abstractions;
using WebsiteManagement.Application.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebsiteManagement.Application.Common;
using WebsiteManagement.Application.Exceptions;

namespace WebsiteManagement.Application.Websites.Queries.FetchWebsites
{
	public class FetchWebsiteQuery : IQuery<IEnumerable<FetchWebsiteDto>>
	{
	}

	public class FetchWebsiteQueryHandler : IHandleQuery<FetchWebsiteQuery, IEnumerable<FetchWebsiteDto>>
	{
		private readonly IContentManagementDbContext _dbContext;
		private ILoggerService _logger;
		public FetchWebsiteQueryHandler(IContentManagementDbContext dbContext, ILoggerService logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}
		public IEnumerable<FetchWebsiteDto> Execute(FetchWebsiteQuery query)
		{
			try
			{
				if (!_dbContext.Websites.Any())
				{
					_logger.LogError($"Empty Websites collection from FetchWebsitesQuery.");
					throw new EmptyCollectionException("Websites");
				}
				else
				{
					_logger.LogInfo($"Returned Websites collection from FetchWebsitesQuery.");
					return _dbContext.Websites.ToDtoList();
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError($"Something went wrong inside FetchWebsitesQuery: {ex.Message}");
				throw;
			}	
		}
	}
}
