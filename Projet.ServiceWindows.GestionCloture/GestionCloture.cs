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

namespace Projet.ServiceWindows.GestionCloture
{
    public partial class GestionCloture : ServiceBase
    {
        public BackgroundJobServer _server;
        public MySqlServiceController _myAccess;
        public UpdateFicheController _updater;


        public GestionCloture()
        {
            InitializeComponent();

            //Configuration du Hangfire
            GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(ConfigurationManager.ConnectionStrings["ConnectToHangfire"].ConnectionString));

            _myAccess = MySqlServiceController.GetInstance(ConfigurationManager.ConnectionStrings["ConnectToGsbFrais"].ConnectionString);
            _updater = new UpdateFicheController(_myAccess);
            

        }

        protected override void OnStart(string[] args)
        {

            //Configuration des options pour le serveur de job d'Hangfire

            var options = new BackgroundJobServerOptions
            {
                ServerName = "GestionClotureHangfire",
                Queues = new[] { "critical", "default" },
                WorkerCount = 3
            };
            _server = new BackgroundJobServer(options);
            BackgroundJob.Enqueue<UpdateFicheController>((n) => _updater.UpdateFicheService());
        }

        protected override void OnStop()
        {
            _server.Dispose();
        }

    }
}
