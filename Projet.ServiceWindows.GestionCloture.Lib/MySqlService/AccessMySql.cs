using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.ServiceWindows.GestionCloture.Classe
{
    public class AccessMySql
    {
        /// <summary>
        /// Propriétés de la classe AccessMySql
        /// </summary>
        private MySqlConnection _connect;
        private static AccessMySql _instance;

        /// <summary>
        /// Constructeur privée de la classe 
        /// </summary>
        /// <param name="connectString"></param>
        private AccessMySql(string connectString)
        {
            try
            {
                _connect = new MySqlConnection(connectString);
                Console.WriteLine("Connexion réussi !");
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message + e.ErrorCode + e.StackTrace);
            }
        }

        /// <summary>
        /// Récupération de l'unique instance de la classe
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static AccessMySql GetInstance(string connectString)
        {
            return _instance == null ? _instance = new AccessMySql(connectString) : _instance;
        }

        public void GetAllTable()
        {
            
        }

        private MySqlDataReader ExecuteQuery(string queryString)
        {
            MySqlCommand command = _connect.CreateCommand();
            command.CommandText = queryString;

            try
            {
                _connect.Open();
                if (_connect.State == System.Data.ConnectionState.Executing)
                    Console.WriteLine("Lâ requête est en cours d'exécution ..");

                if (_connect.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Lâ requête s'est exécuté avec succès !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, e.StackTrace, e.ErrorCode);
            }
        }
    }
}
