using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Deployment.Application;
using System.Windows;

namespace Receituario.Config
{
    public class Configuracao
    {
        private static volatile Configuracao instance;
        private static object syncRoot = new Object();

        private Configuracao() { }

        public static Configuracao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Configuracao();
                    }
                }

                return instance;
            }
        }

        public string GetDataDirectory()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                return ApplicationDeployment.CurrentDeployment.DataDirectory;
            }
            else
            {
                return null;
            }
        }

    }

}
