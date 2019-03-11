using GestionDateTest;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Projet.ServiceWindows.GestionCloture.Controllers
{
    public class UpdateFicheController
    {
        private MySqlServiceController _myAccess;

        public UpdateFicheController(MySqlServiceController myAccess)
        {
            this._myAccess = myAccess;
           
        }

        public void UpdateFicheService()
        {
            Timer timer = new Timer()
            {
                AutoReset = true,
                Enabled = false,
                Interval = 5000
            };

            timer.Elapsed += UpdatePourCloture;

            timer.Start();
        }

        public void UpdatePourCloture(Object source, System.Timers.ElapsedEventArgs e)
        {
            _myAccess.UpdateEtatFiche("CR", "CL", GestionDate.GetMoisPrecedent(new DateTime(2019, 04, 12)));
        }

        public void UpdatePourRemboursement(Object source, System.Timers.ElapsedEventArgs e)
        {

        }

        public static bool GetTest()
        {
            return true;
        }

        
    }
}
