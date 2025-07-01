using DotNet.Test.Api.Shared.Repositories;
using DotNet.Test.Api.Subscriptions.Domain.Entities;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public class UpdateSubscriptionHandler : IUpdateSubscriptionHandler
{
    private readonly ISubscriptionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public Subscription Handle(UpdateSubscriptionCommand command)
    {
        throw new NotImplementedException();
    }

    public UpdateSubscriptionHandler(ISubscriptionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async ValueTask<Subscription> HandleAsync(UpdateSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = await _repository.FindByIdAsync(command.Id, cancellationToken);

        if (subscription is null)
        {
            throw new InvalidOperationException($"Subscription with ID {command.Id} not found.");
        }

        subscription.Update(
            command.AccountId,
            command.Type,
            command.Status,
            command.Payer,
            command.AvailablePaymentMethods,
            command.IntervalMultiplier
        );

        await _repository.UpdateAsync(subscription, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return subscription;
    }
}

