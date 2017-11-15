using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace SwaggerSamples
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
			services
				.AddSwaggerGen(o =>
				{
					o.SchemaFilter<SampleFilter>();
					o.SwaggerDoc("v1", new Info { Title = "SwaggerSamples", Version = "v1" });
				})
				.AddMvcCore()
				.AddFormatterMappings()
				.AddJsonFormatters()
				.AddApiExplorer();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc()
				.UseSwagger(o => { })
				.UseSwaggerUI(o =>
				{
					o.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerSamples V1");
				});
		}
	}
}
