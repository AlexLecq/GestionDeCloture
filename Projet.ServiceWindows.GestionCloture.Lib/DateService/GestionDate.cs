using System;

namespace GestionDateTest
{
    public abstract class GestionDate
    {
        /// <summary>
        /// Permet de récupérer le mois précedent à la date d'aujourd'hui
        /// </summary>
        /// <returns>The mois precedent.</returns>
        public static string GetMoisPrecedent()
        {
            int moisActuelle = DateTime.Now.Month;
            if (moisActuelle == 1)
                return "12";

            return FormatNumber(moisActuelle - 1);

        }

        /// <summary>
        /// Permet de récupérer le mois précédent de la date donné en paramètre
        /// </summary>
        /// <returns>The mois precedent.</returns>
        /// <param name="time">Time.</param>
        public static string GetMoisPrecedent(DateTime time)
        {
            if (time != null)
            {
                int mois = time.Month;
                if (mois == 1)
                    return "12";

                return FormatNumber(mois - 1);
            }
            else
                throw new Exception("L'objet passé en paramètre est null");
        }

        /// <summary>
        /// Permet de récupérer le mois suivant de la date donné en paramètre
        /// </summary>
        /// <returns>The mois precedent.</returns>
        public static string GetMoisSuivant()
        {
            int moisActuelle = DateTime.Now.Month;

            if (moisActuelle == 12)
                return "01";

            return FormatNumber(moisActuelle + 1);
        }

        /// <summary>
        /// Permet de récupérer le mois suivant de la date donné en paramètre
        /// </summary>
        /// <returns></returns>
        /// <param name="time">Time.</param>
        public static string GetMoisSuivant(DateTime time)
        {
            if (time != null)
            {
                int mois = time.Month;
                if (mois == 12)
                    return "01";

                return FormatNumber(mois + 1);
            }
            else
                throw new Exception("L'objet passé en paramètre est null");
        }

        /// <summary>
        /// Permet de vérifier si le jour d'aujourd'hui est compris dans un intervale donné
        /// </summary>
        /// <returns><c>true</c>, if entre was ised, <c>false</c> otherwise.</returns>
        /// <param name="jour1">Jour1.</param>
        /// <param name="jour2">Jour2.</param>
        public static bool IsEntre(int jour1, int jour2)
        {
            int jourActuelle = DateTime.Now.Day;
            return (jourActuelle >= jour1 && jourActuelle <= jour2);
        }

        /// <summary>
        /// Permet de vérifier si le jour de la date passé en paramètre est compris dans un intervale donné
        /// </summary>
        /// <returns><c>true</c>, if entre was ised, <c>false</c> otherwise.</returns>
        /// <param name="jour1">Jour1.</param>
        /// <param name="jour2">Jour2.</param>
        /// <param name="jourToCheck">Jour to check.</param>
        public static bool IsEntre(int jour1, int jour2, DateTime jourToCheck)
        {
            int jour = jourToCheck.Day;
            return (jour >= jour1 && jour <= jour2);
        }

        /// <summary>
        /// Permet d'ajouter un zéro au début d'un chiffre
        /// </summary>
        /// <returns></returns>
        /// <param name="number"></param>
        public static string FormatNumber(int number)
        {
            if (number < 10)
            {
                return "0" + number.ToString();
            }
            else
            {
                return number.ToString();
            }
        }

    }
}
