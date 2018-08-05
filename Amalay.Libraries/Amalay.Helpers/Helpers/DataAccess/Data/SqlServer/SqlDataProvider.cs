using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;


namespace Amalay.Helpers.DataAccess.SqlServer
{
    public sealed class SqlDataProvider : IDataProvider
    {
        #region Singleton

        private static readonly SqlDataProvider _Instance = new SqlDataProvider();
        public static SqlDataProvider Instance
        {
            get
            {
                return _Instance;
            }
        }

        private string ConnectionString { get; set; }

        private string CommandText { get; set; }

        public SqlDataProvider() { }

        #endregion

        #region IDataProvider Members

        public int ExecuteNonQuery(string connectionString, string storeProcedure, ref Hashtable outparam, params object[] spParamsValue)
        {
            this.ConnectionString = connectionString;
            this.CommandText = storeProcedure;

            // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            SqlParameter[] spParams = (SqlParameter[])SqlParameterCache.Instance.GetSpParameters(this.ConnectionString, this.CommandText, false);

            // If we receive parameter values, we need to figure out where they go
            if ((spParamsValue != null) && (spParamsValue.Length > 0))
            {
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(ref spParams, spParamsValue);
            }

            return ExecuteNonQuery(ref outparam, spParams);
        }

        public int ExecuteNonQuery(string connectionString, string storeProcedure, ref Hashtable outparam, IEnumerable parameters)
        {
            this.ConnectionString = connectionString;
            this.CommandText = storeProcedure;

            return ExecuteNonQuery(ref outparam, parameters);
        }

        public object ExecuteScalar(string connectionString, string storeProcedure, ref Hashtable outparam, params object[] spParamsValue)
        {
            this.ConnectionString = connectionString;
            this.CommandText = storeProcedure;

            // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            SqlParameter[] spParams = (SqlParameter[])SqlParameterCache.Instance.GetSpParameters(this.ConnectionString, this.CommandText, false);

            // If we receive parameter values, we need to figure out where they go
            if ((spParamsValue != null) && (spParamsValue.Length > 0))
            {
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(ref spParams, spParamsValue);
            }

            return ExecuteScalar(ref outparam, spParams);
        }

        public object ExecuteScalar(string connectionString, string storeProcedure, ref Hashtable outparam, IEnumerable parameters)
        {
            this.ConnectionString = connectionString;
            this.CommandText = storeProcedure;

            return ExecuteScalar(ref outparam, parameters);
        }

        public IList<T> ExecuteDataReader<T>(string connectionString, string storeProcedure, ref Hashtable outparam, Func<System.Data.IDataRecord, T> generator, params object[] spParamsValue)
        {
            this.ConnectionString = connectionString;
            this.CommandText = storeProcedure;

            SqlParameter[] spParams = (SqlParameter[])SqlParameterCache.Instance.GetSpParameters(this.ConnectionString, this.CommandText, false);

            // If we receive parameter values, we need to figure out where they go
            if ((spParamsValue != null) && (spParamsValue.Length > 0))
            {
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(ref spParams, spParamsValue);
            }

            IList<T> list = ExecuteDataReader(ref outparam, generator, spParams);

            return list;
        }

        public IList<T> ExecuteDataReader<T>(string connectionString, string storeProcedure, ref Hashtable outparam, Func<System.Data.IDataRecord, T> generator, IEnumerable parameters)
        {
            this.ConnectionString = connectionString;
            this.CommandText = storeProcedure;

            IList<T> list = ExecuteDataReader(ref outparam, generator, parameters);
            return list;
        }

        #endregion

        #region Private Methods

        private void AssignParameterValues(ref SqlParameter[] spParams, params object[] spParamsValue)
        {
            if (spParams != null && spParamsValue != null)
            {
                for (int i = 0; i < spParamsValue.Length; i++)
                {
                    if (spParamsValue[i] != null && i < spParams.Length)
                    {
                        spParams[i].Value = (spParamsValue[i] is IDbDataParameter) ? (IDbDataParameter)spParamsValue[i] : spParamsValue[i];
                    }
                }
            }

            //if (spParams != null && spParams.Length == spParamsValue.Length)
            //{
            //    for (int i = 0; i < spParams.Length; i++)
            //    {
            //        if (spParamsValue[i] == null)
            //        {
            //            spParams[i].Value = DBNull.Value;
            //        }
            //        else
            //        {
            //            spParams[i].Value = (spParamsValue[i] is IDbDataParameter) ? (IDbDataParameter)spParamsValue[i] : spParamsValue[i];
            //        }
            //    }
            //}
            //else
            //{
            //    throw new ArgumentException("Parameter count does not match Parameter Value count.");
            //}
        }

        private void AddParametersToCommand(SqlCommand sqlCommand, ref SqlParameter[] spParams)
        {
            try
            {
                foreach (SqlParameter param in spParams)
                {
                    if ((param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Input) && (param.Value == null))
                    {
                        param.Value = DBNull.Value;
                    }
                    sqlCommand.Parameters.Add(param);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void AttachParametersToCommand(SqlCommand sqlCommand, IEnumerable parameters)
        {
            foreach (DbParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.Output) || (parameter.Direction == ParameterDirection.ReturnValue))
                {
                    sqlCommand.Parameters.AddWithValue(parameter.Name, parameter.Value).Direction = parameter.Direction;
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue(parameter.Name, parameter.Value);
                }
            }
        }

        private int ExecuteNonQuery(ref Hashtable outparam, SqlParameter[] spParams)
        {
            int result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(this.CommandText, sqlConnection))
                {
                    SqlTransaction sqlTransaction = null;
                    try
                    {
                        if (spParams != null)
                        {
                            AddParametersToCommand(sqlCommand, ref spParams);
                        }
                        if (sqlConnection.State != ConnectionState.Open || sqlConnection.State == ConnectionState.Broken)
                        {
                            sqlConnection.Open();
                        }
                        sqlTransaction = sqlConnection.BeginTransaction();

                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Transaction = sqlTransaction;

                        result = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
                        sqlTransaction.Commit();

                        if (outparam != null)
                        {
                            foreach (SqlParameter param in sqlCommand.Parameters)
                            {
                                if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.ReturnValue)
                                {
                                    outparam.Add(param.ParameterName, param.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (sqlTransaction != null)
                        {
                            sqlTransaction.Rollback();
                        }
                        throw ex;
                    }
                    finally
                    {
                        sqlCommand.Parameters.Clear();

                        if (sqlConnection.State != ConnectionState.Closed)
                        {
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return result;
        }

        private int ExecuteNonQuery(ref Hashtable outparam, IEnumerable parameters)
        {
            int result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(this.CommandText, sqlConnection))
                {
                    SqlTransaction sqlTransaction = null;
                    try
                    {
                        AttachParametersToCommand(sqlCommand, parameters);

                        if (sqlConnection.State != ConnectionState.Open || sqlConnection.State == ConnectionState.Broken)
                        {
                            sqlConnection.Open();
                        }
                        sqlTransaction = sqlConnection.BeginTransaction();

                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Transaction = sqlTransaction;

                        result = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
                        sqlTransaction.Commit();

                        if (outparam != null)
                        {
                            foreach (SqlParameter param in sqlCommand.Parameters)
                            {
                                if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.ReturnValue)
                                {
                                    outparam.Add(param.ParameterName, param.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (sqlTransaction != null)
                        {
                            sqlTransaction.Rollback();
                        }
                        throw ex;
                    }
                    finally
                    {
                        sqlCommand.Parameters.Clear();

                        if (sqlConnection.State != ConnectionState.Closed)
                        {
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return result;
        }

        private object ExecuteScalar(ref Hashtable outparam, SqlParameter[] spParams)
        {
            object result = null;

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(this.CommandText, sqlConnection))
                {
                    SqlTransaction sqlTransaction = null;
                    try
                    {
                        if (spParams != null)
                        {
                            AddParametersToCommand(sqlCommand, ref spParams);
                        }
                        if (sqlConnection.State != ConnectionState.Open || sqlConnection.State == ConnectionState.Broken)
                        {
                            sqlConnection.Open();
                        }
                        sqlTransaction = sqlConnection.BeginTransaction();

                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Transaction = sqlTransaction;

                        result = sqlCommand.ExecuteScalar();
                        sqlTransaction.Commit();

                        if (outparam != null)
                        {
                            foreach (SqlParameter param in sqlCommand.Parameters)
                            {
                                if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.ReturnValue)
                                {
                                    outparam.Add(param.ParameterName, param.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (sqlTransaction != null)
                        {
                            sqlTransaction.Rollback();
                        }
                        throw ex;
                    }
                    finally
                    {                        
                        sqlCommand.Parameters.Clear();

                        if (sqlConnection.State != ConnectionState.Closed)
                        {
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return result;
        }

        private object ExecuteScalar(ref Hashtable outparam, IEnumerable parameters)
        {
            object result = null;

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(this.CommandText, sqlConnection))
                {
                    SqlTransaction sqlTransaction = null;
                    try
                    {
                        if (parameters != null)
                        {                            
                            AttachParametersToCommand(sqlCommand, parameters);
                        }

                        if (sqlConnection.State != ConnectionState.Open || sqlConnection.State == ConnectionState.Broken)
                        {
                            sqlConnection.Open();
                        }
                        sqlTransaction = sqlConnection.BeginTransaction();

                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Transaction = sqlTransaction;

                        result = sqlCommand.ExecuteScalar();
                        sqlTransaction.Commit();

                        if (outparam != null)
                        {
                            foreach (SqlParameter param in sqlCommand.Parameters)
                            {
                                if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.ReturnValue)
                                {
                                    outparam.Add(param.ParameterName, param.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (sqlTransaction != null)
                        {
                            sqlTransaction.Rollback();
                        }
                        throw ex;
                    }
                    finally
                    {
                        sqlCommand.Parameters.Clear();

                        if (sqlConnection.State != ConnectionState.Closed)
                        {
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return result;
        }

        private IList<T> ExecuteDataReader<T>(ref Hashtable outParam, Func<IDataRecord, T> generator, SqlParameter[] spParams)
        {
            IList<T> list = null;

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(this.CommandText, sqlConnection))
                {
                    SqlTransaction sqlTransaction = null;
                    try
                    {
                        if (spParams != null)
                        {
                            AddParametersToCommand(sqlCommand, ref spParams);
                        }

                        if (sqlConnection.State != ConnectionState.Open || sqlConnection.State == ConnectionState.Broken)
                        {
                            sqlConnection.Open();
                        }
                        sqlTransaction = sqlConnection.BeginTransaction();

                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Transaction = sqlTransaction;

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            list = sqlDataReader.GetEnumerator(generator).ToList();
                        }
                        sqlTransaction.Commit();

                        if (outParam != null)
                        {
                            foreach (SqlParameter param in sqlCommand.Parameters)
                            {
                                if (param.Direction == ParameterDirection.ReturnValue || param.Direction == ParameterDirection.Output)
                                {
                                    outParam.Add(param.ParameterName, param.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (sqlTransaction != null)
                        {
                            sqlTransaction.Rollback();
                        }
                        throw ex;
                    }
                    finally
                    {                        
                        sqlCommand.Parameters.Clear();

                        if (sqlConnection.State != ConnectionState.Closed)
                        {
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return list;
        }

        private IList<T> ExecuteDataReader<T>(ref Hashtable outParam, Func<IDataRecord, T> generator, IEnumerable parameters)
        {
            IList<T> list = null;

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(this.CommandText, sqlConnection))
                {
                    SqlTransaction sqlTransaction = null;
                    try
                    {
                        if (parameters != null)
                        {
                            AttachParametersToCommand(sqlCommand, parameters);
                        }

                        if (sqlConnection.State != ConnectionState.Open || sqlConnection.State == ConnectionState.Broken)
                        {
                            sqlConnection.Open();
                        }
                        sqlTransaction = sqlConnection.BeginTransaction();

                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Transaction = sqlTransaction;

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            list = sqlDataReader.GetEnumerator(generator).ToList();
                        }
                        sqlTransaction.Commit();

                        if (outParam != null)
                        {
                            foreach (SqlParameter param in sqlCommand.Parameters)
                            {
                                if (param.Direction == ParameterDirection.ReturnValue || param.Direction == ParameterDirection.Output)
                                {
                                    outParam.Add(param.ParameterName, param.Value);
                                }
                            }
                        }                        
                    }
                    catch (Exception ex)
                    {
                        if (sqlTransaction != null)
                        {
                            sqlTransaction.Rollback();
                        }
                        throw ex;
                    }
                    finally
                    {
                        sqlCommand.Parameters.Clear();

                        if (sqlConnection.State != ConnectionState.Closed)
                        {
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return list;
        }

        #endregion
    }
}
