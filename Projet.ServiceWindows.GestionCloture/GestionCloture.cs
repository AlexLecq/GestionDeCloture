using Hangfire;
using Hangfire.MySql.Core;
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
using Microsoft.Owin.Hosting;
using Microsoft.Extensions.Configuration;
using Projet.ServiceWindows.GestionCloture.Classe;
using Projet.ServiceWindows.GestionCloture.Controllers;
using System.Timers;
using Projet.ServiceWindows.GestionCloture.Services;
using Hangfire.Common;

namespace Projet.ServiceWindows.GestionCloture
{
    public partial class GestionCloture : ServiceBase
    {
        private BackgroundJobServer _server;
        public static MySqlServiceController _myAccess;
        private TimerService _timer;


        public GestionCloture()
        {
            InitializeComponent();

            //Configuration du Hangfire
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
            
            GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(ConfigurationManager.ConnectionStrings["ConnectToHangfire"].ConnectionString));
            _myAccess = MySqlServiceController.GetInstance(ConfigurationManager.ConnectionStrings["ConnectToGsbFrais"].ConnectionString);
            _timer = new TimerService(new TimeSpan(0,0,30));
        }

        protected override void OnStart(string[] args)
        {

            //Configuration des options pour le serveur de job d'Hangfire
            var options = new BackgroundJobServerOptions
            {
                ServerName = "GestionClotureHangfire",
                Queues = new[] { "critical", "default" },
                WorkerCount = 1
                
            };
            _server = new BackgroundJobServer(options);

            _timer.Start();
        }

        protected override void OnStop()
        {
            _server.Dispose();
            _timer.Stop();
        }

        
    }


}
