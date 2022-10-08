using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pirx.Modules.Expenses.Core.Domain.Issuers;

namespace Pirx.Modules.Expenses.Core.Infrastructure.Database.Configurations;

internal class IssuerEntityTypeConfiguration : IEntityTypeConfiguration<Issuer>
{
    public void Configure(EntityTypeBuilder<Issuer> builder)
    {
        builder.ToTable("issuers", "budget");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
    }
}