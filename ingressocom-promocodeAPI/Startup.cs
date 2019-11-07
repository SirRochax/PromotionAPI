using ingressocom_promocodeAPI.AppConfig;
using ingressocom_promocodeAPI.Repositories;
using ingressocom_promocodeAPI.Repositories.Interface;
using ingressocom_promocodeAPI.Services;
using ingressocom_promocodeAPI.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ingressocom_promocodeAPI
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
            services.AddTransient<ITheatreService, TheatreService>();
            services.AddTransient<IPromotionService, PromotionService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IPromotionRepository, PromotionRepository>();
            services.AddTransient<IPromocodeRepository, PromocodeRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITheatreRepository, TheatreRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
