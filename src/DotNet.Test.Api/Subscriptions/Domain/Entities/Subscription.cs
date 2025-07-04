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

    public string AccountId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string Status { get; private set; }
    public string Type { get; private set; }
    public string? SelectedPaymentMethod { get; private set; }
    public virtual Payer? Payer { get; private set; }
    public PaymentMethods AvailablePaymentMethods { get; private set; }
    public string? LastInvoiceId { get; private set; }
    public short IntervalMultiplier { get; private set; }
    public virtual List<SubscriptionItem> Items { get; private set; }

    public ISubscriptionView ToView() => new SubscriptionView(this);

    internal void Update(string accountId, string type, string status, Payer payer, string[] availablePaymentMethods, int intervalMultiplier)
    {
        AccountId = accountId;
        Type = type;
        Status = status;
        Payer = payer;
        AvailablePaymentMethods = PaymentMethods.Create(string.Join(",", availablePaymentMethods));
        IntervalMultiplier = (short)intervalMultiplier;
    }

    public static Subscription Create(string accountId, string type, string status, Payer payer, string[] availablePaymentMethods, int intervalMultiplier)
    {
        var subscription = new Subscription
        {
            AccountId = accountId,
            Type = type,
            Status = status,
            Payer = payer,
            AvailablePaymentMethods = PaymentMethods.Create(string.Join(",", availablePaymentMethods)),
            IntervalMultiplier = (short)intervalMultiplier
        };
        return subscription;
    }

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
