using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebsiteManagement.Application;
using WebsiteManagement.Infrastructure;
using WebsiteManagement.Persistence;
using System.Linq;
using System.Reflection;

namespace WebsiteManagement.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddApplicationDependencies();
			services.AddPersistenceDependencies();
			services.AddInfrastructureDependencies();

			services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
			{
				builder
				//.AllowAnyMethod()
				//.AllowAnyHeader()
				//.AllowCredentials()
				.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
			}));

			services.AddControllers();

			// Customise default API behavour
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors("CorsPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
