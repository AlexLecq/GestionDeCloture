using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet.ServiceWindows.GestionCloture.Classe;

namespace Projet.ServiceWindows.GestionCloture.ServiceTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessMySql myAccess = AccessMySql.GetInstance("Server=localhost;Database=gsb_frais;Allow User Variables=true;Uid=userGsb;Pwd=secret");
            myAccess.ExecuteQuery("SELECT * FROM visiteur");
            Console.ReadLine();
        }
    }
}
