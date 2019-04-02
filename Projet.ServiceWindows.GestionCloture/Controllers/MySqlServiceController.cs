using Projet.ServiceWindows.GestionCloture.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.ServiceWindows.GestionCloture.Controllers
{
    /// <summary>Controleur de la classe MySql, avec des méthodes propres à la solution développé</summary>
    public class MySqlServiceController : MySqlService
    {
        /// <summary>
        /// Instance de la classe MySqlServiceController
        /// </summary>
        private static MySqlServiceController _instance;

        /// <summary>
        /// Chaine de connexion à la base de données
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Constructeur privé de la classe
        /// </summary>
        /// <param name="connectionString"></param>
        private MySqlServiceController(string connectionString) : base(connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// Récupération de l'unique instance de la classe
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static MySqlServiceController GetInstance(string connectString)
        {
            return _instance == null ? _instance = new MySqlServiceController(connectString) : _instance;
        }

        /// <summary>
        /// Permet la récupération des fiches de frais du mois précédents 
        /// </summary>
        /// <param name="idEtat"></param>
        /// <param name="moisPrecedent"></param>
        /// <returns></returns>
        private List<Dictionary<string,string>> GetFicheMoisPrecedent(string idEtat, string moisPrecedent)
        {
            int lastYear = DateTime.Now.Year - 1;
            string query = String.Format(@"SELECT fichefrais.idetat , fichefrais.idvisiteur, fichefrais.mois
                                           FROM fichefrais
                                           WHERE fichefrais.idetat = '{0}' AND fichefrais.mois = '{1}'", idEtat, moisPrecedent != "12" ? DateTime.Now.Year.ToString() + moisPrecedent : lastYear.ToString() + moisPrecedent);
            return base.ExecuteQuery(query);
        }

        /// <summary>
        /// Permet la mise à jour de l'etat d'une fiche de frais 
        /// </summary>
        /// <param name="idEtatHasChange"></param>
        /// <param name="idEtatToChange"></param>
        /// <param name="moisPrecedent"></param>
        public void UpdateEtatFiche(string idEtatHasChange,string idEtatToChange, string moisPrecedent)
        {
            if (idEtatHasChange != null && idEtatToChange != null)
            {
                List<Dictionary<string,string>> fichesToUp = GetFicheMoisPrecedent(idEtatHasChange, moisPrecedent);
                if (fichesToUp != null)
                {
                    foreach (Dictionary<string,string> one in fichesToUp)
                    {
                        string query = String.Format(@"UPDATE fichefrais
                                                       SET fichefrais.idetat = '{0}' , datemodif = '{1}'
                                                       WHERE idvisiteur = '{2}' AND mois = '{3}'", idEtatToChange, DateTime.Now.ToString("yyyy-MM-dd"), one["idvisiteur"].ToString(), one["mois"].ToString());
                        base.ExecuteQuery(query);
                    }
                }
            }
            else
                throw new NullReferenceException();
        }
    }
}
