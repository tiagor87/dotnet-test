using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Shared.Repositories;
using DotNet.Test.Api.Shared.ValueObjects;
using DotNet.Test.Api.Subscriptions.Domain.Entities;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public interface ICreateSubscription
{
    string AccountId { get; }
    string Type { get; }
    string IntervalType { get; }
    string Status { get; }
    ICreatePayer Payer { get;}
    string[] AvailablePaymentMethods { get; }
    short IntervalMultiplier { get; }
    ICreateSubscriptionItem[] Items { get; }
    
    
    public interface ICreatePayer
    {
        string Name { get; }
        string? Email { get; }
        string? TaxId { get; }
        string? Mobile { get; }
    }

    public interface ICreateSubscriptionItem
    {
        string Name { get; }
        long Price { get; }
        string Currency { get; }
    }
}

public interface ICreateSubscriptionHandler : IHandler<ICreateSubscription, Subscription>;

public class CreateSubscriptionHandler : ICreateSubscriptionHandler
{
    private readonly ISubscriptionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionHandler(ISubscriptionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async ValueTask<Subscription> HandleAsync(ICreateSubscription command, CancellationToken cancellationToken)
    {
        var subscription = new Subscription(command);

        await _repository.AddAsync(subscription, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return subscription;
    }
}
