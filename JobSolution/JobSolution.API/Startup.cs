using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.Mvc.Formatters;
using JobSolution.Repository;
using JobSolution.Services.Concrete;
using JobSolution.Services.Interfaces;
using JobSolution.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace JobSolution.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options => options.AddPolicy("Cors", builder =>
                   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddMvc();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Job API",
                        Version = "v1"
                    });
            });
           // services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<JobDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IJobService, JobService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("Cors");
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Job API");
                options.RoutePrefix = "swagger";
            });
            
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                 );
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa => {
                string strategy = Configuration
                .GetValue<string>("DevTools:ConnectionStrategy");
                if (strategy == "proxy")
                {
                    spa.UseProxyToSpaDevelopmentServer("http://127.0.0.1:4200");
                }
                else if (strategy == "managed")
                {
                   
              spa.Options.SourcePath = @"D:\AmdarisProjectDB\ClientUI";
                    spa.UseAngularCliServer("start");
                }
            });


        }
    }
}
