using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteManagement.Application.Abstractions.Queries;
using WebsiteManagement.Application.Websites.Queries.FetchWebsites;
using WebsiteManagement.Application.Websites.Queries.GetWebsite;
using WebsiteManagement.Application.Websites.Queries.FetchSiteCategories;
using WebsiteManagement.Application.Abstractions;

namespace WebsiteManagement.WebApi.Website.Queries
{
    [Produces("application/json")]
    [Route("api/websites")]
    public class WebsiteQueryController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

		public WebsiteQueryController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

		[HttpGet("fetchWebsites")]
		public IActionResult FetchWebsites()
		{
			try
			{
				var websites = _queryProcessor.Process(new FetchWebsiteQuery());
				return new OkObjectResult(websites);
			}
			catch (System.Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("getWebsite/{id}")]
		public IActionResult GetWebsiteById(int id)
		{
			try
			{
				var result = _queryProcessor.Process(new GetWebsiteQuery(id));
				return new OkObjectResult(result);
			}
			catch (System.Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("fetchSiteCategories")]
		public IActionResult FetchSiteCategories()
		{
			try
			{
				var result = _queryProcessor.Process(new SiteCategoryQuery());
				return new OkObjectResult(result);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}
	}
}