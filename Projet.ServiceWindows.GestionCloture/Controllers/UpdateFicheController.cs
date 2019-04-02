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
    /// <summary>
    /// Controleur permettant la mise à jour de l'état des fiches de frais 
    /// </summary>
    public static class UpdateFicheController
    {
        /// <summary>
        /// Méthode permettant d'éxecuter les requêtes de mis à jour
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        [Queue("critical")]
        public static void UpdateFicheService(Object source, System.Timers.ElapsedEventArgs e)
        {
            BackgroundJob.Enqueue(() => UpdatePourCloture());
            BackgroundJob.Enqueue(() => UpdatePourRemboursement());
        }

        /// <summary>
        /// Permet de mettre à jour fiche en "Saisi en cours" à "Clôturé"
        /// </summary>
        public static void UpdatePourCloture()
        {
            if (GestionDate.IsEntre(1, 10))
                GestionCloture._myAccess.UpdateEtatFiche("CR", "CL", GestionDate.GetMoisPrecedent());

        }

        /// <summary>
        /// Permet de mettre à jour les fiches "Validé" à "Remboursé"
        /// </summary>
        public static void UpdatePourRemboursement()
        {
            if(GestionDate.IsEntre(20 , 30))
                GestionCloture._myAccess.UpdateEtatFiche("VA", "RB", GestionDate.GetMoisPrecedent());

        }
    }
}
