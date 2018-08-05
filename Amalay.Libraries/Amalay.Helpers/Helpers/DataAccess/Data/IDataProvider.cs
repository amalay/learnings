using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Amalay.Helpers.DataAccess
{
    public interface IDataProvider
    {
        int ExecuteNonQuery(string connectionString, string storeProcedure, ref Hashtable outparam, params object[] spParamsValue);

        int ExecuteNonQuery(string connectionString, string storeProcedure, ref Hashtable outparam, IEnumerable parameters);

        object ExecuteScalar(string connectionString, string storeProcedure, ref Hashtable outparam, params object[] spParamsValue);

        object ExecuteScalar(string connectionString, string storeProcedure, ref Hashtable outparam, IEnumerable parameters);

        IList<T> ExecuteDataReader<T>(string connectionString, string storeProcedure, ref Hashtable outparam, Func<IDataRecord, T> generator, params object[] spParamsValue);

        IList<T> ExecuteDataReader<T>(string connectionString, string storeProcedure, ref Hashtable outparam, Func<IDataRecord, T> generator, IEnumerable parameters);
        
    }
}
