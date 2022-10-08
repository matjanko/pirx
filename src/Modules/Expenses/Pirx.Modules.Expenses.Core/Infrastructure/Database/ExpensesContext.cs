using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pirx.Modules.Expenses.Core.Domain.Issuers;
using Pirx.Modules.Expenses.Core.Domain.Receipts;

namespace Pirx.Modules.Expenses.Core.Infrastructure.Database;

internal class ExpensesContext : DbContext
{
    public ExpensesContext(DbContextOptions<ExpensesContext> options) : base(options)
    {
        
    }
    
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Issuer> Issuers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}