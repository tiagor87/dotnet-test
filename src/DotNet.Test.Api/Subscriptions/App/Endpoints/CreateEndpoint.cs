using DotNet.Test.Api.Subscriptions.Domain.Commands;

using Microsoft.AspNetCore.Mvc;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public static class CreateEndpoint
{
    public static async Task<IResult> HandleAsync(
        [FromBody] CreateSubscriptionDto command,
        [FromServices] ICreateSubscriptionHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.HandleAsync(command, cancellationToken);
        return Results.Created($"/subscriptions/{result.Id}", result);
    }
    
    public class CreateSubscriptionDto : ICreateSubscription
    {
        public string AccountId { get; init; } = null!;
        public string Type { get; init; } = null!;
        public string Status { get; init; } = null!;
        public PayerDto Payer { get; init; } = null!;
        ICreateSubscription.ICreatePayer ICreateSubscription.Payer => Payer;
        public string[] AvailablePaymentMethods { get; init; } = null!;
        public short IntervalMultiplier { get; init; }

        public string IntervalType { get; init; }

        public SubscriptionItemDto[] Items { get; init; } = null!;
        ICreateSubscription.ICreateSubscriptionItem[] ICreateSubscription.Items => Items;
    }

    public class SubscriptionItemDto : ICreateSubscription.ICreateSubscriptionItem
    {
        public string Name { get; init; } = null!;
        public long Price { get; init; }
        public string Currency { get; init; } = null!;
    }

    public class PayerDto : ICreateSubscription.ICreatePayer
    {
        public string Name { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string TaxId { get; init; } = null!;
        public string Mobile { get; init; } = null!;
    }
}