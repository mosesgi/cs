using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Packt.Shared;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

using static System.Console;
using NorthwindService.Repositories;

using Microsoft.AspNetCore.Http;        //getEndpoint() extension method
using Microsoft.AspNetCore.Routing;     //RouteEndpoint

namespace NorthwindService
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
            services.AddCors();
            string databasePath = Path.Combine("..", "..", "db", "Northwind.db");
            services.AddDbContext<Northwind>(options => options.UseSqlite($"Data Source={databasePath}"));

            services.AddControllers(options =>
            {
                WriteLine("Default output formatters:");
                foreach (IOutputFormatter formatters in options.OutputFormatters)
                {
                    var mediaFormatter = formatters as OutputFormatter;
                    if (mediaFormatter == null)
                    {
                        WriteLine($" formmater.GetType().Name");
                    }
                    else
                    {
                        WriteLine(" {0}, Media types: {1}", mediaFormatter.GetType().Name, string.Join(", ", mediaFormatter.SupportedMediaTypes));
                    }
                }
            })
            .AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Northwind Service API", Version = "v1" });
            });

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            //health check
            services.AddHealthChecks().AddDbContextCheck<Northwind>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind Service API v1");
                    c.SupportedSubmitMethods(new[] {SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete});
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            //must be after UseRouting and before UseEndpoints
            app.UseCors(configurePolicy: options =>
            {
                options.WithMethods("GET", "POST", "PUT", "DELETE");
                options.WithOrigins(
                    "https://localhost:5002"    //for MVC client
                );
            });

            app.Use(next => (context) =>{
                var endpoint = context.GetEndpoint();
                if (endpoint != null)
                {
                    WriteLine("*** Name: {0}; Route: {1}; Metadata: {2}",
                        endpoint.DisplayName,
                        (endpoint as RouteEndpoint)?.RoutePattern,
                        string.Join(", ", endpoint.Metadata));
                }
                //pass context to next middleware in pipeline
                return next(context);
            });
            app.UseMiddleware<SecurityHeaders>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //health check
            app.UseHealthChecks(path: "/howdoyoufeel");
        }
    }
}
