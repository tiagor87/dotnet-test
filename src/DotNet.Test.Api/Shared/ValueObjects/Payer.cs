using DotNet.Test.Api.Subscriptions.Domain.Commands;

using TheNoobs.ValueObjects.Abstractions;

namespace DotNet.Test.Api.Shared.ValueObjects;

public interface IPayerView
{
    string Name { get; }
    string? Email { get; }
    string? TaxId { get; }
    string? Mobile { get; }
}

public class Payer : ValueObject
{
    protected Payer()
    {
        Name = null!;
        Email = null!;
        TaxId = null!;
        Mobile = null!;
    }

    public Payer(ICreateSubscription.ICreatePayer command)
    {
        Name = command.Name;
        Email = command.Email;
        TaxId = command.TaxId;
        Mobile = command.Mobile;
    }
    
    public string Name { get; }
    public string? Email { get; }
    public string? TaxId { get; }
    public string? Mobile { get; }

    public IPayerView ToView() => new PayerView(this);
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Email ?? string.Empty;
        yield return TaxId ?? string.Empty;
        yield return Mobile ?? string.Empty;
    }
    
    class PayerView(Payer payer) : IPayerView
    {
        public string Name => payer.Name;
        public string? Email => payer.Email;
        public string? TaxId => payer.TaxId;
        public string? Mobile => payer.Mobile;
    }
}