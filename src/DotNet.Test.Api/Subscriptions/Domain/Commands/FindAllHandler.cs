using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public interface IFindAll
{
    int? PageSize { get; }
    int? Page { get; }
}

public interface IFindAllHandler : IHandler<IFindAll, IEnumerable<ISubscriptionView>>;

public class FindAllHandler : IFindAllHandler
{
    private readonly ISubscriptionRepository _repository;

    public FindAllHandler(ISubscriptionRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async ValueTask<IEnumerable<ISubscriptionView>> HandleAsync(IFindAll command, CancellationToken cancellationToken)
    {
        var subscriptions = await _repository.FindAllAsync(command, cancellationToken);
        return subscriptions.Select(x => x.ToView());
    }
}