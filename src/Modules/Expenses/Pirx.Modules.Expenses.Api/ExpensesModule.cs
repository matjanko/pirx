using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pirx.Modules.Expenses.Core;
using Pirx.Shared.Abstractions.Modules;

namespace Pirx.Modules.Expenses.Api;

internal class ExpensesModule : IModule
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Configure(IApplicationBuilder app)
    {
        
    }
}