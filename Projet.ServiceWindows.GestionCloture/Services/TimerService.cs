using Projet.ServiceWindows.GestionCloture.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Projet.ServiceWindows.GestionCloture.Services
{
    /// <summary>
    /// Service permettant de paramétrer le timing des requêtes
    /// </summary>
    public class TimerService
    {
        /// <summary>
        /// Objet de type Timer
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// Constructeur de la classe TimerService
        /// </summary>
        /// <param name="temps"></param>
        public TimerService(TimeSpan temps)
        {
            this._timer = new Timer()
            {
                AutoReset = true,
                Enabled = false,
                Interval = ConvertToMilliseconds(temps)
            };

            this._timer.Elapsed += UpdateFicheController.UpdateFicheService;
        }

        /// <summary>
        /// Permet le lancement du service de Timing
        /// </summary>
        public void Start()
        {
            this._timer.Start();
        }

        /// <summary>
        /// Permet d'arrêter le service de timing 
        /// </summary>
        public void Stop()
        {
            this._timer.Stop();
        }

        /// <summary>
        /// Permet de convertir un temps de type "TimeSpan" en milliseconds
        /// </summary>
        /// <param name="temps"></param>
        /// <returns>Temps en milliseconds</returns>
        private double ConvertToMilliseconds(TimeSpan temps)
        {
            return temps.TotalMilliseconds;
        }
    }
}
