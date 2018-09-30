using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Helpers
{
    public class Utilities
    {
        #region "Singleton Intance"

        private static readonly Utilities _Instance = new Utilities();

        private Utilities()
        {

        }

        public static Utilities Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public List<int> GetMessageCounts()
        {
            List<int> messageCounts = new List<int>() { 1, 2, 3, 5, 10, 20, 50 };

            for (var i = 100; i <= 1000; i += 100)
            {
                messageCounts.Add(i);
            }

            return messageCounts;
        }

        public string CreateFilter(Dictionary<string, string> parameters)
        {
            StringBuilder filter = new StringBuilder();

            foreach (var parameter in parameters)
            {
                filter.Append(parameter.Key);
                filter.Append(" = ");
                filter.Append("'" + parameter.Value + "'");
                filter.Append(" AND ");
            }

            filter.Remove(filter.Length - 5, 5);    //Remove last AND word from the filter.

            return filter.ToString();
        }
        
        public string DateTimeFormating()
        {
            string dateTime = string.Empty;

            string date1 = string.Format("{0:MM/dd/yyyy}", DateTime.Now); // "03/09/2008"
            string date2 = string.Format("{0:d}", DateTime.Now);  // "3/9/2008" 
            string date3 = DateTime.Now.ToString("MM/dd/yyyy");

            string time1 = string.Format("{0:T}", DateTime.Now);  // "4:05:07 PM"
            string time2 = DateTime.Now.ToString("hh:mm tt");

            return dateTime;
        }

        public void ParseDateTime()
        {
            string date = "01/01/2016";
            string date1 = "12/31/9999";
            string date2 = "9/9/2020";

            string date3 = "2016-09-09";
            string date4 = "2020-9-9";
            string date5 = "9999-12-31";

            string[] dateFormat = new[] { "MM/dd/yyyy", "yyyy-MM-dd", "M/d/yyyy", "yyyy-M-d" };

            DateTime startDate, endDate, d2, d3, d4, d5;

            if (DateTime.TryParseExact(date, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                string s = string.Empty;
            }
            else
            {
                string s1 = string.Empty;
            }

            if (DateTime.TryParseExact(date1, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                string s = string.Empty;
            }
            else
            {
                string s1 = string.Empty;
            }

            if (DateTime.TryParseExact(date2, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out d2))
            {
                string s = string.Empty;
            }
            else
            {
                string s1 = string.Empty;
            }

            //=================
            if (DateTime.TryParseExact(date3, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out d2))
            {
                string s = string.Empty;
            }
            if (DateTime.TryParseExact(date4, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out d4))
            {
                string s = string.Empty;
            }
            if (DateTime.TryParseExact(date5, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out d5))
            {
                string s = string.Empty;
            }

        }
    }
}
