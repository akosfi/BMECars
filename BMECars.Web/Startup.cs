using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BMECars.Dal;
using BMECars.Dal.Managers;
using BMECars.Dal.Entities;
using BMECars.Dal.EntityConfigurations;
using System;
using BMECars.Dal.SeedService;

namespace BMECars.Web
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
            services.AddDbContext<BMECarsDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString(nameof(BMECarsDbContext))));
            
            services.AddDefaultIdentity<User>().AddEntityFrameworkStores<BMECarsDbContext>();


            services.AddTransient<ICarManager, CarManager>();
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddTransient<ICompanyManager, CompanyManager>();

            services.AddScoped<IEntityTypeConfiguration<Company>, CompanyEntityConfiguration>()
                .AddScoped(provider => new Lazy<IEntityTypeConfiguration<Company>>(() => provider.GetService<IEntityTypeConfiguration<Company>>()))
                .AddScoped<IEntityTypeConfiguration<Car>, CarEntityConfiguration>()
                .AddScoped(provider => new Lazy<IEntityTypeConfiguration<Car>>(() => provider.GetService<IEntityTypeConfiguration<Car>>()))
                .AddScoped<IEntityTypeConfiguration<Location>, LocationEntityConfiguration>()
                .AddScoped(provider => new Lazy<IEntityTypeConfiguration<Location>>(() => provider.GetService<IEntityTypeConfiguration<Location>>()))
                .AddScoped<IEntityTypeConfiguration<User>, UserEntityConfiguration>()
                .AddScoped(provider => new Lazy<IEntityTypeConfiguration<User>>(() => provider.GetService<IEntityTypeConfiguration<User>>()))
                .AddScoped<IEntityTypeConfiguration<Reservation>, ReservationEntityConfiguration>()
                .AddScoped(provider => new Lazy<IEntityTypeConfiguration<Reservation>>(() => provider.GetService<IEntityTypeConfiguration<Reservation>>())); ;

            services.AddScoped<ISeedService, SeedService>()
                .AddScoped(provider => new Lazy<ISeedService>(() => provider.GetService<ISeedService>()));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
