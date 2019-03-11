using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDateTest;
using Projet.ServiceWindows.GestionCloture.Classe;
using Projet.ServiceWindows.GestionCloture.Controllers;

namespace Projet.ServiceWindows.GestionCloture.ServiceTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlServiceController myAccess = MySqlServiceController.GetInstance("Server=localhost;Database=gsb_frais;Allow User Variables=true;Uid=userGsb;Pwd=secret");

            if (GestionDate.IsEntre(1, 10))
            {

                myAccess.UpdateEtatFiche("CR", "CL", GestionDate.GetMoisPrecedent(new DateTime(2019, 04, 12)));
            }
            else if (GestionDate.IsEntre(11, 31))
                myAccess.UpdateEtatFiche("VA", "RB", GestionDate.GetMoisPrecedent(new DateTime(2019, 02, 12)));
                
            Console.WriteLine("Nous somme le " + DateTime.Now.Day);
            Console.ReadLine();
        }
    }
}
