using System;
using System.Data;

namespace DatabaseFactory.Data.Contracts
{
    public interface IDatabase
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand();
        IDbConnection CreateOpenConnection();
        IDbCommand CreateCommand(string commandText, IDbConnection connection);
        IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        IDbCommand CreateStoredProcCommand(string procName, IDbTransaction transaction);
        IDataParameter CreateParameter(string parameterName, object parameterValue);

        void TryExecuteTransaction(Action<IDbTransaction> transactionAction);
        void TryRollback(IDbTransaction transaction);

        void ExecuteReader(IDbCommand command, Action<IDataReader> onRead);

        T ExecuteScalar<T>(IDbCommand command);

        int Execute(IDbCommand command);
    }
}
