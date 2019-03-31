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
    public static class UpdateFicheController
    {
        [Queue("critical")]
        public static void UpdateFicheService(Object source, System.Timers.ElapsedEventArgs e)
        {
            BackgroundJob.Enqueue(() => UpdatePourCloture());
            BackgroundJob.Enqueue(() => UpdatePourRemboursement());
        }

        public static void UpdatePourCloture()
        {
            if (GestionDate.IsEntre(1, 30))
                GestionCloture._myAccess.UpdateEtatFiche("CR", "CL", GestionDate.GetMoisPrecedent(new DateTime(2019, 04, 5)));
            else
                throw new Exception("On est le  " + DateTime.Now.ToString());

        }

        public static void UpdatePourRemboursement()
        {
            if(GestionDate.IsEntre(10 , 30))
                GestionCloture._myAccess.UpdateEtatFiche("VA", "RB", GestionDate.GetMoisPrecedent(new DateTime(2019, 03, 25)));
            else
                throw new Exception("On est le  " + DateTime.Now.ToString());

        }
    }
}
