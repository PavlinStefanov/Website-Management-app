using WebsiteManagement.Application.Abstractions;
using WebsiteManagement.Application.Abstractions.Queries;
using System.Collections.Generic;
using WebsiteManagement.Application.Common;
using System.Linq;
using WebsiteManagement.Application.Exceptions;

namespace WebsiteManagement.Application.Websites.Queries.FetchSiteCategories
{
    public class SiteCategoryQuery : IQuery<IEnumerable<SiteCategoryDto>>
    {
    }

    public class SiteCategoryQueryHandler : IHandleQuery<SiteCategoryQuery, IEnumerable<SiteCategoryDto>>
    {
        private readonly IContentManagementDbContext _dbContext;
        private ILoggerService _logger;

        public SiteCategoryQueryHandler(IContentManagementDbContext dbContext, ILoggerService logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<SiteCategoryDto> Execute(SiteCategoryQuery query)
        {
            try
            {
                if (!_dbContext.SiteCategories.Any())
                {
                    _logger.LogError($"Empty SiteCategories collection from SiteCategoryQuery.");
                    throw new EmptyCollectionException("SiteCategories");
                }
                else
                {
                    _logger.LogInfo($"Returned SiteCategories collection from SiteCategoryQuery.");
                    return _dbContext.SiteCategories.ToDtoList();
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Something went wrong inside SiteCategoryQuery: {ex.Message}");
                throw;
            }
        }
    }
}
