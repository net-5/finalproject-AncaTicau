using Conference.Constants;
using Conference.Data;
using Conference.Domain.Entities;
using Conference.Interfaces;
using Conference.Service;
using Conference.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Conference
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ConferenceContext>();

            services.AddScoped<IEditionRepository, EditionRepository>();
            services.AddScoped<IEditionService, EditionService>();

            services.AddScoped<ISpeakersRepository, SpeakersRepository>();
            services.AddScoped<ISpeakerService, SpeakerService>();

            services.AddScoped<ITalksRepository, TalksRepository>();
            services.AddScoped<ITalkService, TalkService>();

            services.AddScoped<IWorkshopRepository, WorkshopRepository>();
            services.AddScoped<IWorkshopService, WorkshopService>();

            services.AddScoped<ISponsorsRepository, SponsorsRepository>();
            services.AddScoped<ISponsorService, SponsorService>();

            services.AddScoped<ISponsorTypesRepository, SponsorTypesRepository>();
            services.AddScoped<ISponsorTypeService, SponsorTypeService>();

            services.AddScoped<ISpeakerAppService, SpeakerAppService>();
            services.AddScoped<IWorkshopAppService, WorkshopAppService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes
                    .MapRoute(
                        name: "areaRoute",
                        template: "{area:exists}/{controller}/{action}/{id?}",
                        defaults: new { area = "Admin", controller = "Home", action = "Index" }
                    )
                    .MapRoute(
                        name: RouteName.Details,
                        template: "{controller}/{id:int}",
                        defaults: new { action = "Details" }
                    )
                    .MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}