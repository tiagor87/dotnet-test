using System.Data;

using DotNet.Test.Api.Subscriptions.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.Test.Api.Subscriptions.Infra.Repositories.EntityMappings;

public class SubscriptionItemEFMapping : IEntityTypeConfiguration<SubscriptionItem>
{
    public void Configure(EntityTypeBuilder<SubscriptionItem> builder)
    {
        builder.ToTable("SubscriptionItem");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(36)
            .IsRequired();
        builder.Property(x => x.SubscriptionId)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(36)
            .IsRequired();
        builder.Property(x => x.Name)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Price)
            .HasColumnType(nameof(SqlDbType.BigInt))
            .IsRequired();
        builder.Property(x => x.Currency)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(3)
            .IsRequired();
        builder.Property(x => x.CreatedAt)
            .HasColumnType(nameof(SqlDbType.DateTimeOffset))
            .IsRequired();
        builder.Property(x => x.StartAt)
            .HasColumnType(nameof(SqlDbType.DateTimeOffset))
            .IsRequired();
        builder.Property(x => x.EndAt)
            .HasColumnType(nameof(SqlDbType.DateTimeOffset));
        builder.Property(x => x.DeletedAt)
            .HasColumnType(nameof(SqlDbType.DateTimeOffset));
    }
}