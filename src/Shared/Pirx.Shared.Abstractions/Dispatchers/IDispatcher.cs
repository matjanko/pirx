using Pirx.Shared.Abstractions.Commands;

namespace Pirx.Shared.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
}