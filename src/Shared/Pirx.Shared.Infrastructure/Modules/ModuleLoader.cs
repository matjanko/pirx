using System.Reflection;
using System.Runtime.CompilerServices;
using Pirx.Shared.Abstractions.Modules;

[assembly: InternalsVisibleTo("Pirx.Launcher")]
namespace Pirx.Shared.Infrastructure.Modules;

internal static class ModuleLoader
{
    public static IEnumerable<Assembly> LoadModuleAssemblies()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase) && x.Contains("Pirx.Modules.")).ToList();

        return files.Select(x => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))).ToList();
    }

    public static IEnumerable<IModule> LoadModules(IEnumerable<Assembly> assemblies)
    {
        var modules = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();

        return modules;
    }
}