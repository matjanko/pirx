using Pirx.Shared.Infrastructure;
using Pirx.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
var assemblies = ModuleLoader.LoadModuleAssemblies();
var modules = ModuleLoader.LoadModules(assemblies);

// Add services to the container.
builder.Services.AddInfrastructure(assemblies);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

modules.ToList().ForEach(x => x.ConfigureServices(builder.Services));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();