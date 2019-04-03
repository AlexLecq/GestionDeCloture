using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace Projet.ServiceWindows.GestionCloture.Tools
{
    /// <summary>
    /// Classe permettant de configurer le Service Windows
    /// </summary>
    static class ConfigWindowsService
    {
        /// <summary>
        /// Méthode permettant de configurer le timeout du service windows
        /// </summary>
        public static void ConfigTimeout()
        {
            RegistryKey winKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control", true);
            bool isExist = false;
            foreach (string oneValue in winKey.GetValueNames())
            {
                isExist = oneValue == "ServicesPipeTimeout" ? true : false;
            }

            if (!isExist)
            {
                try
                {
                   winKey.SetValue("ServicesPipeTimeout", 30000, RegistryValueKind.DWord);

                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
