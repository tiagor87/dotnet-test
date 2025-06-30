using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Shared.ValueObjects;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public record CreateSubscriptionCommand(
    string AccountId,
    string Type,
    string Status,
    Payer Payer,
    string[] AvailablePaymentMethods,
    int IntervalMultiplier
);

public interface ICreateSubscriptionHandler : IHandler<CreateSubscriptionCommand, Subscription>
{
}
