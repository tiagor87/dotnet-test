using DotNet.Test.Api.Shared.ValueObjects;
using DotNet.Test.Api.Subscriptions.Domain.Commands;

using TheNoobs.AggregateRoot;

namespace DotNet.Test.Api.Subscriptions.Domain.Entities;

public interface ISubscriptionItemView
{
    string Name { get; }
    long Price { get; }
    string Currency { get; }
    DateTimeOffset CreatedAt { get; }
    DateTimeOffset StartAt { get; }
    DateTimeOffset? EndAt { get; }
    DateTimeOffset? DeletedAt { get; }
}

public class SubscriptionItem : Entity<string>
{
    protected SubscriptionItem() : base(new Id())
    {
        SubscriptionId = string.Empty;
        Name = string.Empty;
        Price = 0;
        Currency = string.Empty;
        CreatedAt = default;
        StartAt = default;
        EndAt = null;
        DeletedAt = null;
    }

    public SubscriptionItem(Subscription subscription, ICreateSubscription.ICreateSubscriptionItem command) : this()
    {
        SubscriptionId = subscription.Id;
        Name = command.Name;
        Price = command.Price;
        Currency = command.Currency;
        CreatedAt = DateTimeOffset.UtcNow;
        StartAt = DateTimeOffset.UtcNow;
    }

    public string SubscriptionId { get; }
    public string Name { get; }
    public long Price { get; }
    public string Currency { get; }
    public DateTimeOffset CreatedAt { get; }
    public DateTimeOffset StartAt { get; }
    public DateTimeOffset? EndAt { get; }
    public DateTimeOffset? DeletedAt { get; }
    
    public ISubscriptionItemView ToView() => new SubscriptionItemView(this);
    
    class SubscriptionItemView(SubscriptionItem item) : ISubscriptionItemView
    {
        public string Name => item.Name;
        public long Price => item.Price;
        public string Currency => item.Currency;
        public DateTimeOffset CreatedAt => item.CreatedAt;
        public DateTimeOffset StartAt => item.StartAt;
        public DateTimeOffset? EndAt => item.EndAt;
        public DateTimeOffset? DeletedAt => item.DeletedAt;
    }
}