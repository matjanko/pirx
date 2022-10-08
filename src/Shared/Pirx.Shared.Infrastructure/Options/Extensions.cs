using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pirx.Shared.Infrastructure.Options;

internal static class Extensions
{
    public static TModel GetOptions<TModel>(this IServiceCollection services, string key)
        where TModel : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        return configuration.GetOptions<TModel>(key);
    }
    
    private static TModel GetOptions<TModel>(this IConfiguration? configuration, string key)
        where TModel : new()
    {
        var model = new TModel();
        configuration?.GetSection(key).Bind(model);
        return model;
    }
}