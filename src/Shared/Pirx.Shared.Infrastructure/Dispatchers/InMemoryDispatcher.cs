using Pirx.Shared.Abstractions.Commands;
using Pirx.Shared.Abstractions.Dispatchers;

namespace Pirx.Shared.Infrastructure.Dispatchers;

public class InMemoryDispatcher : IDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;

    public InMemoryDispatcher(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    public Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        => _commandDispatcher.SendAsync(command);
}