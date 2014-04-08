using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;

/// <summary>
/// config 的摘要说明 process for web.config
/// </summary>
namespace DAL
{
    public class HelperConfig
    {
        public HelperConfig()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static bool AddConfig(string sKey, string sValue)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("");
            AppSettingsSection app = config.AppSettings;
            app.Settings.Add(sKey, sValue);
            config.Save(ConfigurationSaveMode.Modified);
            return true;
        }
        public static bool ReviseConfig(string sKey, string sValue)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("");
            AppSettingsSection app = config.AppSettings;

            app.Settings[sKey].Value = sValue;
            config.Save(ConfigurationSaveMode.Modified);
            return true;
        }
        public static string ReadConfig(string sKey)
        {
            string sValue = ConfigurationManager.AppSettings[sKey];
            return sValue;
        }
    }
}