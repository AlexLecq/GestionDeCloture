using Projet.ServiceWindows.GestionCloture.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Projet.ServiceWindows.GestionCloture
{
    public partial class GestionCloture : ServiceBase
    {
        private EventLog eventLog1;

        public GestionCloture()
        {
            InitializeComponent();

            string keyName = "ServiceGestionCloture";
            eventLog1 = new EventLog();

            ToolsBox.CreateKeyEventLog(keyName);

            if (!EventLog.SourceExists(keyName))
            {
                EventLog.CreateEventSource(
                    keyName, "logEvent");
            }
            eventLog1.Source = keyName;
            eventLog1.Log = "logEvent";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Service on start !");
        }

        protected override void OnStop()
        {
        }
    }
}
