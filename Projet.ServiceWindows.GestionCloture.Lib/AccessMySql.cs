using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.ServiceWindows.GestionCloture.Lib
{
    public class AccessMySql
    {
        /// <summary>
        /// Propriétés de la classe AccessMySql
        /// </summary>
        private static MySqlConnection connect;
        private static AccessMySql instance;

        /*
         * Constructeur de la classe AccessMySql
         * @param  connectString -> chaine de connexion
         */
        private AccessMySql(string connectString)
        {
            connect = new MySqlConnection(connectString);
        }

        /*
         * Permet de récupérer l'unique instance de la classe 
         * @param  connectString -> chaine de connexion
         * @return instance -> Instance de la classe AccessMySql
         */
        public static AccessMySql getInstance(string connectString)
        {
            if (connect == null)
            {
                return instance = new AccessMySql(connectString);
            }
            else
            {
                return instance;
            }
        }
    }
}
