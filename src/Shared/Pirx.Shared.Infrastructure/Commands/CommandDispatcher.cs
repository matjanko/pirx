using Microsoft.Extensions.DependencyInjection;
using Pirx.Shared.Abstractions.Commands;

namespace Pirx.Shared.Infrastructure.Commands;

internal class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public CommandDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command);
    }
}