using DotNet.Test.Api.Shared.Repositories;
using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace DotNet.Test.Api.Subscriptions.Infra.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly SubscriptionDbContext _context;

    public SubscriptionRepository(SubscriptionDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async ValueTask<IReadOnlyCollection<Subscription>> FindAllAsync(IFindAll request, CancellationToken cancellationToken)
    {
        return await _context.Subscriptions.ToListAsync(cancellationToken);
    }

    public async Task<Subscription> FindByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await _context.Subscriptions.FindAsync([id], cancellationToken);
    }

    public async Task AddAsync(Subscription subscription, CancellationToken cancellationToken)
    {
        await _context.Subscriptions.AddAsync(subscription, cancellationToken);
    }

    public Task UpdateAsync(Subscription subscription, CancellationToken cancellationToken)
    {
        _context.Subscriptions.Update(subscription);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Subscription subscription, CancellationToken cancellationToken)
    {
        _context.Subscriptions.Remove(subscription);
         return Task.CompletedTask;
    }
}
