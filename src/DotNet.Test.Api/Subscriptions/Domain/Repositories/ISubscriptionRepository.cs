using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

namespace DotNet.Test.Api.Subscriptions.Domain.Repositories;

public interface ISubscriptionRepository
{
    ValueTask<IReadOnlyCollection<Subscription>> FindAllAsync(IFindAll request, CancellationToken cancellationToken);
}