using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StartUp.Confluence.Model;
using StartUp.Confluence.Model.Entities.Confluence;
using StartUp.Confluence.Repository.Extension;
using StartUp.Confluence.Repository.Shared;
using StartUp.Confluence.Service.Collections;
using StartUp.Confluence.Service.Extension;
using StartUp.Confluence.Service.Shared.Confluence;
using StartUp.Confluence.UnitOfWork.Shared;
using Swashbuckle.AspNetCore.Swagger;

namespace StartUp.Confluence.Api
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConfluenceDBContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("ConfluenceDBContext"),
                                    b => b.MigrationsAssembly("StartUp.Confluence.Model")));

            _logger.LogInformation("Added ConfluenceDBContext to DbContext");


            services.AddUnitOfWork<ConfluenceDBContext>();

            //add DI service
            services.AddServicesInstance();

            //add DI Repositories
            services.AddRepositoriesInstance();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Confluence API", Version = "v1" });
            });

            // Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                          builder =>
                          {
                              builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                          });
            });
        }    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {

            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RMX API V1");
            });


        app.UseCors("AllowAllOrigins");


        app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
