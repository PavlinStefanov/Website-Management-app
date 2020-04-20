using Microsoft.AspNetCore.Mvc;
using WebsiteManagement.Application.Abstractions.Commands;
using WebsiteManagement.Application.Website.Commands.CreateWebsite;
using WebsiteManagement.Application.Websites.Commands.DeleteWebsite;
using WebsiteManagement.Application.Websites.Commands.UpdateWebsite;

namespace WebsiteManagement.WebApi.Website.Commands
{
    [Produces("application/json")]
    [Route("api/websites")]
    public class WebsiteCommandController : ControllerBase
    {
		private readonly ICommandDispatcher _commandDispatcher;

		public WebsiteCommandController(ICommandDispatcher commandDispatcher)
		{
			_commandDispatcher = commandDispatcher;
		}

		[HttpPost("createWebsite")]
		public IActionResult CreateWebSite([FromBody] CreateWebsiteCommand command)
		{
			try
			{
				_commandDispatcher.DispatchCommand(command);

				return new OkObjectResult(StatusCode(200));
			}
			catch (System.Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPut("updateWebsite")]
		public IActionResult UpdateWebsite([FromBody] UpdateWebsiteCommand command)
		{
			try
			{
				_commandDispatcher.DispatchCommand(command);

				return new OkObjectResult(StatusCode(200));
			}
			catch (System.Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpDelete("deleteWebsite/{id}")]
		public IActionResult DeleteWebSite(int id)
		{
			try
			{
				_commandDispatcher.DispatchCommand(new DeleteWebsiteCommand(id));

				return new OkObjectResult(StatusCode(200));
			}
			catch (System.Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}
	}
}