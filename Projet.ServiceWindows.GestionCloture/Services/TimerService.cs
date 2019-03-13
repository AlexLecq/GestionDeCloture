using Projet.ServiceWindows.GestionCloture.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Projet.ServiceWindows.GestionCloture.Services
{
    public class TimerService
    {
        private Timer _timer;

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

        public void Start()
        {
            this._timer.Start();
        }

        public void Stop()
        {
            this._timer.Stop();
        }

        private double ConvertToMilliseconds(TimeSpan temps)
        {
            return temps.TotalMilliseconds;
        }
    }
}
