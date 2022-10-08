using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pirx.Modules.Expenses.Core.Domain.Receipts;

namespace Pirx.Modules.Expenses.Core.Infrastructure.Database.Configurations;

internal class ReceiptEntityTypeConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.ToTable("receipts", "budget");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property<DateTime>("_issueDate").HasColumnName("issue_date").IsRequired();
        builder.Property<int>("_issuerId").HasColumnName("issuer_id").IsRequired();
    }
}