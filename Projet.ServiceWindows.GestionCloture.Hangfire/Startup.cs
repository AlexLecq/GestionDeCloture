using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using Hangfire.MySql;
using Hangfire.MySql.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Projet.ServiceWindows.GestionCloture.Hangfire
{
    public class Startup
    {

        public IConfiguration config;

        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddHangfire((n) => 
            {

                n.UseStorage(new MySqlStorage(config.GetConnectionString("MySqlConnection")));
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            List<IDashboardAuthorizationFilter> filters = new List<IDashboardAuthorizationFilter>();
            filters.Add(new DontUseThisAuthorizationFilter());
            app.UseHangfireDashboard("/hangfire", new DashboardOptions { Authorization = filters });

            var options = new BackgroundJobServerOptions
            {
                Queues = new[] { "critical", "default" },
                WorkerCount = 3
            };
            app.UseHangfireServer(options);

            app.UseMvc();

        }
    }

    public class DontUseThisAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
