using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Helpers
{
    public static class ConfigHelper
    {
        #region "Public Properties"

        public static string Enviornment { get; private set; }

        public static string ExchangeEmail { get; private set; }

        public static string ExchangePassword { get; private set; }

        public static string ServiceBusConnectionString { get; private set; }

        public static string DatabaseConnectionString { get; private set; }

        #endregion

        static ConfigHelper()
        {
            // Cache all these values in static properties.
            Enviornment = Get<string>("Enviornment");
            ExchangeEmail = Get<string>("ExchangeEmail");
            ExchangePassword = Get<string>("ExchangePassword");
            DatabaseConnectionString = Get<string>("DatabaseConnectionString");
        }

        #region "Public Methods"

        /// <summary>
        /// Generic function to get the value stored in app settings.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private static T Get<T>(string key)
        {
            var value = default(T);

            var appSetting = System.Configuration.ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(appSetting))
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                value = (T)(converter.ConvertFromInvariantString(appSetting));
            }

            return value;
        }

        #endregion
    }
}
