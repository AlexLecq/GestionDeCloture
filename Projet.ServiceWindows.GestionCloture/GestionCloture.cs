using Hangfire;
using Hangfire.MySql.Core;
using System;
using System.ServiceProcess;
using System.Configuration;
using Projet.ServiceWindows.GestionCloture.Controllers;
using Projet.ServiceWindows.GestionCloture.Services;

namespace Projet.ServiceWindows.GestionCloture
{
    /// <summary>
    /// Classe principale du service windows
    /// </summary>
    public partial class GestionCloture : ServiceBase
    {
        /// <summary>
        /// Déclaration des services 
        /// </summary>
        private BackgroundJobServer _server;

        /// <summary>
        /// Instance du controleur d'accès à la BDD
        /// </summary>
        public static MySqlServiceController _myAccess;

        /// <summary>
        /// Instance du service de Timing
        /// </summary>
        private TimerService _timer;

        /// <summary>
        /// Constructeur de la classe GestionCloture
        /// </summary>
        public GestionCloture()
        {
            InitializeComponent();

            //Configuration du Timeout
            Tools.ConfigWindowsService.ConfigTimeout();

            //Configuration du Hangfire
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
            GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(ConfigurationManager.ConnectionStrings["ConnectToHangfire"].ConnectionString));

            //Configuration des services d'accès à la BDD et du Service de Timing
            _myAccess = MySqlServiceController.GetInstance(ConfigurationManager.ConnectionStrings["ConnectToGsbFrais"].ConnectionString);
            _timer = new TimerService(new TimeSpan(0,0,30));
        }

        /// <summary>
        /// Action effectué au démarrage du service
        /// </summary>
        /// <param name="args"></param>
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

            _timer.Start();
        }

        /// <summary>
        /// Action effectué à l'arrêt du service
        /// </summary>
        protected override void OnStop()
        {
            _server.Dispose();
            _timer.Stop();
            
        }

        
    }


}
