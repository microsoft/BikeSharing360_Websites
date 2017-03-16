using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using BikeSharing.Web.Configuration;
using BikeSharing.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BikeSharing.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuration Settings:
            services.AddOptions();
            services.Configure<Links>(Configuration.GetSection("Links"));
            services.AddDbContext<BikeSharingContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddTransient<ICitiesService, CitiesService>();

            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            // Add framework services.
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options =>
            {
                options.ResourcesPath = "Resources";
            });

        }

        private void SeedData(IApplicationBuilder app)
        {
            var dbContext = app.ApplicationServices.GetRequiredService<BikeSharingContext>();
	    dbContext.Database.EnsureCreated();

            if (!dbContext.Cities.Any())
            {
                dbContext.Cities.Add(new City()
                {
                    Initial = false,
                    Name="NewYork",
                    LocalizedName="New York",
                    IsAvailable=true
                });

                dbContext.Cities.Add(new City()
                {
                    Initial = true,
                    Name = "Seattle",
                    IsAvailable = true
                });

                dbContext.Cities.Add(new City()
                {
                    Initial = false,
                    Name = "SanFrancisco",
                    LocalizedName = "San Francisco",
                    IsAvailable = false
                });

                dbContext.Cities.Add(new City()
                {
                    Initial = false,
                    Name = "Boston",
                    IsAvailable = false
                });

                dbContext.Cities.Add(new City()
                {
                    Initial = false,
                    Name = "Barcelona",
                    IsAvailable = false
                });


                dbContext.Cities.Add(new City()
                {
                    Initial = false,
                    Name = "MexicoCity",
                    LocalizedName = "Mexico",
                    IsAvailable = false
                });

                dbContext.SaveChanges();


            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        { 
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseCors(pb => pb.AllowAnyHeader());
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData(app);
        }
    }
}
