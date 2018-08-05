using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Amalay.Helpers.DataAccess.SqlServer
{
    public class SqlParameterCache : IParameterCache
    {
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        #region Singleton

        private static readonly SqlParameterCache _Instance = new SqlParameterCache();
        public static SqlParameterCache Instance
        {
            get
            {
                return _Instance;
            }
        }
        
        //default constructor
        private SqlParameterCache() { }

        #endregion
        
        #region IParameterCache Members

        public IDbDataParameter[] GetSpParameters(string connectionString, string storeProcedure, bool includeReturnValueParameter)
        {
            //bool includeReturnValueParameter = true;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Invalid connection string.");
            }

            if (string.IsNullOrEmpty(storeProcedure))
            {
                throw new ArgumentNullException("Invalid store procedure.");
            }

            string hashKey = connectionString + ":" + storeProcedure + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
            IDbDataParameter[] spParams = paramCache[hashKey] as SqlParameter[];

            if (spParams == null)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand(storeProcedure, sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCon.Open();
                    SqlCommandBuilder.DeriveParameters(sqlCmd);
                    sqlCon.Close();

                    if (sqlCmd.Parameters != null && sqlCmd.Parameters.Count > 0)
                    {
                        if (!includeReturnValueParameter)
                        {
                            sqlCmd.Parameters.RemoveAt(0);
                        }

                        spParams = new SqlParameter[sqlCmd.Parameters.Count];

                        sqlCmd.Parameters.CopyTo(spParams, 0);

                        // Init the parameters with a DBNull value
                        foreach (SqlParameter param in spParams)
                        {
                            param.Value = DBNull.Value;
                        }

                        paramCache[hashKey] = spParams;
                    }
                }
            }

            IDbDataParameter[] cloneSpParams = null;
            if (spParams != null && spParams.Length > 0)
            {
                cloneSpParams = new SqlParameter[spParams.Length];

                for (int i = 0; i < spParams.Length; i++)
                {
                    cloneSpParams[i] = (SqlParameter)((ICloneable)spParams[i]).Clone();
                }
            }

            return cloneSpParams;
        }

        #endregion
    }
}
