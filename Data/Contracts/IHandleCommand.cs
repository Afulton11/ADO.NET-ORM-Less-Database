using System;
namespace DatabaseFactory.Data.Contracts
{
    public interface IHandleCommand<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
