using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public class FindByIdHandler : IFindByIdHandler
{
    private readonly ISubscriptionRepository _repository;

    public FindByIdHandler(ISubscriptionRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public ISubscriptionView Handle(FindByIdCommand command)
    {
        throw new NotImplementedException();
    }


    public async ValueTask<ISubscriptionView> HandleAsync(FindByIdCommand command, CancellationToken cancellationToken)
    {
        var subscription = await _repository.FindByIdAsync(command.Id, cancellationToken);

        if (subscription is null)
        {
            throw new InvalidOperationException($"Subscription with ID {command.Id} not found.");
        }

        return subscription.ToView();
    }
}

