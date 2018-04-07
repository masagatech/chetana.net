namespace Idv.Chetana.DAL
{
    using Idv.Chetana.Common;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class DataServiceBase
    {
        private bool _isOwner;
        private SqlTransaction _txn;

        public DataServiceBase() : this(null)
        {
        }

        public DataServiceBase(IDbTransaction txn)
        {
            this._isOwner = false;
            if (txn == null)
            {
                this._isOwner = true;
            }
            else
            {
                this._txn = (SqlTransaction) txn;
                this._isOwner = false;
            }
        }

        public static IDbTransaction BeginTransaction()
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            connection.Open();
            return connection.BeginTransaction();
        }

        protected object CheckParamValue(DateTime paramValue)
        {
            if (paramValue.Equals(Constants.NullDateTime))
            {
                return DBNull.Value;
            }
            return paramValue;
        }

        protected object CheckParamValue(decimal paramValue)
        {
            if (paramValue.Equals(Constants.NullDecimal))
            {
                return DBNull.Value;
            }
            return paramValue;
        }

        protected object CheckParamValue(double paramValue)
        {
            if (paramValue.Equals(Constants.NullDouble))
            {
                return DBNull.Value;
            }
            return paramValue;
        }

        protected object CheckParamValue(Guid paramValue)
        {
            if (paramValue.Equals(Constants.NullGuid))
            {
                return DBNull.Value;
            }
            return paramValue;
        }

        protected object CheckParamValue(int paramValue)
        {
            if (paramValue.Equals(Constants.NullInt))
            {
                return 0;
            }
            return paramValue;
        }

        protected object CheckParamValue(float paramValue)
        {
            if (paramValue.Equals(Constants.NullFloat))
            {
                return DBNull.Value;
            }
            return paramValue;
        }

        protected object CheckParamValue(string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                return DBNull.Value;
            }
            return paramValue;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, ParameterDirection direction)
        {
            SqlParameter parameter = this.CreateParameter(paramName, paramType, DBNull.Value);
            parameter.Direction = direction;
            return parameter;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue)
        {
            SqlParameter parameter = new SqlParameter(paramName, paramType);
            if (paramValue != DBNull.Value)
            {
                switch (paramType)
                {
                    case SqlDbType.Bit:
                        if (paramValue is bool)
                        {
                            paramValue = ((bool) paramValue) ? 1 : 0;
                        }
                        if ((((int) paramValue) < 0) || (((int) paramValue) > 1))
                        {
                            paramValue = Constants.NullInt;
                        }
                        paramValue = this.CheckParamValue((int) paramValue);
                        break;

                    case SqlDbType.Char:
                    case SqlDbType.NChar:
                    case SqlDbType.NVarChar:
                    case SqlDbType.Text:
                    case SqlDbType.VarChar:
                        paramValue = this.CheckParamValue((string) paramValue);
                        break;

                    case SqlDbType.DateTime:
                        paramValue = this.CheckParamValue((DateTime) paramValue);
                        break;

                    case SqlDbType.Decimal:
                        paramValue = this.CheckParamValue((decimal) paramValue);
                        break;

                    case SqlDbType.Float:
                        paramValue = this.CheckParamValue(Convert.ToSingle(paramValue));
                        break;

                    case SqlDbType.Int:
                        paramValue = this.CheckParamValue((int) paramValue);
                        break;

                    case SqlDbType.UniqueIdentifier:
                        paramValue = this.CheckParamValue(this.GetGuid(paramValue));
                        break;
                }
            }
            parameter.Value = paramValue;
            return parameter;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, ParameterDirection direction, int size)
        {
            SqlParameter parameter = this.CreateParameter(paramName, paramType, DBNull.Value);
            parameter.SqlDbType = paramType;
            parameter.Direction = direction;
            parameter.Size = size;
            parameter.Value = paramName;
            return parameter;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, ParameterDirection direction)
        {
            SqlParameter parameter = this.CreateParameter(paramName, paramType, paramValue);
            parameter.Direction = direction;
            return parameter;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size)
        {
            SqlParameter parameter = this.CreateParameter(paramName, paramType, paramValue);
            parameter.Size = size;
            return parameter;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size, byte precision)
        {
            SqlParameter parameter = this.CreateParameter(paramName, paramType, paramValue);
            parameter.Size = size;
            parameter.Precision = precision;
            return parameter;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size, ParameterDirection direction)
        {
            SqlParameter parameter = this.CreateParameter(paramName, paramType, paramValue);
            parameter.Direction = direction;
            parameter.Size = size;
            return parameter;
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size, byte precision, ParameterDirection direction)
        {
            SqlParameter parameter = this.CreateParameter(paramName, paramType, paramValue);
            parameter.Direction = direction;
            parameter.Size = size;
            parameter.Precision = precision;
            return parameter;
        }

        protected DataSet ExecuteDataSet(string procName, params IDataParameter[] procParams)
        {
            SqlCommand command;
            return this.ExecuteDataSet(out command, procName, procParams);
        }

        protected DataSet ExecuteDataSet(out SqlCommand cmd, string procName, params IDataParameter[] procParams)
        {
            SqlConnection connection = null;
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd = null;
            try
            {
                cmd = new SqlCommand(procName);
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int i = 0; i < procParams.Length; i++)
                    {
                        cmd.Parameters.Add(procParams[i]);
                    }
                }
                adapter.SelectCommand = cmd;
                if (this._isOwner)
                {
                    connection = new SqlConnection(GetConnectionString());
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0x2710;
                    connection.Open();
                }
                else
                {
                    cmd.Connection = this._txn.Connection;
                    cmd.Transaction = this._txn;
                }
                adapter.Fill(dataSet);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (this._isOwner)
                {
                    connection.Dispose();
                }
            }
            return dataSet;
        }

        protected void ExecuteNonQuery(string procName, params IDataParameter[] procParams)
        {
            SqlCommand command;
            this.ExecuteNonQuery(out command, procName, procParams);
        }

        protected void ExecuteNonQuery(out SqlCommand cmd, string procName, params IDataParameter[] procParams)
        {
            SqlConnection connection = null;
            cmd = null;
            try
            {
                cmd = new SqlCommand(procName);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < procParams.Length; i++)
                {
                    cmd.Parameters.Add(procParams[i]);
                }
                if (this._isOwner)
                {
                    connection = new SqlConnection(GetConnectionString());
                    cmd.Connection = connection;
                    connection.Open();
                }
                else
                {
                    cmd.Connection = this._txn.Connection;
                    cmd.Transaction = this._txn;
                }
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this._isOwner)
                {
                    connection.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }

        protected static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["idvConString"].ToString();
        }

        protected Guid GetGuid(object value)
        {
            Guid nullGuid = Constants.NullGuid;
            if (value is string)
            {
                return new Guid((string) value);
            }
            if (value is Guid)
            {
                nullGuid = (Guid) value;
            }
            return nullGuid;
        }

        public IDbTransaction Txn
        {
            get
            {
                return this._txn;
            }
            set
            {
                this._txn = (SqlTransaction) value;
            }
        }
    }
}

