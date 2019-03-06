using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// Permet d'exécuter les requêtes vers la BDD
        /// </summary>
        /// <param name="queryString"></param>
        public void ExecuteQuery(string queryString)
        {
            using(MySqlCommand command = _connect.CreateCommand())
            {
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
                    _connect.Dispose();
                    Console.WriteLine(e.Message, e.StackTrace, e.ErrorCode);
                }

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(string.Format("- {0} : {1} ", reader.GetName(i), reader.GetString(i)));
                        }
                        Console.WriteLine();
                    }
                }

                reader.Close();
            } 
        }
    }
}
