using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobSolution.Services.Concrete;
using JobSolution.Services.Interfaces;
using JobSolution.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JobSolution.Domain.Auth;
using Microsoft.AspNetCore.Mvc.Authorization;
using JobSolution.Infrastructure.Extensions;
using JobSolution.Repository.Interfaces;
using JobSolution.Repository.Concrete;
using JobSolution.SignalR.Concrete;
using JobSolution.Infrastructure.Middleware;
using JobSolution.Infrastructure.Seed;

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

            services.AddMvc();
            services.AddSignalR();
            services.AddCors(options => options.AddPolicy("Cors", builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Job API",
                        Version = "v1"
                    });
            });

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryServices>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IAdvertServices, AdvertServices>();
            services.AddTransient<IAdvertRepository, AdvertRepository>();
            services.AddTransient<IJobTypeRepository, TypeJobRepository>();
            services.AddTransient<ITypeJobService, TypeJobServices>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IStudentJobService, StudentJobService>();
            services.AddTransient<IStudentJobRepository, StudentJobRepository>();
            services.AddTransient<IRepositoryImage, RepositoryImage>();
            services.AddTransient<IServiceImage, ServiceImage>();




            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddIdentity<User, Role>(opts =>
            {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddRoleManager<RoleManager<Role>>();


            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtAuthentication(authOptions);

            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("Cors");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Job API");
                options.RoutePrefix = "swagger";
            });

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {

                endpoints.MapHub<Chat>("/chat");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                 );
                ;
            });

            app.UseSpa(spa =>
            {
                string strategy = Configuration
                .GetValue<string>("DevTools:ConnectionStrategy");
                if (strategy == "proxy")
                {
                    spa.UseProxyToSpaDevelopmentServer("http://127.0.0.1:4200");
                }
            });


            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                using (var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {
                    if (!dbContext.Profiles.Any())
                    {
                        dbContext.Database.Migrate();
                        DbSeeder.Seed(dbContext, roleManager, userManager);
                        dbContext.SaveChanges();
                    }
                }
            }



            //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();
            //    var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

            //    var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
            //   dbContext.Database.Migrate();
            //   Seeder.Populate(dbContext, roleManager, userManager).GetAwaiter().GetResult();

            //}

        }
    }
}
