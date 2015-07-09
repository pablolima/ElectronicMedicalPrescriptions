using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace Util.Database
{
    public class Util : DataWorker
    {
        public static bool TestConnectionDb()
        {
            try
            {
                IDbConnection conn = database.CreateOpenConnection();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool SetaCaminho()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Clear();
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("Access", @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Data\receituario.mdb", "System.Data.OleDb"));
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            return true;
        }
        public static bool SetaCaminho(string caminho)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Clear();
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("Access", @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + caminho, "System.Data.OleDb"));
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            return true;
        }

        public static string TipoBanco()
        {
            DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");
            string retorno = sectionHandler.ConnectionStringName;
            return retorno;
        }

        public static string RetornaCaminhoBanco()
        {
            DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");
            string retorno = sectionHandler.ConnectionString.Substring(45);
            return retorno;
        }

    }
}
