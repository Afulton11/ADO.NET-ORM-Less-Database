using System.Data;
using System.Data.SqlClient;
using DatabaseFactory.Config;

namespace DatabaseFactory.Data
{
    public class SQLDatabase : Database
    {
        public SQLDatabase()
            : this(new DatabaseOptions<SQLDatabase>())
        {
        }

        public SQLDatabase(DatabaseOptions options) : base(options)
        {
        }

        public override IDbCommand CreateCommand() =>
            new SqlCommand();

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            var cmd = CreateCommand();
            cmd.CommandText = commandText;
            cmd.Connection = connection;

            return cmd;
        }        

        public override IDbCommand CreateCommand(string commandText, IDbTransaction transaction)
        {
            var cmd = CreateCommand();
            cmd.CommandText = commandText;
            cmd.Transaction = transaction;
            cmd.Connection = transaction.Connection;

            return cmd;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue) =>
            new SqlParameter(parameterName, parameterValue);

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            var cmd = CreateCommand();
            cmd.CommandText = procName;
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbTransaction transaction)
        {
            var cmd = CreateCommand();
            cmd.CommandText = procName;
            cmd.Connection = transaction.Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaction;

            return cmd;
        }

        public override IDbConnection CreateConnection()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = options.ConnectionString;

            return connection;
        }

        public override IDbConnection OpenConnection(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                if (string.IsNullOrEmpty(connection.ConnectionString))
                {
                    connection.ConnectionString = options.ConnectionString;
                }
                connection.Open();
            }

            return connection;
        }
    }
}
