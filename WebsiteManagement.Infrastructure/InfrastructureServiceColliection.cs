using Microsoft.Extensions.DependencyInjection;
using WebsiteManagement.Application.Abstractions;

namespace WebsiteManagement.Infrastructure
{
    public static class InfrastructureServiceColliection
    {
		public static void AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddSingleton<ILoggerService, LoggerService>();
		}
	}
}
