using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Annotations;
using Hangfire.Common;
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
    /// <summary>
    /// Classe de configuration du service Hangfire
    /// </summary>
    public class Startup
    {

        public IConfiguration config;
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }
        
        /// <summary>
        /// Configuration du service Hangfire
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire((n) => n.UseStorage(new MySqlStorage(config.GetConnectionString("ConnectToHangfire"))));
            services.AddMvc();
        }

        /// <summary>
        /// Configuration de l'environnement
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            List<IDashboardAuthorizationFilter> filters = new List<IDashboardAuthorizationFilter>();
            filters.Add(new DontUseThisAuthorizationFilter());
            app.UseHangfireDashboard("/hangfire", new DashboardOptions { Authorization = filters });

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
