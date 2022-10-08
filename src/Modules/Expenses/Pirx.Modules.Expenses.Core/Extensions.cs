using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Pirx.Modules.Expenses.Core.Domain.Issuers;
using Pirx.Modules.Expenses.Core.Domain.Receipts;
using Pirx.Modules.Expenses.Core.Infrastructure.Database;
using Pirx.Modules.Expenses.Core.Infrastructure.Database.Repositories;
using Pirx.Shared.Infrastructure.Persistence.Npgsql;

[assembly: InternalsVisibleTo("Pirx.Modules.Expenses.Api")]
namespace Pirx.Modules.Expenses.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddNpgsql<ExpensesContext>()
            .AddScoped<IReceiptRepository, ReceiptRepository>()
            .AddScoped<IIssuerRepository, IssuerRepository>();

        return services;
    }
}