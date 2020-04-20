using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebsiteManagement.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using WebsiteManagement.Application.Abstractions;
using Microsoft.AspNetCore.Identity;
using WebsiteManagement.Domain.Entities;
using WebsiteManagement.Infrastructure;

namespace WebsiteManagement.Persistence
{
    public static class PersistenceServiceCollection
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
        {
            // Dependencies for MSSQL Server
            //IConfigurationRoot _settingsBuilder = ConfigurationSettingsBuilder.GetSettingsFile();
            //var connection = _settingsBuilder["ConnectionStrings:ContentManagementConnectionString"];
            //services.AddEntityFrameworkSqlServer();
            //services.AddDbContext<ContentManagementDbContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<ContentManagementDbContext>(options => options.UseInMemoryDatabase(databaseName: "WebsiteDb"));
        
            services.AddTransient<IContentManagementDbContext, ContentManagementDbContext>();

            return services;
        }
    }
}
