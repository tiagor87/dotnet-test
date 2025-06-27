using DotNet.Test.Api.Shared.ValueObjects;

using TheNoobs.AggregateRoot;

namespace DotNet.Test.Api.Subscriptions.Domain.Entities;

public interface ISubscriptionView
{
    string Id { get; }
    string AccountId { get; }
    DateTime CreatedAt { get; }
    string Status { get; }
    string Type { get; }
    string? SelectedPaymentMethod { get; }
    IPayerView? Payer { get; }
    IPaymentMethodsView AvalilablePaymentMethods { get; }
    string? LastInvoiceId { get; }
    short IntervalMultiplier { get; }
    IEnumerable<ISubscriptionItemView> Items { get; }
}

public class Subscription : AggregateRoot<string>
{
    protected Subscription() : base(new Id())
    {
        AccountId = null!;
        CreatedAt = default;
        Status = null!;
        Type = null!;
        SelectedPaymentMethod = null!;
        Payer = null!;
        AvailablePaymentMethods = null!;
        LastInvoiceId = null!;
        IntervalMultiplier = 0;
        Items = [];
    }
    
    public string AccountId { get; }
    public DateTime CreatedAt { get; }
    public string Status { get; }
    public string Type { get; }
    public string? SelectedPaymentMethod { get; }
    public virtual Payer? Payer { get; }
    public PaymentMethods AvailablePaymentMethods { get; }
    public string? LastInvoiceId { get; }
    public short IntervalMultiplier { get; }
    public virtual List<SubscriptionItem> Items { get; }
    
    public ISubscriptionView ToView() => new SubscriptionView(this);

    class SubscriptionView(Subscription subscription) : ISubscriptionView
    {
        public string Id => subscription.Id;

        public string AccountId => subscription.AccountId;

        public DateTime CreatedAt => subscription.CreatedAt;

        public string Status => subscription.Status;

        public string Type => subscription.Type;

        public string? SelectedPaymentMethod => subscription.SelectedPaymentMethod;

        public IPayerView? Payer => subscription.Payer?.ToView();

        public IPaymentMethodsView AvalilablePaymentMethods => subscription.AvailablePaymentMethods.ToView();

        public string? LastInvoiceId => subscription.LastInvoiceId;

        public short IntervalMultiplier => subscription.IntervalMultiplier;

        public IEnumerable<ISubscriptionItemView> Items => subscription.Items.Select(x => x.ToView());
    }
}