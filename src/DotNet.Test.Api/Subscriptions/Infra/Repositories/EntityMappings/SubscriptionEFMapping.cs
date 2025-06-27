using System.Data;

using DotNet.Test.Api.Shared.ValueObjects;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.Test.Api.Subscriptions.Infra.Repositories.EntityMappings;

public class SubscriptionEFMapping : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscription");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(36)
            .IsRequired();
        builder.Property(x => x.AccountId)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(36)
            .IsRequired();
        builder.Property(x => x.CreatedAt)
            .HasColumnType(nameof(SqlDbType.DateTime))
            .IsRequired();
        builder.Property(x => x.Status)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(x => x.Type)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(x => x.SelectedPaymentMethod)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(20);
        builder.OwnsOne(x => x.Payer, x =>
            {
                x.Property(xy => xy.Name)
                    .HasColumnName("payerName")
                    .HasColumnType(nameof(SqlDbType.VarChar))
                    .HasMaxLength(100)
                    .IsRequired();
                x.Property(xy => xy.Email)
                    .HasColumnName("payerEmail")
                    .HasColumnType(nameof(SqlDbType.VarChar))
                    .HasMaxLength(100);
                x.Property(xy => xy.TaxId)
                    .HasColumnName("payerTaxId")
                    .HasColumnType(nameof(SqlDbType.VarChar))
                    .HasMaxLength(100);
                x.Property(xy => xy.Mobile)
                    .HasColumnName("payerMobile")
                    .HasColumnType(nameof(SqlDbType.VarChar))
                    .HasMaxLength(100);
            });
        builder.Property(x => x.AvailablePaymentMethods)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(256)
            .HasConversion<string>(x => string.Join(',', x), x => PaymentMethods.Create(x))
            .IsRequired();
        builder.Property(x => x.LastInvoiceId)
            .HasColumnType(nameof(SqlDbType.VarChar))
            .HasMaxLength(36);
        builder.Property(x => x.IntervalMultiplier)
            .HasColumnType(nameof(SqlDbType.Int))
            .IsRequired();
        
        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.SubscriptionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}