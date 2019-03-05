using Hangfire;
using Hangfire.MySql.Core;
using Projet.ServiceWindows.GestionCloture.Tools;
using Projet.ServiceWindows.GestionCloture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Projet.ServiceWindows.GestionCloture
{
    public partial class GestionCloture : ServiceBase
    {
        public BackgroundJobServer server;

        public GestionCloture()
        {
            InitializeComponent();

            //Configuration du Hangfire
            GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString));

        }

        protected override void OnStart(string[] args)
        {
            //Configuration des options pour le serveur de job d'Hangfire
            var options = new BackgroundJobServerOptions
            {
                ServerName = "GestionCloture.Hangfire",
                Queues = new[] { "critical", "default" },
                WorkerCount = 3
            };
            server = new BackgroundJobServer(options);

        }

        protected override void OnStop()
        {
            server.Dispose();
        }

    }
}
