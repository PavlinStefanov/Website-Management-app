using WebsiteManagement.Application.Abstractions;
using WebsiteManagement.Application.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebsiteManagement.Application.Common;
using System;
using WebsiteManagement.Application.Exceptions;

namespace WebsiteManagement.Application.Websites.Queries.GetWebsite
{
    public class GetWebsiteQuery : IQuery<GetWebsiteDto>
    {
        public GetWebsiteQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetWebsiteQueryHandler : IHandleQuery<GetWebsiteQuery, GetWebsiteDto>
    {
        private readonly IContentManagementDbContext _dbContext;
        private ILoggerService _logger;

        public GetWebsiteQueryHandler(IContentManagementDbContext dbContext, ILoggerService logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public GetWebsiteDto Execute(GetWebsiteQuery query)
        {
            try
            {
                var website = _dbContext.Websites
                    .Include(x => x.SiteCategory)
                    .SingleOrDefault(x => x.WebsiteId == query.Id);

                if (website == null)
                {
                    _logger.LogError($"Website with id: {query.Id}, hasn't been found in db.");
                    throw new EntityNotFoundException("Website", query.Id);
                }
                else
                {
                    _logger.LogInfo($"Returned website with id: {query.Id}");
                    return website.ToSigleDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetWebsiteQuery: {ex.Message}");
                throw;
            }
        }
    }
}
