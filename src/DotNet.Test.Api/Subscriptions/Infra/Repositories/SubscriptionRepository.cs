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
}