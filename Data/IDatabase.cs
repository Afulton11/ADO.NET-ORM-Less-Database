using System;
using System.Data;

namespace DatabaseFactory.Data.Contracts
{
    public interface IDatabase
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand();
        IDbConnection OpenConnection(IDbConnection connection);
        IDbCommand CreateCommand(string commandText, IDbConnection connection);
        IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        IDbCommand CreateStoredProcCommand(string procName, IDbTransaction transaction);
        IDataParameter CreateParameter(string parameterName, object parameterValue);

        void TryExecuteTransaction(Action<IDbTransaction> transactionAction);

        TResult TryExecuteTransaction<TResult>(Func<IDbTransaction, TResult> transactionFunc);

        void TryRollback(IDbTransaction transaction);

        void ExecuteReader(IDbCommand command, Action<IDataReader> onRead);
        TResult ExecuteReader<TResult>(IDbCommand command, Func<IDataReader, TResult> onRead);

        T ExecuteScalar<T>(IDbCommand command);

        int Execute(IDbCommand command);
    }
}
