using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pirx.Shared.Infrastructure.Options;

namespace Pirx.Shared.Infrastructure.Persistence.Npgsql;

public static class Extensions
{
    public static IServiceCollection AddNpgsql<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        var options = services.GetOptions<NpgsqlOptions>("Npgsql");
        
        services.AddDbContext<TContext>(builder =>
        {
            builder.UseNpgsql(options.ConnectionString ?? string.Empty);
        });

        services.AddScoped<TContext>();
            
        return services;
    }
}