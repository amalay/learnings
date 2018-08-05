using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Configuration;

namespace Amalay.Helpers.DataAccess
{
    public sealed class DataAccessManager
    {
        private string _ProviderName = string.Empty;

        public DataAccessManager() { }

        public DataAccessManager(string dataProviderName)
        {
            this._ProviderName = dataProviderName;
        }

        #region "DataProviders & Configurations"

        private string ProviderName
        {
            get
            {
                return this._ProviderName;
            }
        }

        private DataProvider Provider
        {
            get
            {
                DataConfiguration dataConfiguration = ConfigurationManager.GetSection("DataProviders") as DataConfiguration;

                return dataConfiguration.DataProviders[this.ProviderName];
            }
        }

        private IDataProvider Instance
        {
            get
            {
                return this.Provider.Instance;
            }
        }

        private string ConnectionString
        {
            get
            {
                return this.Provider.ConnectionString;
            }
        }

        #endregion

        #region "Public Methods"

        public int ExecuteNonQuery(string commandText, ref Hashtable outparam, params object[] spParamValues)
        {
            int result = this.Instance.ExecuteNonQuery(this.ConnectionString, commandText, ref outparam, spParamValues);
            return result;
        }

        public int ExecuteNonQuery(string commandText, ref Hashtable outparams, IList<DbParameter> parameters)
        {
            int result = this.Instance.ExecuteNonQuery(this.ConnectionString, commandText, ref outparams, parameters);
            return result;
        }

        public object ExecuteScalar(string commandText, ref Hashtable outparam, params object[] spParamValues)
        {
            object result = this.Instance.ExecuteScalar(this.ConnectionString, commandText, ref outparam, spParamValues);
            return result;
        }

        public object ExecuteScalar(string commandText, ref Hashtable outparams, IList<DbParameter> parameters)
        {
            object result = this.Instance.ExecuteScalar(this.ConnectionString, commandText, ref outparams, parameters);
            return result;
        }

        public IList<T> ExecuteDataReader<T>(string commandText, ref Hashtable outparam, Func<IDataRecord, T> generator, params object[] spParamsValue)
        {
            IList<T> list = this.Instance.ExecuteDataReader(this.ConnectionString, commandText, ref outparam, generator, spParamsValue);
            return list;
        }

        public IList<T> ExecuteDataReader<T>(string commandText, ref Hashtable outparam, Func<IDataRecord, T> generator, IList<DbParameter> parameters)
        {
            IList<T> list = this.Instance.ExecuteDataReader(this.ConnectionString, commandText, ref outparam, generator, parameters);
            return list;
        }

        #endregion
    }
}
