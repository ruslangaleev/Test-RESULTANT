using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StandCurrencies.Services.Infrastructure;
using StandCurrencies.Services.Interfaces;
using StandCurrencies.Services.Logic;

namespace StandCurrencies
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
            services.AddScoped<IPhisixClient, PhisixClient>();

            services.AddMvc();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSignalR(route =>
            {
                route.MapHub<SignalServer>("/signalServer");
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            new Reminder(serviceProvider.GetRequiredService<IHubContext<SignalServer>>(),
                serviceProvider.GetRequiredService<IConfiguration>()).Start();
        }
    }
}
