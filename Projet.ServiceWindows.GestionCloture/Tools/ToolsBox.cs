using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.ServiceWindows.GestionCloture.Tools
{
    static class ToolsBox
    {
        public static void CreateKeyEventLog(string keyName)
        {
            const string PATH = @"./createkey.reg";

            if (!File.Exists(PATH))
            {
                using (StreamWriter writer = File.CreateText(PATH))
                {
                    writer.WriteLine("Windows Registry Editor Version 5.00");
                    writer.WriteLine(" ");
                    writer.WriteLine(@"[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\EventLog\Application\" + keyName + "]");

                    writer.Close();
                }
            }

        }
    }
}
