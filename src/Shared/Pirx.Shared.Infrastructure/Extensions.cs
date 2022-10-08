using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Pirx.Shared.Abstractions.Dispatchers;
using Pirx.Shared.Abstractions.Persistence;
using Pirx.Shared.Infrastructure.Commands;
using Pirx.Shared.Infrastructure.Dispatchers;
using Pirx.Shared.Infrastructure.Persistence;

[assembly: InternalsVisibleTo("Pirx.Launcher")]
namespace Pirx.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services
            .AddCommands(assemblies)
            .AddSingleton<IDispatcher, InMemoryDispatcher>()
            .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        
        return services;
    }
}