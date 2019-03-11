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
    public class MySqlService
    {
        /// <summary>
        /// Propriétés de la classe AccessMySql
        /// </summary>
        private MySqlConnection _connect;

        /// <summary>
        /// Constructeur privée de la classe 
        /// </summary>
        /// <param name="connectString"></param>
        protected MySqlService(string connectString)
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
        /// Permet d'exécuter les requêtes vers la BDD
        /// </summary>
        /// <param name="queryString"></param>
        protected List<Dictionary<string,string>> ExecuteQuery(string queryString)
        {
            using(MySqlCommand command = _connect.CreateCommand())
            {
                command.CommandText = queryString;

                try
                {
                    _connect.Open();

                    if (_connect.State == System.Data.ConnectionState.Open)
                        Console.WriteLine("Lâ requête s'est exécuté avec succès !");
                }
                catch (MySqlException e)
                {
                    _connect.Dispose();
                    Console.WriteLine(e.Message, e.StackTrace, e.ErrorCode);
                }

                List<Dictionary<string, string>> result = null;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Dictionary<string, string> uneLigne = null;
                    result = new List<Dictionary<string, string>>();
                    while (reader.Read())
                    {
                        uneLigne = new Dictionary<string, string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            uneLigne.Add(reader.GetName(i), reader.GetString(i));
                        }
                        result.Add(uneLigne);
                    }
                }
                _connect.Close();
                reader.Close();
                return result;
            } 
        }
    }
}
