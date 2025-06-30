using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

namespace DotNet.Test.Api.Subscriptions.Domain.Repositories;

public interface ISubscriptionRepository
{
    Task AddAsync(Subscription subscription, CancellationToken cancellationToken);
    Task DeleteAsync(Subscription subscription, CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<Subscription>> FindAllAsync(IFindAll request, CancellationToken cancellationToken);
    Task<Subscription> FindByIdAsync(string id, CancellationToken cancellationToken);
    Task UpdateAsync(Subscription subscription, CancellationToken cancellationToken);
}
