using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Helpers
{
    public static class Extensions
    {
        public static bool IsValidDataTable(this System.Data.DataTable dataTable, int rowCount = 0)
        {
            var isValid = false;

            if (dataTable != null && dataTable.Rows.Count > rowCount)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool IsValidDataSet(this System.Data.DataSet ds, int tableCount = 0, int rowCount = 0)
        {
            var isValid = false;

            if (ds != null && ds.Tables != null && ds.Tables.Count > tableCount && ds.Tables[tableCount].Rows != null && ds.Tables[tableCount].Rows.Count > rowCount)
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Extension method to check whether the data reader has this column or not before reading the data from it.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool HasColumn(this IDataRecord reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Generic extension method to get the different type of data from data reader.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T GetColumnValue<T>(this IDataReader reader, string columnName)
        {
            var value = default(T);
            var t = typeof(T);

            if (reader.HasColumn(columnName))
            {
                if (!DBNull.Value.Equals(reader[columnName]))
                {
                    if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        t = Nullable.GetUnderlyingType(t);
                    }
                    value = (T)Convert.ChangeType(reader[columnName], t);
                }
            }

            return value;
        }

        /// <summary>
        /// Extension method to get the integer value from data reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int GetIntValue(this IDataReader reader, string columnName)
        {
            int value = 0;

            if (reader.HasColumn(columnName))
            {
                value = DBNull.Value.Equals(reader[columnName]) ? 0 : (int)reader[columnName];
            }

            return value;
        }

        /// <summary>
        /// Extension method to get the nullable integer value from data reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int? GetIntValueNullable(this IDataReader reader, string columnName)
        {
            int? value = null;

            if (reader.HasColumn(columnName))
            {
                value = DBNull.Value.Equals(reader[columnName]) ? null : (int?)reader[columnName];
            }

            return value;
        }

        /// <summary>
        /// Extension method to get the boolean value from data reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool GetBooleanValue(this IDataReader reader, string columnName)
        {
            bool value = false;

            if (reader.HasColumn(columnName))
            {
                value = DBNull.Value.Equals(reader[columnName]) ? false : (bool)reader[columnName];
            }

            return value;
        }

        /// <summary>
        /// Extension method to get the string value from data reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetStringValue(this IDataReader reader, string columnName)
        {
            string value = string.Empty;

            if (reader.HasColumn(columnName))
            {
                value = DBNull.Value.Equals(reader[columnName]) ? null : Convert.ToString(reader[columnName]);
            }

            return value;
        }

        /// <summary>
        /// Extension method to get the datetime value from data reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static DateTime? GetDateTimeValue(this IDataReader reader, string columnName)
        {
            DateTime? value = null;

            if (reader.HasColumn(columnName))
            {
                value = DBNull.Value.Equals(reader[columnName]) ? null : (DateTime?)reader[columnName];
            }

            return value;
        }

        public static T GetValueFromDictionary<T>(this System.Collections.IDictionary dictionary, string key)
        {
            var value = default(T);

            if (dictionary.HasKey(key))
            {
                if (dictionary[key] != null)
                {
                    value = (T)Convert.ChangeType(dictionary[key], typeof(T));
                }
            }

            return value;
        }

        private static bool HasKey(this System.Collections.IDictionary dictionary, string key)
        {
            return dictionary.Contains(key);
        }

        public static T ConvertTo<T>(this object result)
        {
            var value = default(T);

            if (result != null)
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                value = (T)(converter.ConvertFromInvariantString(result.ToString()));
            }

            return value;
        }

        #region "Email Validation"

        public static bool IsValidEmailAddress(this string emailAddress)
        {
            var valid = true;
            var isnotblank = false;

            var email = emailAddress.Trim();

            if (email.Length > 0)
            {
                // Email Address Cannot start with period.
                // Name portion must be at least one character
                // In the Name, valid characters are:  a-z 0-9 ! # _ % & ' " = ` { } ~ - + * ? ^ | / $
                // Cannot have period immediately before @ sign.
                // Cannot have two @ symbols
                // In the domain, valid characters are: a-z 0-9 - .
                // Domain cannot start with a period or dash
                // Domain name must be 2 characters.. not more than 256 characters
                // Domain cannot end with a period or dash.
                // Domain must contain a period
                isnotblank = true;
                valid = System.Text.RegularExpressions.Regex.IsMatch(email, EmailRegex.EmailPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase) && !email.StartsWith("-") && !email.StartsWith(".") && !email.EndsWith(".") && !email.Contains("..") && !email.Contains(".@") && !email.Contains("@.");
            }

            return (valid && isnotblank);
        }

        /// <summary>
        /// Validates the string is an Email Address or a delimited string of email addresses...
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>bool</returns>
        public static bool IsValidEmailAddressDelimitedList(this string emailAddress, char delimiter = ';')
        {
            var valid = true;
            var isnotblank = false;

            string[] emails = emailAddress.Split(delimiter);

            foreach (string e in emails)
            {
                var email = e.Trim();

                if (email.Length > 0 && valid) // if valid == false, no reason to continue checking
                {
                    isnotblank = true;

                    if (!email.IsValidEmailAddress())
                    {
                        valid = false;
                    }
                }
            }

            return (valid && isnotblank);
        }

        #endregion
    }

    public class EmailRegex
    {
        /// <summary>
        /// Set of Unicode Characters currently supported in the application for email, etc.
        /// </summary>
        public static readonly string UnicodeCharacters = @"À-ÿ\p{L}\p{M}ÀàÂâÆæÇçÈèÉéÊêËëÎîÏïÔôŒœÙùÛûÜü«»€₣äÄöÖüÜß"; // German and French

        /// <summary>
        /// Set of Symbol Characters currently supported in the application for email, etc.
        /// Needed if a client side validator is being used.
        /// Not needed if validation is done server side.
        /// The difference is due to subtle differences in Regex engines.
        /// </summary>
        public static readonly string SymbolCharacters = @"!#%&'""=`{}~\.\-\+\*\?\^\|\/\$";

        /// <summary>
        /// Regular Expression string pattern used to match an email address.
        /// The following characters will be supported anywhere in the email address:
        /// ÀàÂâÆæÇçÈèÉéÊêËëÎîÏïÔôŒœÙùÛûÜü«»€₣äÄöÖüÜß[a - z][A - Z][0 - 9] _
        /// The following symbols will be supported in the first part of the email address(before the @ symbol):
        /// !#%&'"=`{}~.-+*?^|\/$
        /// Emails cannot start or end with periods,dashes or @.
        /// Emails cannot have two @ symbols.
        /// Emails must have an @ symbol followed later by a period.
        /// Emails cannot have a period before or after the @ symbol.
        /// </summary>
        public static readonly string EmailPattern = String.Format(
            @"^([\w{0}{2}])+@{1}[\w{0}]+([-.][\w{0}]+)*\.[\w{0}]+([-.][\w{0}]+)*$",                     //  @"^[{0}\w]+([-+.'][{0}\w]+)*@[{0}\w]+([-.][{0}\w]+)*\.[{0}\w]+([-.][{0}\w]+)*$",
            UnicodeCharacters, "{1}", SymbolCharacters);
    }
}
