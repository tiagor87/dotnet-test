using DotNet.Test.Api.Subscriptions.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using TheNoobs.AggregateRoot.Abstractions;

namespace DotNet.Test.Api.Shared.Repositories;

public class SubscriptionDbContext : DbContext, IUnitOfWork
{
    public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options) : base(options)
    {
    }
    
    internal DbSet<Subscription> Subscriptions { get; set; }

    public async ValueTask CompleteAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyMarker.Self);
        modelBuilder.Ignore<IDomainEvent>();
    }
}