using System;
namespace DatabaseFactory.Data.Contracts
{
    public interface IHandleQuery<TQuery, TResult> where TQuery: IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
