using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Pirx.Launcher")]
namespace Pirx.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        return services;
    }
}