using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Shared.Repositories;
using DotNet.Test.Api.Subscriptions.Domain.Entities;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public class CreateSubscriptionHandler : ICreateSubscriptionHandler
{
    private readonly ISubscriptionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionHandler(ISubscriptionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async ValueTask<Subscription> HandleAsync(CreateSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = Subscription.Create(
            command.AccountId,
            command.Type,
            command.Status,
            command.Payer,
            command.AvailablePaymentMethods,
            command.IntervalMultiplier
        );

        await _repository.AddAsync(subscription, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return subscription;
    }
}

