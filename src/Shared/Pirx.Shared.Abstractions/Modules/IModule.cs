using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Pirx.Shared.Abstractions.Modules;

public interface IModule
{
    void ConfigureServices(IServiceCollection services);
    void Configure(IApplicationBuilder app);
}